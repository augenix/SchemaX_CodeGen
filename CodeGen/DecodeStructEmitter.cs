using System.Globalization;

namespace SchemaX_CodeGen.CodeGen;

public static class DecodeStructEmitter
{
    public static void EmitStructs(IndentedStringBuilder sb, StructMeta meta, List<StructMeta> structs)
    {
        //0. Initialize
        var structByName = structs.ToDictionary(kvp => kvp.Name);
        var childStructs = meta.Fields
            .Where(f => f.IsPointerStruct && !f.Type.StartsWith("StructList<"))
            .Select(f => f.Type)
            .Distinct();
        
        var structLists = meta.Fields
            .Where(f => f.Type.StartsWith("StructList<"))
            .Select(f => f.Type.Substring("StructList<".Length).TrimEnd('>'))
            .Distinct();
        
        static string Mask(ulong widthBits, int bit) =>
            bit == 0 ? $"~0x{widthBits:X}UL" : $"~(0x{widthBits:X}UL << {bit})";


        // 1. Header
        
            sb.AppendLine($"public ref struct {meta.Name}Decoder");
            sb.AppendLine("{");
            sb.AppendLine("    private readonly Span<ulong> frame;");
            sb.AppendLine("    private readonly SegmentMeta meta;");
            sb.AppendLine("    private readonly Span<ulong> buffer;");
            sb.AppendLine("    private readonly int offset;");
            sb.AppendLine("    private readonly int segmentIndex;");
            sb.AppendLine($"    private const int DataWords = {meta.DataWords};");
            sb.AppendLine($"    private const int PointerWords = {meta.PointerWords};");
            sb.AppendLine();
            sb.AppendLine($"    public {meta.Name}Decoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)");
            sb.AppendLine("    {");
            sb.AppendLine("        this.frame = frame;");
            sb.AppendLine("        this.meta = meta;");
            sb.AppendLine("        this.segmentIndex = segmentIndex;");
            sb.AppendLine("        offset = structIndex + DataWords;");
            sb.AppendLine("        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;");
            sb.AppendLine("        buffer = frame.Slice(structIndex, DataWords + PointerWords);");
            sb.AppendLine("    }");
            sb.AppendLine();
        
        
        // 2. Fields
        foreach (var field in meta.Fields)
        {
            var name = field.Name;
            var type = field.Type;
            var isEnum = meta.UsedEnums.Contains(type);
            bool isZeroDefault =
                field.DefaultValue == null ||
                (field.DefaultValue is IConvertible c && c.ToDouble(CultureInfo.InvariantCulture) == 0.0);


            // ---- Pointer fields ----
            if (field.PointerIndex is { } slot)
            {
                if (type == "string")
                {
                    sb.AppendLine($"    public string {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + {slot});");
                    sb.AppendLine("    }");
                }
                else if (type == "TextList")
                {
                    sb.AppendLine($"    public ReadOnlySpan<string> {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => DecodeHelpers.ReadList_Text(frame, meta, segmentIndex, offset + {slot});");
                    sb.AppendLine("    }");
                }
                else if (type.StartsWith("PrimitiveList<"))
                {
                    int start = type.IndexOf('<') + 1;
                    int length = type.IndexOf('>') - start;
                    string innerType = type.Substring(start, length);
                    sb.AppendLine($"    public ReadOnlySpan<{innerType}> {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => DecodeHelpers.ReadList_Primitive<{innerType}>(frame, meta, segmentIndex, offset + {slot});");
                    sb.AppendLine("    }");
                }
                else if (type.StartsWith("StructList<"))
                {
                    int start = type.IndexOf('<') + 1;
                    int length = type.IndexOf('>') - start;
                    string innerType = type.Substring(start, length);

                    sb.AppendLine($"    public {innerType}ListAccessor {name} => new {innerType}ListAccessor(frame, meta, segmentIndex, offset + {slot});");
                }
                else
                {
                    sb.AppendLine($"    public {type}StructAccessor {name} => new {type}StructAccessor(frame, meta, segmentIndex, offset + {slot});");
                }

                sb.AppendLine();
            }

            // ---- Data fields ----
            if (field.BitOffset is { } bitOffset)
            {
                int word = bitOffset / 64;
                int bit = bitOffset % 64;
                
                if (type == "bool")
                {
                    string maskClear = Mask(1, bit);
                    string read      = bit == 0 ? $"buffer[{word}]" : $"(buffer[{word}] >> {bit})";
                    string defBool   = isZeroDefault ? "" : "true"; // only non-zero default for bool is 'true'

                    // GET: ((buffer[..] >> bit) & 1UL) != 0  [with bit==0 suppression]  then XOR if default==true
                    string getCore = $"(({read} & 1UL) != 0)";
                    string getExpr = string.IsNullOrEmpty(defBool) ? getCore : $"{getCore} ^ {defBool}";
                    
                    sb.AppendLine($"    public bool {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => {getExpr};");
                    sb.AppendLine("    }");
                    
                }
                else if (type is "byte" or "ushort")
                {
                    int widthBits = type == "byte" ? 8 : 16;
                    string maskClear = Mask((ulong)((1 << widthBits) - 1), bit);
                    string defExpr = isZeroDefault ? "" : Convert.ToUInt64(field.DefaultValue).ToString(CultureInfo.InvariantCulture);

                    // --- Getter ---
                    // Ensure the mask is *inside* the cast and suppress >> 0
                    string getCore = bit == 0
                        ? $"buffer[{word}] & 0x{((1 << widthBits) - 1):X}UL"
                        : $"(buffer[{word}] >> {bit} & 0x{((1 << widthBits) - 1):X}UL)";

                    string getExpr = isZeroDefault
                        ? $"({type})({getCore})"
                        : $"({type})(({getCore}) ^ {defExpr}UL)";
                    
                    // --- Emit ---
                    sb.AppendLine($"    public {type} {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => {getExpr};");
                    sb.AppendLine("    }");
                }
                else if (type is "int" or "uint")
                {
                    bool isSigned = type == "int";
                    string maskClear = Mask(0xFFFFFFFF, bit);
                    string defExpr = isZeroDefault ? "" : Convert.ToUInt32(field.DefaultValue).ToString(CultureInfo.InvariantCulture);

                    // getter core (no >>0, mask inside cast)
                    string getCore = bit == 0
                        ? $"buffer[{word}] & 0xFFFFFFFFUL"
                        : $"(buffer[{word}] >> {bit} & 0xFFFFFFFFUL)";

                    string getExpr = isZeroDefault
                        ? isSigned
                            ? $"(int)({getCore})"
                            : $"(uint)({getCore})"
                        : isSigned
                            ? $"(int)(({getCore}) ^ {defExpr}U)"
                            : $"(uint)(({getCore}) ^ {defExpr}U)";

                    sb.AppendLine($"    public {type} {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => {getExpr};");
                    sb.AppendLine("    }");
                }
                else if (type == "ulong")
                {
                    sb.AppendLine($"    public ulong {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine(isZeroDefault
                        ? $"        get => buffer[{word}];"
                        : $"        get => buffer[{word}] ^ {field.DefaultValue};");
                    sb.AppendLine("    }");
                }
                else if (type is "long" or "ulong")
                {
                    bool isSigned = type == "long";
                    string defExpr = isZeroDefault
                        ? ""
                        : isSigned
                            ? $"{Convert.ToInt64(field.DefaultValue)}L"
                            : $"{Convert.ToUInt64(field.DefaultValue)}UL";

                    string getExpr;

                    if (isSigned)
                    {
                        // signed: cast buffer to long before XOR
                        getExpr = isZeroDefault
                            ? $"(long)buffer[{word}]"
                            : $"(long)buffer[{word}] ^ {defExpr}";
                    }
                    else
                    {
                        // unsigned: operate directly in ulong domain
                        getExpr = isZeroDefault
                            ? $"(ulong)buffer[{word}]"
                            : $"buffer[{word}] ^ {defExpr}";
                    }

                    sb.AppendLine($"    public {type} {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => {getExpr};");
                    sb.AppendLine("    }");
                }
                 else if (type is "float" or "double")
                {
                    bool isFloat = type == "float";
                    string defExpr = isZeroDefault
                        ? ""
                        : isFloat
                            ? $"{Convert.ToSingle(field.DefaultValue, CultureInfo.InvariantCulture)}f"
                            : $"{Convert.ToDouble(field.DefaultValue, CultureInfo.InvariantCulture)}";

                    // --- Getter ---
                    string readBits = isFloat
                        ? $"(uint)(buffer[{word}] & 0xFFFFFFFFUL)"
                        : $"buffer[{word}]";

                    string getBits = isZeroDefault
                        ? readBits
                        : isFloat
                            ? $"{readBits} ^ (uint)BitConverter.SingleToInt32Bits({defExpr})"
                            : $"{readBits} ^ (ulong)BitConverter.DoubleToInt64Bits({defExpr})";

                    string getExpr = isFloat
                        ? $"BitConverter.Int32BitsToSingle((int){getBits})"
                        : $"BitConverter.Int64BitsToDouble((long){getBits})";
                    

                    // --- Emit ---
                    sb.AppendLine($"    public {type} {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => {getExpr};");
                    sb.AppendLine("    }");
                }
                
                 else if (isEnum)
                 {
                     string maskClear = Mask(0xFFFF, bit);
                     string defExpr = isZeroDefault ? "" : $"{Convert.ToUInt64(field.DefaultValue)}UL";

                     // --- Getter ---
                     string getBits = bit == 0
                         ? $"buffer[{word}] & 0xFFFFUL"
                         : $"(buffer[{word}] >> {bit} & 0xFFFFUL)";
                     string getExpr = isZeroDefault
                         ? $"({type})(ushort)({getBits})"
                         : $"({type})(ushort)(({getBits}) ^ {defExpr})";

                     sb.AppendLine($"    public {type} {name}");
                     sb.AppendLine("    {");
                     sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                     sb.AppendLine($"        get => {getExpr};");
                     sb.AppendLine("    }");
                 }
                else
                {
                    sb.AppendLine($"    // Unhandled field type: {type} at bit {bitOffset}");
                }

                sb.AppendLine();
            }
        }

        foreach (var child in childStructs)
        {
            if (!structByName.TryGetValue(child, out var childMeta))
                throw new InvalidOperationException($"StructEmitter: Could not resolve child struct: {child}");

            string accessorName = $"{child}StructAccessor";
            sb.AppendLine();
            sb.AppendLine($"    public ref struct {accessorName}");
            sb.AppendLine("    {");
            sb.AppendLine("        private readonly Span<ulong> frame;");
            sb.AppendLine("        private readonly SegmentMeta meta;");
            sb.AppendLine("        private readonly int pointerIndex;");
            sb.AppendLine("        private readonly int segmentIndex;");
            sb.AppendLine();
            sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
            sb.AppendLine($"        public {accessorName}(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)");
            sb.AppendLine("        {");
            sb.AppendLine("            this.frame = frame;");
            sb.AppendLine("            this.meta = meta;");
            sb.AppendLine("            this.pointerIndex = pointerIndex;");
            sb.AppendLine("            this.segmentIndex = segmentIndex;");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
            sb.AppendLine($"        public {child}Decoder Reader()");
            sb.AppendLine("        {");
            sb.AppendLine($"            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);");
            sb.AppendLine($"            return new {child}Decoder(frame, meta, cursor.segmentIndex, cursor.structIndex);");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
        }

        foreach (var child in structLists)
        {
            if (!structByName.TryGetValue(child, out var childMeta))
                throw new InvalidOperationException($"StructEmitter: Could not resolve child struct: {child}");

            string accessorName = $"{child}ListAccessor";

            sb.AppendLine();
            sb.AppendLine($"    public ref struct {accessorName}");
            sb.AppendLine("    {");
            sb.AppendLine("        private readonly Span<ulong> frame;");
            sb.AppendLine("        private readonly SegmentMeta meta;");
            sb.AppendLine("        private readonly int pointerIndex;");
            sb.AppendLine("        private readonly int segmentIndex;");
            sb.AppendLine();
            sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
            sb.AppendLine($"        public {accessorName}(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)");
            sb.AppendLine("        {");
            sb.AppendLine("            this.frame = frame;");
            sb.AppendLine("            this.meta = meta;");
            sb.AppendLine("            this.pointerIndex = pointerIndex;");
            sb.AppendLine("            this.segmentIndex = segmentIndex;");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
            sb.AppendLine($"        public {child}Decoder GetElement(int index)");
            sb.AppendLine("        {");
            sb.AppendLine($"            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);");
            sb.AppendLine($"            var elementCursor = DecodeHelpers.GetListElementCursor(frame, meta, cursor.segmentIndex, cursor.structIndex, index);");
            sb.AppendLine($"            return new {child}Decoder(frame, meta, elementCursor.segmentIndex, elementCursor.elementIndex);");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        public int Count");
            sb.AppendLine("        {");
            sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);");
            sb.AppendLine("                return DecodeHelpers.GetListLength(frame, meta, cursor.segmentIndex, cursor.structIndex);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
        }

        sb.AppendLine("}");
    }
}
