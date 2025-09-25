namespace SchemaX_CodeGen.Tests;

public static class FrameInspector
{
    public static void DumpSegments(SegmentArena arena)
    {
        int segmentCount = arena.SegmentCount;
        
        for (int segIndex = 0; segIndex < segmentCount; segIndex++)
        {
            Console.WriteLine($"--- Segment {segIndex} ---");

            Span<ulong> seg = arena.GetSegment(segIndex);
            int wordCount = arena.GetWordCount(segIndex);
            Console.WriteLine($"Segment Length: {wordCount}");

            for (int i = 0; i < wordCount; i++)
            {
                ulong word = seg[i];
                Console.WriteLine($"[{i:D3}] 0x{word:X16}");
            }

            Console.WriteLine();
        }
    }

    public static void DumpFrame(Span<ulong> frame)
    {
        int wordCount = frame.Length;
        Console.WriteLine($"Segment Length: {wordCount}");

        for (int i = 0; i < wordCount; i++)
        {
            ulong word = frame[i];
            Console.WriteLine($"[{i:D3}] 0x{word:X16}");
        }

        Console.WriteLine();
    }
}