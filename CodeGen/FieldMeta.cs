namespace SchemaX_CodeGen.CodeGen
{
    public class FieldMeta
    {
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Fully qualified type name as it appeared in source, before normalization.
        /// </summary>
        public string TypeRaw { get; set; } = string.Empty;

        /// <summary>
        /// Normalized type name (e.g. CapnpGen.Foo.WRITER → Foo).
        /// </summary>
        public string Type { get; set; } = string.Empty;

        public int? BitOffset { get; set; }
        public int? PointerIndex { get; set; }

        /// <summary>
        /// True if this field is a pointer to a struct (used to identify embedded structs).
        /// </summary>
        public bool IsPointerStruct { get; set; } = false;
    }
}