
using System.Globalization;

namespace SchemaX_CodeGen.CodeGen;
public static class EncodeStructEmitter
{
    public static void EmitStructs(IndentedStringBuilder sb, StructMeta meta, List<StructMeta> structs)
    {
        //0. Initialize
        var structByName = structs.ToDictionary(kvp => kvp.Name);
        var childStructs = meta.Fields
            .Where(f => f.IsPointerStruct && !f.Type.StartsWith("StructList<"))
            .Select(f => f.Type)
            .Distinct();
        var allChildStructs = structs
            .SelectMany(s => s.Fields)
            .Where(f => f.IsPointerStruct && !f.Type.StartsWith("StructList<"))
            .Select(f => f.Type)
            .ToHashSet();
        var structLists = meta.Fields
            .Where(f => f.Type.StartsWith("StructList<"))
            .Select(f => f.Type.Substring("StructList<".Length).TrimEnd('>'))
            .Distinct();
        
        static string Mask(ulong widthBits, int bit) =>
            bit == 0 ? $"~0x{widthBits:X}UL" : $"~(0x{widthBits:X}UL << {bit})";

        static string Shift(string expr, int bit, bool left)
            => bit == 0 ? expr : $"({expr} {(left ? "<<" : ">>")} {bit})";

        static string Xor(string expr, string? defExpr)
            => string.IsNullOrEmpty(defExpr) ? expr : $"{expr} ^ {defExpr}";
        
        static string ReadBits(string bufferExpr, int bit)
            => bit == 0 ? bufferExpr : $"({bufferExpr} >> {bit})";


        
        // 1. Header
        
            sb.AppendLine($"public ref struct {meta.Name}Encoder");
            sb.AppendLine("{");
            sb.AppendLine("    private readonly SegmentArena arena;");
            sb.AppendLine("    private readonly Span<ulong> buffer;");
            sb.AppendLine("    private readonly int offset;");
            sb.AppendLine("    private readonly int segmentIndex;");
            sb.AppendLine($"    private const int DataWords = {meta.DataWords};");
            sb.AppendLine($"    private const int PointerWords = {meta.PointerWords};");
            sb.AppendLine();
            sb.AppendLine($"    public {meta.Name}Encoder(SegmentArena arena, int segmentIndex, int structIndex)");
            sb.AppendLine("    {");
            sb.AppendLine("        this.arena = arena;");
            sb.AppendLine("        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);");
            sb.AppendLine("        offset = structIndex + DataWords;");
            sb.AppendLine("        this.segmentIndex = segmentIndex;");
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
                    sb.AppendLine($"        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + {slot});");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + {slot}, value);");
                    sb.AppendLine("    }");
                }
                else if (type == "TextList")
                {
                    sb.AppendLine($"    public ReadOnlySpan<string> {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => EncodeHelpers.ReadList_Text(arena, segmentIndex, offset + {slot});");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        set => EncodeHelpers.WriteList_Text(arena, segmentIndex, offset + {slot}, value);");
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
                    sb.AppendLine($"        get => EncodeHelpers.ReadList_Primitive<{innerType}>(arena, segmentIndex, offset + {slot});");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine(
                        $"        set => EncodeHelpers.WriteList_Primitive<{innerType}>(arena, segmentIndex, offset + {slot}, value);");
                    sb.AppendLine("    }");
                }
                else if (type.StartsWith("StructList<"))
                {
                    int start = type.IndexOf('<') + 1;
                    int length = type.IndexOf('>') - start;
                    string innerType = type.Substring(start, length);

                    sb.AppendLine($"    public {innerType}ListAccessor {name} => new {innerType}ListAccessor(arena, segmentIndex, offset + {slot});");
                }
                else
                {
                    sb.AppendLine($"    public {type}StructAccessor {name} => new {type}StructAccessor(arena, segmentIndex, offset + {slot});");
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

                    // SET: value (or value ^ true if default==true) -> 1UL/0UL -> shift if needed -> merge
                    string vBool   = string.IsNullOrEmpty(defBool) ? "value" : "(value ^ true)";
                    string vBit    = $"({vBool} ? 1UL : 0UL)";
                    string vShift  = bit == 0 ? vBit : $"({vBit} << {bit})";
                    string setExpr = $"buffer[{word}] = (buffer[{word}] & {maskClear}) | {vShift}";

                    sb.AppendLine($"    public bool {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => {getExpr};");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        set => {setExpr};");
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

                    // --- Setter ---
                    // Widen the value to uint to avoid type mismatch with ulong
                    string valueExpr = isZeroDefault
                        ? "(uint)value"
                        : $"(uint)(value ^ {defExpr})";

                    string shifted = bit == 0
                        ? valueExpr
                        : $"({valueExpr} << {bit})";

                    string setExpr = $"buffer[{word}] = (buffer[{word}] & {maskClear}) | {shifted}";

                    // --- Emit ---
                    sb.AppendLine($"    public {type} {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => {getExpr};");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        set => {setExpr};");
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

                    // setter: cast signed to uint before OR with ulong
                    string valueExpr = isSigned
                        ? "(uint)value"
                        : "value";

                    if (!isZeroDefault)
                        valueExpr = $"((ulong)({valueExpr} ^ {defExpr}U))";
                    else
                        valueExpr = $"(ulong){valueExpr}";

                    string shifted = bit == 0
                        ? valueExpr
                        : $"({valueExpr} << {bit})";

                    string setExpr = $"buffer[{word}] = (buffer[{word}] & {maskClear}) | {shifted}";

                    sb.AppendLine($"    public {type} {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => {getExpr};");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        set => {setExpr};");
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
                    string setExpr;

                    if (isSigned)
                    {
                        // signed: cast buffer to long before XOR
                        getExpr = isZeroDefault
                            ? $"(long)buffer[{word}]"
                            : $"(long)buffer[{word}] ^ {defExpr}";
                        setExpr = isZeroDefault
                            ? $"buffer[{word}] = (ulong)value"
                            : $"buffer[{word}] = (ulong)(value ^ {defExpr})";
                    }
                    else
                    {
                        // unsigned: operate directly in ulong domain
                        getExpr = isZeroDefault
                            ? $"(ulong)buffer[{word}]"
                            : $"buffer[{word}] ^ {defExpr}";
                        setExpr = isZeroDefault
                            ? $"buffer[{word}] = value"
                            : $"buffer[{word}] = value ^ {defExpr}";
                    }

                    sb.AppendLine($"    public {type} {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => {getExpr};");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        set => {setExpr};");
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

                    // --- Setter ---
                    string valueBits = isFloat
                        ? $"(ulong)BitConverter.SingleToInt32Bits(value)"
                        : $"(ulong)BitConverter.DoubleToInt64Bits(value)";

                    if (!isZeroDefault)
                        valueBits = isFloat
                            ? $"{valueBits} ^ (uint)BitConverter.SingleToInt32Bits({defExpr})"
                            : $"{valueBits} ^ (ulong)BitConverter.DoubleToInt64Bits({defExpr})";

                    string setExpr = $"buffer[{word}] = {valueBits}";

                    // --- Emit ---
                    sb.AppendLine($"    public {type} {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => {getExpr};");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        set => {setExpr};");
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

                    // --- Setter ---
                    string valueBits = isZeroDefault
                        ? "(ushort)value"
                        : $"((ushort)value ^ {defExpr})";

                    // force unsigned widening before OR
                    string setExpr = bit == 0
                        ? $"buffer[{word}] = (buffer[{word}] & {maskClear}) | (ulong){valueBits}"
                        : $"buffer[{word}] = (buffer[{word}] & {maskClear}) | ((ulong){valueBits} << {bit})";

                    sb.AppendLine($"    public {type} {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => {getExpr};");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        set => {setExpr};");
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
            sb.AppendLine("        private readonly SegmentArena arena;");
            sb.AppendLine("        private readonly int pointerIndex;");
            sb.AppendLine("        private readonly int segmentIndex;");
            sb.AppendLine();
            sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
            sb.AppendLine($"        public {accessorName}(SegmentArena arena, int segmentIndex, int pointerIndex)");
            sb.AppendLine("        {");
            sb.AppendLine("            this.arena = arena;");
            sb.AppendLine("            this.pointerIndex = pointerIndex;");
            sb.AppendLine("            this.segmentIndex = segmentIndex;");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
            sb.AppendLine($"        public {child}Encoder Writer()");
            sb.AppendLine("        {");
            sb.AppendLine($"            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, {childMeta.DataWords}, {childMeta.PointerWords});");
            sb.AppendLine($"            return new {child}Encoder(arena, cursor.segmentIndex, cursor.structIndex);");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
            sb.AppendLine($"        public {child}Encoder Reader()");
            sb.AppendLine("        {");
            sb.AppendLine($"            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);");
            sb.AppendLine($"            return new {child}Encoder(arena, cursor.segmentIndex, cursor.structIndex);");
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
            sb.AppendLine("        private readonly SegmentArena arena;");
            sb.AppendLine("        private readonly int pointerIndex;");
            sb.AppendLine("        private readonly int segmentIndex;");
            sb.AppendLine();
            sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
            sb.AppendLine($"        public {accessorName}(SegmentArena arena, int segmentIndex, int pointerIndex)");
            sb.AppendLine("        {");
            sb.AppendLine("            this.arena = arena;");
            sb.AppendLine("            this.pointerIndex = pointerIndex;");
            sb.AppendLine("            this.segmentIndex = segmentIndex;");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
            sb.AppendLine("        public void Init(int count)");
            sb.AppendLine("        {");
            sb.AppendLine($"            EncodeHelpers.AllocateList_Struct(arena, segmentIndex, pointerIndex, count, {childMeta.DataWords}, {childMeta.PointerWords});");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
            sb.AppendLine($"        public {child}Encoder GetElement(int index)");
            sb.AppendLine("        {");
            sb.AppendLine($"            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);");
            sb.AppendLine($"            var elementCursor = EncodeHelpers.GetListElementCursor(arena, cursor.segmentIndex, cursor.structIndex, index);");
            sb.AppendLine($"            return new {child}Encoder(arena, elementCursor.segmentIndex, elementCursor.elementIndex);");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
        }

        sb.AppendLine("}");
    }
}
