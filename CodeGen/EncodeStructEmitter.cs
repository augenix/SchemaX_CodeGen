
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

            // ---- Pointer fields ----
            if (field.PointerIndex is int slot)
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
            if (field.BitOffset is int bitOffset)
            {
                int word = bitOffset / 64;
                int bit = bitOffset % 64;
                
                if (type == "bool")
                {
                    sb.AppendLine($"    public bool {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => ((buffer[{word}] >> {bit}) & 1UL) != 0;");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        set => buffer[{word}] = (buffer[{word}] & ~(1UL << {bit})) | (value ? 1UL << {bit} : 0UL);");
                    sb.AppendLine("    }");
                }
                else if (type == "byte")
                {
                    sb.AppendLine($"    public byte {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => (byte)((buffer[{word}] >> {bit}) & 0xFF);");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        set => buffer[{word}] = (buffer[{word}] & ~(0xFF << {bit})) | ((ulong)value << {bit});");
                    sb.AppendLine("    }");
                }

                else if (type == "ushort")
                {
                    sb.AppendLine($"    public ushort {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => (ushort)((buffer[{word}] >> {bit}) & 0xFFFF);");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        set => buffer[{word}] = (buffer[{word}] & ~(0xFFFFFFFFUL << {bit})) | ((ulong)value << {bit});");
                    sb.AppendLine("    }");
                }
                else if (type == "uint")
                {
                    sb.AppendLine($"    public uint {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => (uint)((buffer[{word}] >> {bit}) & 0xFFFFFFFFUL);");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        set => buffer[{word}] = (buffer[{word}] & ~(0xFFFFFFFFUL << {bit})) | ((ulong)value << {bit});");
                    sb.AppendLine("    }");
                }
                else if (type == "int")
                {
                    sb.AppendLine($"    public int {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => (int)(buffer[{word}] >> {bit}) & 0xFFFF;");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        set => buffer[{word}] = (buffer[{word}] & ~(0xFFFFFFFFUL << {bit})) | ((ulong)(uint)value << {bit});");
                    sb.AppendLine("    }");
                }
                else if (type == "ulong")
                {
                    sb.AppendLine($"    public ulong {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => buffer[{word}];");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        set => buffer[{word}] = value;");
                    sb.AppendLine("    }");
                }
                else if (type == "long")
                {
                    sb.AppendLine($"    public long {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => (long)buffer[{word}];");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        set => buffer[{word}] = (ulong)value;");
                    sb.AppendLine("    }");
                }
                else if (type == "double")
                {
                    sb.AppendLine($"    public double {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        get => BitConverter.Int64BitsToDouble((long)buffer[{word}]);");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"        set => buffer[{word}] = (ulong)BitConverter.DoubleToInt64Bits(value);");
                    sb.AppendLine("    }");
                }
                else if (isEnum)
                {
                    sb.AppendLine($"    public {type} {name}");
                    sb.AppendLine("    {");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
                    sb.AppendLine($"        get => ({type})(ushort)((buffer[{word}] >> {bit}) & 0xFFFF);");
                    sb.AppendLine("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
                    sb.AppendLine($"        set => buffer[{word}] = (buffer[{word}] & ~(0xFFFFUL << {bit})) | ((ulong)(ushort)value << {bit});");
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
