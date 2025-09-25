namespace SchemaX_CodeGen.CodeGen;

public class EnumMeta
{
    public string Name { get; set; } = string.Empty;
    public string UnderlyingType { get; set; } = "ushort";
    public List<EnumMemberMeta> Members { get; set; } = new();
}

public class EnumMemberMeta
{
    public string Name { get; set; } = string.Empty;
    public string? Value { get; set; } = null;
}