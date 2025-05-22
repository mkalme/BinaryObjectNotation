namespace BinaryObjectNotation.IO
{
    public interface IReader
    {
        byte ReadByte();
        byte[] ReadByteArray(int length);

        short ReadInt16();
        short[] ReadInt16Array(int length);

        ushort ReadUInt16();
        ushort[] ReadUInt16Array(int length);

        int ReadInt32();
        int[] ReadInt32Array(int length);

        uint ReadUInt32();
        uint[] ReadUInt32Array(int length);

        long ReadInt64();
        long[] ReadInt64Array(int length);

        ulong ReadUInt64();
        ulong[] ReadUInt64Array(int length);

        float ReadSingle();
        float[] ReadSingleArray(int length);

        double ReadDouble();
        double[] ReadDoubleArray(int length);

        bool ReadBoolean();
        bool[] ReadBooleanArray(int length);

        char ReadChar();
        char[] ReadCharArray(int length);

        string ReadString();
        string[] ReadStringArray(int length);
    }
}
