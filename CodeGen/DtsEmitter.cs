using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace SchemaX_CodeGen.CodeGen
{
    public static class DtsEmitter
    {
        private const int DefaultListSize = 10;
        private const int NaturalAlign    = 8;
        private static int sz;

        private static readonly Dictionary<string, int> SizeCache = new();

        // --------------------------------------------------------------------
        //  Public entrypoints
        // --------------------------------------------------------------------

        public static void PrecomputeSizes(List<StructMeta> structs)
        {
            bool changed;
            do
            {
                changed = false;
                foreach (var meta in structs)
                {
                    var key = meta.Name + "Dts";
                    sz  = ComputeStructSize(meta, structs);
                    if (!SizeCache.TryGetValue(key, out var cur) || cur != sz)
                    {
                        SizeCache[key] = sz;
                        changed = true;
                    }
                }
            } while (changed);
        }
        private static bool IsFlattenableTimestamp(string type, List<StructMeta> structs)
        {
            var s = structs.FirstOrDefault(x => x.Name == type);
            if (s == null)
                return false;

            // terminal timestamp struct (one long field, no pointers)
            if (s.PointerWords == 0 && s.Fields.Count == 1 &&
                (s.Fields[0].Type is "long" or "Int64" or "ulong" or "UInt64"))
                return true;

            // wrapper struct that only contains pointer fields leading to terminal timestamps
            return s.Fields.All(f =>
                f.PointerIndex.HasValue && IsFlattenableTimestamp(f.Type, structs));
        }


        public static void EmitDts(IndentedStringBuilder sb, StructMeta meta, List<StructMeta> structs)
        {
            // Order fields for optimal packing
            var orderedFields = OrderFieldsForPacking(meta.Fields);

            // Compute total struct size (8-byte alignment)
            int sizeBytes = ComputeStructSize(meta, structs);

            sb.AppendLine($"[StructLayout(LayoutKind.Sequential, Pack = 1, Size = {sizeBytes})]");
            sb.AppendLine($"public struct {meta.Name}Dts");
            sb.AppendLine("{");

            foreach (var field in orderedFields)
            {
                // --- 🔹 Flatten timestamp-like structs (structs that terminate in one long field) ---
                if (IsFlattenableTimestamp(field.Type, structs))
                {
                    var root = structs.First(s => s.Name == field.Type);

                    // Case A: wrapper struct like CmeFeedManagerTimestamps
                    foreach (var sub in root.Fields)
                    {
                        // recurse to find final leaf
                        var leaf = structs.FirstOrDefault(s => s.Name == sub.Type);
                        if (leaf != null && leaf.PointerWords == 0 && leaf.Fields.Count == 1 &&
                            (leaf.Fields[0].Type is "long" or "Int64" or "ulong" or "UInt64"))
                        {
                            sb.AppendLine($"    public long {field.Name}_{sub.Name}Ns;");
                        }
                        else
                        {
                            // single-level timestamp (Exchange->UtcTime->TimeNs)
                            sb.AppendLine($"    public long {field.Name}Ns;");
                        }
                    }

                    continue;
                }
                
                // --- Flattened lists -------------------------------------------------
                if (field.Type.StartsWith("StructList<"))
                {
                    string inner = field.Type.Substring("StructList<".Length).TrimEnd('>');
                    for (int i = 0; i < DefaultListSize; i++)
                        sb.AppendLine($"    public {inner}Dts {field.Name}{i};");
                }
                else if (field.Type.StartsWith("PrimitiveList<"))
                {
                    string inner = field.Type.Substring("PrimitiveList<".Length).TrimEnd('>');
                    for (int i = 0; i < DefaultListSize; i++)
                        sb.AppendLine($"    public {MapPrimitive(inner)} {field.Name}{i};");
                }
                else if (field.Type == "TextList")
                {
                    for (int i = 0; i < DefaultListSize; i++)
                        sb.AppendLine($"    public FixedAscii32 {field.Name}{i};");
                }
                // --- Single fields ---------------------------------------------------
                else if (field.Type == "string")
                {
                    sb.AppendLine($"    public FixedAscii32 {field.Name};");
                }
                else if (structs.Any(s => s.Name == field.Type))
                {
                    sb.AppendLine($"    public {field.Type}Dts {field.Name};");
                }
                else
                {
                    sb.AppendLine($"    public {MapPrimitive(field.Type)} {field.Name};");
                }
            }

            // --------------------------------------------------------------------
            //  Runtime size assert (safety net for generated code)
            // --------------------------------------------------------------------
            sb.AppendLine();
            sb.AppendLine($"    static {meta.Name}Dts()");
            sb.AppendLine("    {");
            sb.AppendLine("        int sz = Unsafe.SizeOf<" + meta.Name + "Dts>();");
            sb.AppendLine($"        if ((sz & {NaturalAlign - 1}) != 0) throw new System.Exception($\"{meta.Name}Dts not 8B aligned: {sz}\");");
            sb.AppendLine($"        if (sz != {sizeBytes}) throw new System.Exception($\"{meta.Name}Dts size mismatch: {sz} != {sizeBytes}\");");
            sb.AppendLine("    }");
            sb.AppendLine("}");
        }

        // --------------------------------------------------------------------
        //  Size computation
        // --------------------------------------------------------------------
        private static int ComputeStructSize(StructMeta meta, List<StructMeta> structs)
        {
            var orderedFields = OrderFieldsForPacking(meta.Fields);
            int total = 0;

            foreach (var field in orderedFields)
            {
                if (field.Type == "string")
                {
                    total += 32; // FixedAscii32
                }
                else if (field.Type == "TextList")
                {
                    total += 32 * DefaultListSize;
                }
                else if (field.Type.StartsWith("StructList<"))
                {
                    string inner = field.Type.Substring("StructList<".Length).TrimEnd('>');
                    total += DefaultListSize * SizeOfStruct(inner, structs);
                }
                else if (field.Type.StartsWith("PrimitiveList<"))
                {
                    string inner = field.Type.Substring("PrimitiveList<".Length).TrimEnd('>');
                    total += DefaultListSize * SizeOfPrimitiveOrEnum(inner);
                }
                else if (structs.Any(s => s.Name == field.Type))
                {
                    total += SizeOfStruct(field.Type, structs);
                }
                else
                {
                    total += SizeOfPrimitiveOrEnum(field.Type);
                }
            }

            // Natural 8-byte alignment at struct end
            return AlignUp(total, NaturalAlign);
        }

        private static int SizeOfStruct(string structName, List<StructMeta> structs)
        {
            var key = structName + "Dts";
            if (SizeCache.TryGetValue(key, out var cached))
                return cached;

            var child = structs.First(s => s.Name == structName);
            var sz = ComputeStructSize(child, structs);
            SizeCache[key] = sz;
            return sz;
        }

        private static int SizeOfPrimitiveOrEnum(string type)
        {
            if (type.StartsWith("FixedAscii"))
            {
                if (int.TryParse(type.Substring("FixedAscii".Length), out var n) && n > 0)
                    return n;
                return 32;
            }

            return type switch
            {
                "bool"   => 1,
                "byte"   => 1,
                "sbyte"  => 1,
                "char"   => 2,
                "ushort" => 2,
                "short"  => 2,
                "int"    => 4,
                "uint"   => 4,
                "float"  => 4,
                "long"   => 8,
                "ulong"  => 8,
                "double" => 8,
                _        => 4  // default: enums / unknown scalars
            };
        }

        private static int AlignUp(int value, int align) => (value + (align - 1)) & ~(align - 1);

        // --------------------------------------------------------------------
        //  Field ordering logic
        // --------------------------------------------------------------------
        private static IEnumerable<FieldMeta> OrderFieldsForPacking(IEnumerable<FieldMeta> fields)
        {
            static int Tier(string t)
            {
                // smallest primitives first
                if (t is "bool" or "byte" or "sbyte" or "ushort" or "short") return 1;
                // 4-byte types (ints, floats, enums)
                if (t is "int" or "uint" or "float" || t.EndsWith("Kind") || t.EndsWith("Status")) return 2;
                // 8-byte types (longs, doubles, timestamps)
                if (t is "long" or "ulong" or "double" || t.Contains("Time") || t.Contains("Timestamp")) return 3;
                // Everything else (text, lists, nested structs)
                return 4;
            }

            return fields.OrderBy(f => Tier(f.Type));
        }

        // --------------------------------------------------------------------
        //  Primitive mapping helper
        // --------------------------------------------------------------------
        private static string MapPrimitive(string type)
        {
            return type switch
            {
                "boolean" => "bool",
                "i8"      => "sbyte",
                "u8"      => "byte",
                "i16"     => "short",
                "u16"     => "ushort",
                "i32"     => "int",
                "u32"     => "uint",
                "i64"     => "long",
                "u64"     => "ulong",
                "f32"     => "float",
                "f64"     => "double",
                _         => type
            };
        }
    }
}
