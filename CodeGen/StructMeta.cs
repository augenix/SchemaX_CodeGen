using System.Diagnostics;

namespace SchemaX_CodeGen.CodeGen;

public class StructMeta
{
    public string Name { get; set; } = string.Empty;
    public int DataWords { get; set; }
    public int PointerWords { get; set; } = -1;
    public int UnionTag { get; set; }
    public List<FieldMeta> Fields { get; init; } = new();
    public bool RequiresRefStruct { get; set; }
    public HashSet<string> UsedEnums { get; set; } = new();
    public bool IsChildStruct { get; set; }
    public bool IsRequest { get; set; }
    public bool IsResponse { get; set; }
    public bool IsStream { get; set; }
    public bool IsControl  { get; set; }
    public bool IsMisc { get; set; }
    
}
