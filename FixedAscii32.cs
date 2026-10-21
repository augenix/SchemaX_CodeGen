using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace SchemaX_CodeGen;

// 31 ASCII chars + NUL terminator. Zero allocations except ToString().
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct FixedAscii32
{
    public const int MaxLength = 31;

    public fixed byte Buffer[32];

    public readonly int Length
    {
        get
        {
            int n = 0;
            while (n < MaxLength && Buffer[n] != 0) n++;
            return n;
        }
    }

    public readonly bool IsEmpty => Buffer[0] == 0;

    // Raw ASCII bytes. GC-tracked span into this struct; no allocation, no pinning.
    // Valid while the struct stays where it is (e.g. a ref into a queue slot).
    [UnscopedRef]
    public ReadOnlySpan<byte> AsSpan() =>
        MemoryMarshal.CreateReadOnlySpan(ref Buffer[0], Length);

    // Copy straight from encoded text bytes (decoder span). No allocation.
    public void Set(ReadOnlySpan<byte> src)
    {
        int len = Math.Min(src.Length, MaxLength);
        var dst = MemoryMarshal.CreateSpan(ref Buffer[0], MaxLength + 1);
        src[..len].CopyTo(dst);
        dst[len] = 0;
    }

    // For callers that only have a string. No byte[] allocation.
    public void Set(string? value)
    {
        int len = string.IsNullOrEmpty(value) ? 0 : Math.Min(value.Length, MaxLength);
        for (int i = 0; i < len; i++) Buffer[i] = (byte)value![i];
        Buffer[len] = 0;
    }

    // Allocates by nature: UI and diagnostics only, not message paths.
    public override readonly string ToString()
    {
        fixed (byte* p = Buffer) return Encoding.ASCII.GetString(p, Length);
    }
}