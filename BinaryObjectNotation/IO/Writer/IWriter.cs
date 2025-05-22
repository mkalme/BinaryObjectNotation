namespace BinaryObjectNotation.IO
{
    public interface IWriter
    {
        void Write(byte value);
        void Write(byte[] array);

        void Write(short value);
        void Write(short[] array);

        void Write(ushort value);
        void Write(ushort[] array);

        void Write(int value);
        void Write(int[] array);

        void Write(uint value);
        void Write(uint[] array);

        void Write(long value);
        void Write(long[] array);

        void Write(ulong value);
        void Write(ulong[] array);

        void Write(float value);
        void Write(float[] array);

        void Write(double value);
        void Write(double[] array);

        void Write(bool value);
        void Write(bool[] array);

        void Write(char value);
        void Write(char[] array);

        void Write(string value);
        void Write(string[] array);
    }
}