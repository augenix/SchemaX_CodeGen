using System.Text;

namespace SchemaX_CodeGen.CodeGen;

public static class EnumEmitter
{
    public static string EmitEnum(EnumMeta meta)
    {
        var sb = new StringBuilder();
        
        sb.AppendLine($"public enum {meta.Name} : {meta.UnderlyingType}");
        sb.AppendLine("{");

        foreach (var member in meta.Members)
        {
            if (member.Value != null)
                sb.AppendLine($"    {member.Name} = {member.Value},");
            else
                sb.AppendLine($"    {member.Name},");
        }

        sb.AppendLine("}");
        return sb.ToString();
    }
}