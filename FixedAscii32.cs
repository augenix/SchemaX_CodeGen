using System.Runtime.InteropServices;
using System.Text;

namespace SchemaX_CodeGen;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct FixedAscii32
{
    public const int MaxLength = 31;

    public fixed byte Buffer[32];

    public void Set(string value)
    {
        if (string.IsNullOrEmpty(value)) return;

        var bytes = Encoding.ASCII.GetBytes(value);
        int len = Math.Min(bytes.Length, MaxLength);

        fixed (byte* p = Buffer)
        {
            for (int i = 0; i < len; i++)
                p[i] = bytes[i];
            p[len] = 0;
        }
    }
    public bool IsEmpty
    {
        get
        {
            fixed (byte* p = Buffer)
                return p[0] == 0; // first byte zero means no data set
        }
    }

    public override string ToString()
    {
        fixed (byte* p = Buffer)
        {
            int len = 0;
            while (len < MaxLength && p[len] != 0) len++;
            return Encoding.ASCII.GetString(p, len);
        }
    }
}
