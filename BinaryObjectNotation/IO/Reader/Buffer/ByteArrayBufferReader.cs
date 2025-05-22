namespace BinaryObjectNotation.IO
{
    public class ByteArrayBufferReader : IBufferReader
    {
        public byte[] Buffer { get; set; }
        public int Index { get; set; }

        public ByteArrayBufferReader(byte[] buffer, int index = 0)
        {
            Buffer = buffer;
            Index = index;
        }

        public void Read(ref Span<byte> buffer)
        {
            buffer = Buffer.AsSpan(Index, buffer.Length);
            Index += buffer.Length;
        }
    }
}
