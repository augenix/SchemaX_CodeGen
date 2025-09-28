
namespace SchemaX_CodeGen.CodeGen;

public static class DtsEmitter
{
    private const int DefaultListSize = 10;
    private static readonly Dictionary<string,int> SizeCache = new();

    public static void PrecomputeSizes(List<StructMeta> structs)
    {
        foreach (var meta in structs)
            SizeCache[meta.Name + "Dts"] = ComputeStructSize(meta, structs);
    }
    public static void EmitDts(IndentedStringBuilder sb, StructMeta meta, List<StructMeta> structs)
    {
        // Size: align to nearest 64 bytes for cache line safety
        int sizeBytes = ComputeStructSize(meta, structs);
        
        sb.AppendLine($"[StructLayout(LayoutKind.Sequential, Pack = 1, Size = {sizeBytes})]");
        sb.AppendLine($"public struct {meta.Name}Dts");
        sb.AppendLine("{");

        foreach (var field in meta.Fields)
        {
            // --- Handle lists by flattening ---
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
                    sb.AppendLine($"    public {inner} {field.Name}{i};");
            }
            else if (field.Type == "TextList")
            {
                for (int i = 0; i < DefaultListSize; i++)
                    sb.AppendLine($"    public FixedAscii32 {field.Name}{i};");
            }
            // --- Handle single fields ---
            else if (field.Type == "string")
            {
                sb.AppendLine($"    public FixedAscii32 {field.Name};");
            }
            else if (structs.Any(s => s.Name == field.Type)) // if the type is another struct we know
            {
                sb.AppendLine($"    public {field.Type}Dts {field.Name};");
            }
            else
            {
                sb.AppendLine($"    public {field.Type} {field.Name};");
            }
        }
        
        sb.AppendLine("}");
    }

    private static int ComputeStructSize(StructMeta meta, List<StructMeta> structs)
    {
        int total = 0;

        foreach (var field in meta.Fields)
        {
            if (field.Type == "string" || field.Type == "TextList")
            {
                total += 32;
            }
            else if (field.Type.StartsWith("StructList<"))
            {
                var inner = field.Type.Substring("StructList<".Length).TrimEnd('>');
                var childMeta = structs.First(s => s.Name == inner);
                total += 5 * ComputeStructSize(childMeta, structs); // flatten 5 elements
            }
            else if (structs.Any(s => s.Name == field.Type))
            {
                var childMeta = structs.First(s => s.Name == field.Type);
                total += ComputeStructSize(childMeta, structs);
            }
            else
            {
                total += field.Type switch
                {
                    "bool"   => 1,
                    "byte"   => 1,
                    "ushort" => 2,
                    "short"  => 2,
                    "int"    => 4,
                    "uint"   => 4,
                    "long"   => 8,
                    "ulong"  => 8,
                    "double" => 8,
                    _        => 8 // safe default
                };
            }
        }
        
        return ((total + 63) / 64) * 64;
    }
}
