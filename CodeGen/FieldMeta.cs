namespace SchemaX_CodeGen.CodeGen
{
    public class FieldMeta
    {
        public string Name { get; set; } = string.Empty;
        public string TypeRaw { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int? BitOffset { get; set; }
        public int? PointerIndex { get; set; }
        public bool IsPointerStruct { get; set; } = false;

        public bool IsString => Type == "string";
        public bool IsTextList => Type == "TextList";
        public bool IsPrimitiveList => Type.StartsWith("PrimitiveList<");
        public bool IsStructList => Type.StartsWith("StructList<");

        public string InnerStructName =>
            IsStructList ? Type.Substring("StructList<".Length).TrimEnd('>') : null;

        public string InnerPrimitiveName =>
            IsPrimitiveList ? Type.Substring("PrimitiveList<".Length).TrimEnd('>') : null;
    }

}