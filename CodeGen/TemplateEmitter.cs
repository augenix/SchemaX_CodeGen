using System.Text;

namespace SchemaX_CodeGen.CodeGen
{
    public static class TemplateEmitter
    {
        public static void EmitTemplates(List<StructMeta> structs, string outputDir)
        {
            var sb = new IndentedStringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Net.Sockets;");
            sb.AppendLine("using System.Runtime.InteropServices;");
            sb.AppendLine("using System.Runtime.CompilerServices;");
            sb.AppendLine("using SchemaX_CodeGen.Queues;");
            sb.AppendLine();
            sb.AppendLine($"namespace SchemaX_CodeGen.Generated.{EmitterRunner.ProjectName};");
            sb.AppendLine();
            
            foreach (var meta in structs)
            {
                if (true )
                {
                    var name = meta.Name;
                    var templateName = name + "Template";

                    sb.AppendLine($"public sealed class {templateName}");
                    sb.AppendLine("{");
                    sb.AppendLine("    private readonly SegmentArena arena;");
                    sb.AppendLine();
                    sb.AppendLine("    private const ulong Root = 0x0001000100000000UL;");
                    sb.AppendLine($"    private const int UnionTag = {meta.UnionTag};");
                    sb.AppendLine($"    private const int DataWords = {meta.DataWords};");
                    sb.AppendLine($"    private const int PointerWords = {meta.PointerWords};");
                    sb.AppendLine($"    private const int BaseSegment = 0;");
                    sb.AppendLine($"    private const int BaseIndex = 1;");
                    sb.AppendLine();

                    // Constructor
                    sb.AppendLine($"    public {templateName}()");
                    sb.AppendLine("    {");
                    sb.AppendLine("        arena = new SegmentArena();"); 
                    sb.AppendLine("        arena.IncrementWordCount(0, 1);");
                    sb.AppendLine("        arena.PrepopulateWords = DataWords + PointerWords + 1;");
                    sb.AppendLine("        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);");
                    sb.AppendLine("    }");
                    sb.AppendLine();
                    // Prepopulate method
                   
                    sb.AppendLine("    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"    public {name}Encoder Prepopulate()");
                    sb.AppendLine("    {");
                    sb.AppendLine("        arena.Prepopulate = true;");
                    sb.AppendLine($"        return new {name}Encoder(arena, BaseSegment, BaseIndex);");
                    sb.AppendLine("    }");
                    sb.AppendLine();
                    
                    // Populate method
                    sb.AppendLine("    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine($"    public {name}Encoder Populate()");
                    sb.AppendLine("    {");
                    sb.AppendLine("        arena.Prepopulate = false;");
                    sb.AppendLine("        if (arena.GetWordCount(0) > arena.PrepopulateWords) arena.ResetWordCount();");
                    sb.AppendLine($"        return new {name}Encoder(arena, BaseSegment, BaseIndex);");
                    sb.AppendLine("    }");
                    sb.AppendLine();
                    
                    // Get arena and meta data for testing purposes.

                    sb.AppendLine($"    public ArenaMeta Meta => arena.Meta;");
                    sb.AppendLine();
                    sb.AppendLine($"    public Span<ulong> GetArenaAsSpan => arena.GetArenaAsSpan;");
                    sb.AppendLine();
                    // Build Send Frame method
                    sb.Indent();
                    sb.AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine("public unsafe SendFrame BuildSendFrame()");
                    sb.AppendLine("{");
                    sb.Indent();
                    sb.AppendLine("var buf  = arena.Buffer;");
                    sb.AppendLine("int segCount = arena.SegmentCount;");
                    sb.AppendLine();
                    sb.AppendLine("int headerWords = 3 + ((segCount - 1 + 1) / 2);    // 3 for 1 segment");
                    sb.AppendLine("int startWord   = arena.ReservedWords - headerWords;");
                    sb.AppendLine();
                    sb.AppendLine("arena.IncrementWordCount(0, 2);");
                    sb.AppendLine();
                    sb.AppendLine("buf[startWord] =");
                    sb.AppendLine("    ((ulong)arena.GetWordCount(0) << 32) |");
                    sb.AppendLine("    (uint)(segCount - 1);");
                    sb.AppendLine();
                    sb.AppendLine("int w = startWord + 1;");
                    sb.AppendLine();
                    sb.AppendLine("for (int i = 1; i < segCount; i += 2)");
                    sb.AppendLine("{");
                    sb.Indent();
                    sb.AppendLine("buf[w++] = (ulong)arena.GetWordCount(i + 1) << 32 | (uint) arena.GetWordCount(i);");
                    sb.Unindent();
                    sb.AppendLine("}");
                    sb.AppendLine();
                    sb.AppendLine("buf[w++] = Root;");
                    sb.AppendLine("buf[w]   = UnionTag;");
                    sb.AppendLine("arena.IncrementWordCount(0,1);");
                    sb.AppendLine();
                    sb.AppendLine("var frame = new SendFrame");
                    sb.AppendLine("{");
                    sb.Indent();
                    sb.AppendLine("BasePtr           = arena.BasePtr,");
                    sb.AppendLine("SegmentCount      = (byte)segCount,");
                    sb.AppendLine("Segment0StartWord = startWord");
                    sb.Unindent();
                    sb.AppendLine("};");
                    sb.AppendLine();
                    sb.AppendLine("for (int i = 0; i < segCount; i++)");
                    sb.AppendLine("{");
                    sb.Indent();
                    sb.AppendLine("frame.Offsets[i]    = arena.GetOffset(i);");
                    sb.AppendLine("frame.WordCounts[i] = arena.GetWordCount(i);");
                    sb.Unindent();
                    sb.AppendLine("}");
                    sb.AppendLine();
                    sb.AppendLine("return frame;");
                    sb.Unindent();
                    sb.AppendLine("}");
                    
                    //Send method
                    sb.AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]");
                    sb.AppendLine("public void Send(Socket socket)");
                    sb.AppendLine("{");
                    sb.Indent();
                    sb.AppendLine("var buf = arena.Buffer;");
                    sb.AppendLine("var segCount = arena.SegmentCount;");
                    sb.AppendLine("var headerWords = 3 + (segCount - 1 + 1) / 2;");
                    sb.AppendLine("var start = arena.ReservedWords - headerWords;");
                    sb.AppendLine("arena.IncrementWordCount(0, 2);");
                    sb.AppendLine("buf[start] = ((ulong)(arena.GetWordCount(0)) << 32) | (uint)(segCount - 1);");
                    sb.AppendLine();
                    sb.AppendLine("var w = start + 1;");
                    sb.AppendLine("for (int i = 1; i < segCount; i += 2)");
                    sb.AppendLine("    buf[w++] = (ulong)arena.GetWordCount(i + 1) << 32 | (uint) arena.GetWordCount(i);");
                    sb.AppendLine("buf[w++] = Root;");
                    sb.AppendLine("buf[w] = UnionTag;");
                    sb.AppendLine();
                    sb.AppendLine("int seg0Words = arena.GetWordCount(0);");
                    sb.AppendLine("int totalSeg0Words = 1 + seg0Words;");
                    sb.AppendLine("ReadOnlySpan<byte> seg0Bytes = MemoryMarshal.AsBytes(arena.GetArenaAsSpan.Slice(start, totalSeg0Words));");
                    sb.AppendLine("int sent = 0;");
                    sb.AppendLine("while (sent < seg0Bytes.Length)");
                    sb.AppendLine("    sent += socket.Send(seg0Bytes.Slice(sent));");
                    sb.AppendLine("for (int i = 1; i < segCount; i++)");
                    sb.AppendLine("{");
                    sb.Indent();
                    sb.AppendLine("int sent2 = 0;");
                    sb.AppendLine("int words = arena.GetWordCount(i);");
                    sb.AppendLine("if (words == 0) continue;");
                    sb.AppendLine("ReadOnlySpan<byte> segBytes = MemoryMarshal.AsBytes(arena.GetSegment(i).Slice(0, words));");
                    sb.AppendLine("while (sent2 < segBytes.Length)");
                    sb.AppendLine("    sent2 += socket.Send(segBytes.Slice(sent2));");
                    sb.Unindent();
                    sb.AppendLine("}");
                    sb.Unindent();
                    sb.AppendLine("}");
                    sb.Unindent();
                    sb.AppendLine("}");
                }
            }

            var filePath = Path.Combine(outputDir, "RequestTemplates.cs");
            File.WriteAllText(filePath, sb.ToString());
        }
    }
}
