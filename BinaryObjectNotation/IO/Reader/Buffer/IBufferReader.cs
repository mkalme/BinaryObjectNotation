namespace BinaryObjectNotation.IO
{
    public interface IBufferReader
    {
        void Read(ref Span<byte> buffer);
    }
}
