using System.Text;

namespace SchemaX_CodeGen.CodeGen
{
    public static class DtoEmitter
    {
        public static string EmitDto(StructMeta meta)
        {
            var sb = new StringBuilder();
            sb.AppendLine();

            int sizeBytes = Math.Max((meta.DataWords + meta.PointerWords) * 8, 64);
            sizeBytes = ((sizeBytes + 63) / 64) * 64; // round up to nearest cache line

            sb.AppendLine($"[StructLayout(LayoutKind.Sequential, Pack = 1, Size = {sizeBytes})]");
            sb.AppendLine($"public struct {meta.Name}Dto");
            sb.AppendLine("{");

            foreach (var field in meta.Fields)
            {
                sb.AppendLine($"    public {field.Type} {field.Name};");
            }

            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}