#nullable enable
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace SchemaX_CodeGen.Queues
{
    public unsafe struct SendFrame
    {
        public const int MaxSegments = 12;

        public byte* BasePtr;
        public int Segment0StartWord;
        public int Segment0WordCount;
        public byte SegmentCount;
        public int TotalWords;

        public fixed int Offsets[MaxSegments];
        public fixed int WordCounts[MaxSegments];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly unsafe void WriteToSocket(Socket socket)
        {
            if (SegmentCount == 0)
                return;

            // Send segment 0 (header + seg0 payload)
            {
                byte* bptr = (byte*)(BasePtr + Segment0StartWord);
                int blen  = Segment0WordCount * 8;
                int sent = 0;
                while (sent < blen)
                    sent += socket.Send(new ReadOnlySpan<byte>(bptr + sent, blen - sent));
            }

            // Send additional segments
            for (int seg = 1; seg < SegmentCount; seg++)
            {
                int words = WordCounts[seg];
                if (words == 0)
                    continue;

                byte* bptr = (byte*)(BasePtr + Offsets[seg]);
                int blen  = words * 8;

                int sent = 0;
                while (sent < blen)
                    sent += socket.Send(new ReadOnlySpan<byte>(bptr + sent, blen - sent));
            }
        }

    }
}