using System.Text;
using System.Runtime.CompilerServices;

namespace SchemaX_CodeGen.CodeGen;

    public static class DtsFactoryEmitter
    {
        private const int DefaultListSize = 10; // keep in sync with DtsEmitter

        public static void EmitFromDecoder(IndentedStringBuilder sb, StructMeta meta, List<StructMeta> structs)
        {
            sb.AppendLine($"    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
            sb.AppendLine($"    public static void FromDecoder(ref {meta.Name}Dts msg, in {meta.Name}Decoder reader)");
            sb.AppendLine("    {");

            foreach (var field in meta.Fields)
            {
                if (field.IsStructList)
                {
                    sb.AppendLine($"        var {field.Name}Accessor = reader.{field.Name};");
                    sb.AppendLine($"        switch ({field.Name}Accessor.Count)");
                    sb.AppendLine("        {");
                    for (int i = DefaultListSize; i >= 1; i--)
                    {
                        sb.AppendLine($"            case {i}:");
                        sb.AppendLine($"                var e{i - 1} = {field.Name}Accessor.GetElement({i - 1});");
                        sb.AppendLine($"                FromDecoder(ref msg.{field.Name}{i - 1}, in e{i - 1});");
                        sb.AppendLine($"                goto case {i - 1};");
                    }
                    sb.AppendLine("            case 0: break;");
                    sb.AppendLine("        }");
                }
                else if (field.IsPrimitiveList)
                {
                    var inner = field.InnerPrimitiveName;
                    sb.AppendLine($"        var {field.Name}List = reader.{field.Name};");
                    sb.AppendLine($"        switch ({field.Name}List.Length)");
                    sb.AppendLine("        {");
                    for (int i = DefaultListSize; i >= 1; i--)
                    {
                        sb.AppendLine($"            case {i}: msg.{field.Name}{i - 1} = {field.Name}List[{i - 1}]; goto case {i - 1};");
                    }
                    sb.AppendLine("            case 0: break;");
                    sb.AppendLine("        }");
                }
                else if (field.IsTextList)
                {
                    sb.AppendLine($"        var {field.Name}List = reader.{field.Name};");
                    sb.AppendLine($"        switch ({field.Name}List.Length)");
                    sb.AppendLine("        {");
                    for (int i = DefaultListSize; i >= 1; i--)
                    {
                        sb.AppendLine($"            case {i}: msg.{field.Name}{i - 1}.Set({field.Name}List[{i - 1}]); goto case {i - 1};");
                    }
                    sb.AppendLine("            case 0: break;");
                    sb.AppendLine("        }");
                }
                else if (field.IsString)
                {
                    sb.AppendLine($"        msg.{field.Name}.Set(reader.{field.Name});");
                }
                else if (IsStructField(field, structs))
                {
                    sb.AppendLine($"        var {field.Name}Struct = reader.{field.Name}.Reader();");
                    sb.AppendLine($"        FromDecoder(ref msg.{field.Name}, in {field.Name}Struct);");
                }
                else
                {
                    sb.AppendLine($"        msg.{field.Name} = reader.{field.Name};");
                }
            }

            sb.AppendLine("    }");
            sb.AppendLine();
        }

        private static bool IsStructField(FieldMeta field, List<StructMeta> structs)
        {
            // With the new extractor, structs contains only real structs (no unions)
            return structs.FirstOrDefault(s => s.Name == field.Type) != null;
        }
    
}
