namespace BinaryObjectNotation.IO
{
    public interface IBufferWriter
    {
        void Write(ReadOnlySpan<byte> buffer);
    }
}
