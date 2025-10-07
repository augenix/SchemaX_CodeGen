using System.Runtime.CompilerServices;

namespace SchemaX_CodeGen;

public unsafe struct ArenaMeta
{
    private const int MaxSegments = 12;
    private const int HeaderWords = 9; // 1 header, 6 segment table, 1 root struct, 1 tag
    private fixed int offsets[MaxSegments];
    private fixed int wordCounts[MaxSegments];

    public ArenaMeta(int size)
    {
        ArenaSize = size - HeaderWords;
        SetOffset(0, 0);
        SetOffset(1, ArenaSize);
        SegmentCount = 1;
        SegmentCountLimit = MaxSegments;
    }

    public int ArenaSize { get; }
    public int ReservedWords => HeaderWords;
    public int SegmentCountLimit {get; }
    public int TotalWords { get; set; }
    public int SegmentCount { get; set; }
    public int PrepopulateWords { get; set; }
    public bool Prepopulate { get; set; }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public int GetOffset(int segmentIndex)
    {
        return offsets[segmentIndex];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void SetOffset(int segmentIndex, int value)
    {
        offsets[segmentIndex] = value + HeaderWords;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public int GetWordCount(int segmentIndex)
    {
        return wordCounts[segmentIndex];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void SetWordCount(int segmentIndex, int value)
    {
        wordCounts[segmentIndex] = value ;
        if (Prepopulate) TotalWords = value ;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public int IncrementWordCount(int segmentIndex, int delta)
    {
        wordCounts[segmentIndex] += delta;
        TotalWords += delta;
        if (Prepopulate) PrepopulateWords += delta;
        if (TotalWords >= ArenaSize + HeaderWords)
            throw new InvalidOperationException("Segment word count exceeds arena size");
        return wordCounts[segmentIndex];
    }
}