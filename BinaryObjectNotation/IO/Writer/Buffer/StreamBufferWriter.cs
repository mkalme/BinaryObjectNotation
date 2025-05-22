namespace BinaryObjectNotation.IO
{
    public class StreamBufferWriter : IBufferWriter
    {
        public Stream Output { get; set; }

        public StreamBufferWriter(Stream output)
        {
            Output = output;
        }

        public void Write(ReadOnlySpan<byte> buffer)
        {
            Output.Write(buffer);
        }
    }
}
