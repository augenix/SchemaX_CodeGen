using System.Net.Sockets;

namespace SchemaX_CodeGen;

public static class SocketTx
{
    private static Socket _socket = default!;
    private static readonly object _sendLock = new();

    public static void Initialize(Socket socket)
    {
        SocketTx._socket = socket ?? throw new ArgumentNullException(nameof(socket));
    }

    public static void SendAll(Span<byte> payloadBytes)
    {
        lock (_sendLock)
        {
            int totalSent = 0;

            while (totalSent < payloadBytes.Length)
            {
                try
                {
                    int sent = _socket.Send(payloadBytes.Slice(totalSent));

                    if (sent == 0)
                    {
                        Thread.SpinWait(1);
                        continue;
                    }

                    totalSent += sent;
                }
                catch (SocketException ex) when (ex.SocketErrorCode == SocketError.WouldBlock)
                {
                    Thread.SpinWait(1);
                }
            }
        }
    }
}