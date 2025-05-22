namespace BinaryObjectNotation.IO
{
    public class StreamBufferReader : IBufferReader
    {
        public Stream Input { get; set; }

        public StreamBufferReader(Stream input)
        {
            Input = input;
        }

        public void Read(ref Span<byte> buffer)
        {
            Input.Read(buffer);
        }
    }
}
