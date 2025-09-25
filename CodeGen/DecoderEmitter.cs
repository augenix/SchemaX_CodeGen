using System.Text;

namespace SchemaX_CodeGen.CodeGen
{
    public static class DecoderEmitter
    {
        public static string EmitDecoder(StructMeta meta)
        {
            var sb = new StringBuilder();
            sb.AppendLine("// Auto-generated decoder");
            sb.AppendLine($"public static class {meta.Name}Decoder");
            sb.AppendLine("{");

            sb.AppendLine($"    public static {meta.Name}Dto FromRefStruct(in {meta.Name} input)");
            sb.AppendLine("    {");
            sb.AppendLine($"        return new {meta.Name}Dto");
            sb.AppendLine("        {");

            foreach (var field in meta.Fields)
            {
                var name = field.Name;
                var type = field.Type;
                
                if (field.PointerIndex.HasValue)
                {
                    if (type == "string")
                        sb.AppendLine($"            {name} = PointerHelpers.ReadText(ref input.GetBuffer(), {field.PointerIndex}),");
                    else if (type == "TextList")
                        sb.AppendLine($"            {name} = PointerHelpers.ReadList_Text(ref input.GetBuffer(), {field.PointerIndex}),");
                    else if (type.StartsWith("PrimitiveList<"))
                        sb.AppendLine($"            {name} = PointerHelpers.ReadList_Primitive<{type.Substring(15, type.Length - 16)}>(ref input.GetBuffer(), {field.PointerIndex}),");
                    else if (type.StartsWith("StructList<"))
                        sb.AppendLine($"            {name} = PointerHelpers.ReadList_Struct<{type.Substring(12, type.Length - 13)}>(ref input.GetBuffer(), {field.PointerIndex}),");
                    else
                        sb.AppendLine($"            {name} = PointerHelpers.ReadStruct<{type}>(ref input.GetBuffer(), {field.PointerIndex}),");
                }
                else
                {
                    sb.AppendLine($"            {name} = input.{name},");
                }
            }

            sb.AppendLine("        };");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
