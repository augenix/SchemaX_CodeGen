using System.Runtime.InteropServices;

namespace SchemaX_CodeGen;

public sealed class SegmentArena : IDisposable
{
    private readonly ulong[] buffer;
    private GCHandle handle;
    private ArenaMeta meta;
    
    public SegmentArena(int arenaSize = 8192)
    {
        buffer = new ulong[arenaSize];
        handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        meta = new(arenaSize);
        SegmentCount = meta.SegmentCount;
    }
    public ArenaMeta Meta => meta;
    public Span<ulong> GetArenaAsSpan => buffer.AsSpan();
    public Span<ulong> GetAllSegments => buffer.AsSpan(ReservedWords, TotalWords);
    public ulong[] Buffer => buffer;
    public int ReservedWords => meta.ReservedWords;
    public int GetWordCount(int segmentIndex) => meta.GetWordCount(segmentIndex);
    public void IncrementWordCount(int segmentIndex, int count) => meta.IncrementWordCount(segmentIndex, count);
    public int GetOffset(int segmentIndex) => meta.GetOffset(segmentIndex);
    public int TargetSegmentSize => 128;

    public bool Prepopulate
    {
        get => meta.Prepopulate; 
        set => meta.Prepopulate = value;
    }

    public void ResetWordCount()
    {
        meta.SetWordCount(0, meta.PrepopulateWords);
    }
    public int PrepopulateWords
    {
        get => meta.PrepopulateWords;
        set => meta.PrepopulateWords += value;
    }

    public int SegmentCount
    {
        get => meta.SegmentCount;
        private set => meta.SegmentCount = value;
    }

    public int SegmentCountLimit => meta.SegmentCountLimit;
    public int TotalWords => meta.TotalWords;
    public int ArenaSize => meta.ArenaSize;

    public Span<ulong> GetSegment(int segmentIndex)
    {
        if (segmentIndex < SegmentCount)
        {
            var start = GetOffset(segmentIndex);
            var length = GetOffset(segmentIndex + 1) - start;
            return buffer.AsSpan(start, length);
        }
        ArgumentOutOfRangeException.ThrowIfGreaterThan(segmentIndex, SegmentCount);
        return null;
    }

    public void AllocateSegment(int segmentIndex)
    {
        if (segmentIndex < SegmentCount) return;
        ArgumentOutOfRangeException.ThrowIfGreaterThan(segmentIndex, SegmentCount);
        meta.SetOffset(SegmentCount, TotalWords);
        meta.SetOffset(++SegmentCount, ArenaSize);
    }

    public Span<ulong> GetHeader() => buffer.AsSpan(0, meta.GetOffset(0));
    public Span<ulong> ArenaSpan => buffer.AsSpan(0, ArenaSize);

    public void Dispose()
    {
        if (handle.IsAllocated)
            handle.Free();
    }
}