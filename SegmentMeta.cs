
namespace SchemaX_CodeGen;

public unsafe struct SegmentMeta
{
    
    private const int MaxSegments = 12;
    private fixed int wordCounts[MaxSegments];
    
    public int SegmentCount { get; set; }
    public int TotalWords { get; set; }

    public void SetWordCount(int index, int value)
    {
        wordCounts[index] = value;
    }

    public int GetWordCount(int index)
    {
        return wordCounts[index];
    }
    public int Tag { get; set; }
}
