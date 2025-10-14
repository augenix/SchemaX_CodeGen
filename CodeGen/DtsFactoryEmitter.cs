using System.Text;
using System.Runtime.CompilerServices;

namespace SchemaX_CodeGen.CodeGen
{
    public static class DtsFactoryEmitter
    {
        private const int DefaultListSize = 10; // keep in sync with DtsEmitter

        public static void EmitFromDecoder(IndentedStringBuilder sb, StructMeta meta, List<StructMeta> structs)
        {
            sb.AppendLine($"    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
            sb.AppendLine($"    public static void FromDecoder(ref {meta.Name}Dts msg, in {meta.Name}Decoder reader)");
            sb.AppendLine("    {");
            sb.AppendLine("        int count;"); // ✅ single declaration for the whole method

            foreach (var field in meta.Fields)
            {
                // -------------------------------------------------------------
                // Struct list (e.g. Levels0–9)
                // -------------------------------------------------------------
                if (field.IsStructList)
                {
                    sb.AppendLine($"        var {field.Name}Accessor = reader.{field.Name};");
                    sb.AppendLine($"        count = {field.Name}Accessor.Count;");
                    sb.AppendLine($"        if (count > {DefaultListSize}) count = {DefaultListSize};");
                    sb.AppendLine("        for (int i = 0; i < count; i++)");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            var e = {field.Name}Accessor.GetElement(i);");
                    sb.AppendLine("            switch (i)");
                    sb.AppendLine("            {");
                    for (int i = 0; i < DefaultListSize; i++)
                        sb.AppendLine($"                case {i}: FromDecoder(ref msg.{field.Name}{i}, in e); break;");
                    sb.AppendLine("            }");
                    sb.AppendLine("        }");
                }

                // -------------------------------------------------------------
                // Primitive list
                // -------------------------------------------------------------
                else if (field.IsPrimitiveList)
                {
                    sb.AppendLine($"        var {field.Name}List = reader.{field.Name};");
                    sb.AppendLine($"        count = {field.Name}List.Length;");
                    sb.AppendLine($"        if (count > {DefaultListSize}) count = {DefaultListSize};");
                    sb.AppendLine("        for (int i = 0; i < count; i++)");
                    sb.AppendLine("        {");
                    sb.AppendLine("            switch (i)");
                    sb.AppendLine("            {");
                    for (int i = 0; i < DefaultListSize; i++)
                        sb.AppendLine($"                case {i}: msg.{field.Name}{i} = {field.Name}List[{i}]; break;");
                    sb.AppendLine("            }");
                    sb.AppendLine("        }");
                }

                // -------------------------------------------------------------
                // Text list (FixedAscii32)
                // -------------------------------------------------------------
                else if (field.IsTextList)
                {
                    sb.AppendLine($"        var {field.Name}List = reader.{field.Name};");
                    sb.AppendLine($"        count = {field.Name}List.Length;");
                    sb.AppendLine($"        if (count > {DefaultListSize}) count = {DefaultListSize};");
                    sb.AppendLine("        for (int i = 0; i < count; i++)");
                    sb.AppendLine("        {");
                    sb.AppendLine("            switch (i)");
                    sb.AppendLine("            {");
                    for (int i = 0; i < DefaultListSize; i++)
                        sb.AppendLine($"                case {i}: msg.{field.Name}{i}.Set({field.Name}List[{i}]); break;");
                    sb.AppendLine("            }");
                    sb.AppendLine("        }");
                }

                // -------------------------------------------------------------
                // String (FixedAscii32)
                // -------------------------------------------------------------
                else if (field.IsString)
                {
                    sb.AppendLine($"        msg.{field.Name}.Set(reader.{field.Name});");
                }

                else if (IsStructField(field, structs))
                {
                    // --- Flattened timestamp-like structs -----------------------------------
                    // Normalize the type name once (strip namespaces and trailing Dts)
                    string normType = field.Type;
                    {
                        int lastDot = normType.LastIndexOf('.');
                        if (lastDot >= 0) normType = normType[(lastDot + 1)..];
                        if (normType.EndsWith("Dts", StringComparison.Ordinal))
                            normType = normType[..^3];
                    }

                    if (normType == "UtcTime")
                    {
                        // Single timestamp -> read once
                        sb.AppendLine($"        msg.{field.Name}Ns = reader.{field.Name}.Reader().TimeNs;");
                    }
                    else if (normType == "CmeFeedManagerTimestamps")
                    {
                        // Cache the base timestamp reader ONCE, then read its children
                        string tsVar = field.Name + "Ts";
                        sb.AppendLine($"        var {tsVar} = reader.{field.Name}.Reader();");
                        sb.AppendLine($"        msg.{field.Name}_ExchangeNs = {tsVar}.Exchange.Reader().TimeNs;");
                        sb.AppendLine($"        msg.{field.Name}_SendingNs  = {tsVar}.Sending.Reader().TimeNs;");
                        sb.AppendLine($"        msg.{field.Name}_ReceiptNs  = {tsVar}.Receipt.Reader().TimeNs;");
                        sb.AppendLine($"        msg.{field.Name}_ExtractNs  = {tsVar}.Extract.Reader().TimeNs;");
                    }
                    else
                    {
                        // Fallback: normal nested struct decode
                        sb.AppendLine($"        var {field.Name}Struct = reader.{field.Name}.Reader();");
                        sb.AppendLine($"        FromDecoder(ref msg.{field.Name}, in {field.Name}Struct);");
                    }
                }


                // -------------------------------------------------------------
                // Primitive / enum
                // -------------------------------------------------------------
                else
                {
                    sb.AppendLine($"        msg.{field.Name} = reader.{field.Name};");
                }
            }

            sb.AppendLine("    }");
            sb.AppendLine();
        }
        
        private static bool IsFlattenableTimestamp(string type, List<StructMeta> structs)
        {
            var s = structs.FirstOrDefault(x => x.Name == type);
            if (s == null) return false;

            if (s.PointerWords == 0 && s.Fields.Count == 1 &&
                (s.Fields[0].Type is "long" or "Int64" or "ulong" or "UInt64"))
                return true;

            return s.Fields.All(f =>
                f.PointerIndex.HasValue && IsFlattenableTimestamp(f.Type, structs));
        }


        private static bool IsStructField(FieldMeta field, List<StructMeta> structs)
        {
            return structs.Any(s => s.Name == field.Type);
        }
    }
}
