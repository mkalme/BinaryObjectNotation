using System.Buffers.Binary;
using System.Text;

namespace BinaryObjectNotation.IO
{
    public class Reader : IReader
    {
        public virtual IBufferReader BufferReader { get; set; }
        public virtual Encoding Encoding { get; set; } = Encoding.UTF8;

        public Reader(Stream input) : this(new StreamBufferReader(input)) { }
        public Reader(byte[] inputBuffer, int index = 0) : this(new ByteArrayBufferReader(inputBuffer, index)) { }
        public Reader(IBufferReader bufferProvider)
        {
            BufferReader = bufferProvider;
        }

        public virtual byte ReadByte()
        {
            Span<byte> buffer = stackalloc byte[sizeof(byte)];
            BufferReader.Read(ref buffer);

            return buffer[0];
        }
        public virtual byte[] ReadByteArray(int length)
        {
            Span<byte> buffer = stackalloc byte[sizeof(byte) * length];
            BufferReader.Read(ref buffer);

            return buffer.ToArray();
        }

        public virtual short ReadInt16()
        {
            Span<byte> buffer = stackalloc byte[sizeof(short)];
            BufferReader.Read(ref buffer);

            short output = BitConverter.ToInt16(buffer);
            if (ShouldReverseEndianess()) output = BinaryPrimitives.ReverseEndianness(output);

            return output;
        }
        public virtual short[] ReadInt16Array(int length)
        {
            Span<byte> buffer = stackalloc byte[sizeof(short) * length];
            BufferReader.Read(ref buffer);

            bool reverse = ShouldReverseEndianess();

            short[] output = new short[length];
            for (int i = 0; i < length; i++)
            {
                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(short));
                short value = BitConverter.ToInt16(slicedBuffer);

                if (reverse) value = BinaryPrimitives.ReverseEndianness(value);
                output[i] = value;
            }

            return output;
        }

        public virtual ushort ReadUInt16()
        {
            Span<byte> buffer = stackalloc byte[sizeof(ushort)];
            BufferReader.Read(ref buffer);

            ushort output = BitConverter.ToUInt16(buffer);
            if (ShouldReverseEndianess()) output = BinaryPrimitives.ReverseEndianness(output);

            return output;
        }
        public virtual ushort[] ReadUInt16Array(int length)
        {
            Span<byte> buffer = stackalloc byte[sizeof(ushort) * length];
            BufferReader.Read(ref buffer);

            bool reverse = ShouldReverseEndianess();

            ushort[] output = new ushort[length];
            for (int i = 0; i < length; i++)
            {
                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(ushort));
                ushort value = BitConverter.ToUInt16(slicedBuffer);

                if (reverse) value = BinaryPrimitives.ReverseEndianness(value);
                output[i] = value;
            }

            return output;
        }

        public virtual int ReadInt32()
        {
            Span<byte> buffer = stackalloc byte[sizeof(int)];
            BufferReader.Read(ref buffer);

            int output = BitConverter.ToInt32(buffer);
            if (ShouldReverseEndianess()) output = BinaryPrimitives.ReverseEndianness(output);

            return output;
        }
        public virtual int[] ReadInt32Array(int length)
        {
            Span<byte> buffer = stackalloc byte[sizeof(int) * length];
            BufferReader.Read(ref buffer);

            bool reverse = ShouldReverseEndianess();

            int[] output = new int[length];
            for (int i = 0; i < length; i++)
            {
                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(int));
                int value = BitConverter.ToInt32(slicedBuffer);

                if (reverse) value = BinaryPrimitives.ReverseEndianness(value);
                output[i] = value;
            }

            return output;
        }

        public virtual uint ReadUInt32()
        {
            Span<byte> buffer = stackalloc byte[sizeof(uint)];
            BufferReader.Read(ref buffer);

            uint output = BitConverter.ToUInt32(buffer);
            if (ShouldReverseEndianess()) output = BinaryPrimitives.ReverseEndianness(output);

            return output;
        }
        public virtual uint[] ReadUInt32Array(int length)
        {
            Span<byte> buffer = stackalloc byte[sizeof(uint) * length];
            BufferReader.Read(ref buffer);

            bool reverse = ShouldReverseEndianess();

            uint[] output = new uint[length];
            for (int i = 0; i < length; i++)
            {
                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(uint));
                uint value = BitConverter.ToUInt32(slicedBuffer);

                if (reverse) value = BinaryPrimitives.ReverseEndianness(value);
                output[i] = value;
            }

            return output;
        }

        public virtual long ReadInt64()
        {
            Span<byte> buffer = stackalloc byte[sizeof(long)];
            BufferReader.Read(ref buffer);

            long output = BitConverter.ToInt64(buffer);
            if (ShouldReverseEndianess()) output = BinaryPrimitives.ReverseEndianness(output);

            return output;
        }
        public virtual long[] ReadInt64Array(int length)
        {
            Span<byte> buffer = stackalloc byte[sizeof(long) * length];
            BufferReader.Read(ref buffer);

            bool reverse = ShouldReverseEndianess();

            long[] output = new long[length];
            for (int i = 0; i < length; i++)
            {
                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(long));
                long value = BitConverter.ToInt64(slicedBuffer);

                if (reverse) value = BinaryPrimitives.ReverseEndianness(value);
                output[i] = value;
            }

            return output;
        }

        public virtual ulong ReadUInt64()
        {
            Span<byte> buffer = stackalloc byte[sizeof(ulong)];
            BufferReader.Read(ref buffer);

            ulong output = BitConverter.ToUInt64(buffer);
            if (ShouldReverseEndianess()) output = BinaryPrimitives.ReverseEndianness(output);

            return output;
        }
        public virtual ulong[] ReadUInt64Array(int length)
        {
            Span<byte> buffer = stackalloc byte[sizeof(ulong) * length];
            BufferReader.Read(ref buffer);

            bool reverse = ShouldReverseEndianess();

            ulong[] output = new ulong[length];
            for (int i = 0; i < length; i++)
            {
                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(ulong));
                ulong value = BitConverter.ToUInt64(slicedBuffer);

                if (reverse) value = BinaryPrimitives.ReverseEndianness(value);
                output[i] = value;
            }

            return output;
        }

        public virtual float ReadSingle()
        {
            Span<byte> buffer = stackalloc byte[sizeof(float)];
            BufferReader.Read(ref buffer);

            float output = BitConverter.ToSingle(buffer);
            return output;
        }
        public virtual float[] ReadSingleArray(int length)
        {
            Span<byte> buffer = stackalloc byte[sizeof(float) * length];
            BufferReader.Read(ref buffer);

            float[] output = new float[length];
            for (int i = 0; i < length; i++)
            {
                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(float));
                float value = BitConverter.ToSingle(slicedBuffer);

                output[i] = value;
            }

            return output;
        }

        public virtual double ReadDouble()
        {
            Span<byte> buffer = stackalloc byte[sizeof(double)];
            BufferReader.Read(ref buffer);
            
            double output = BitConverter.ToDouble(buffer);
            return output;
        }
        public virtual double[] ReadDoubleArray(int length)
        {
            Span<byte> buffer = stackalloc byte[sizeof(double) * length];
            BufferReader.Read(ref buffer);

            double[] output = new double[length];
            for (int i = 0; i < length; i++)
            {
                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(double));
                double value = BitConverter.ToDouble(slicedBuffer);

                output[i] = value;
            }

            return output;
        }

        public virtual bool ReadBoolean()
        {
            Span<byte> buffer = stackalloc byte[sizeof(bool)];
            BufferReader.Read(ref buffer);

            return buffer[0] == 1;
        }
        public virtual bool[] ReadBooleanArray(int length)
        {
            Span<byte> buffer = stackalloc byte[sizeof(bool) * length];
            BufferReader.Read(ref buffer);

            bool[] output = new bool[length];
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = buffer[i] == 1;
            }

            return output;
        }

        public virtual char ReadChar()
        {
            Span<byte> buffer = stackalloc byte[sizeof(char)];
            BufferReader.Read(ref buffer);

            char output = BitConverter.ToChar(buffer);
            return output;
        }
        public virtual char[] ReadCharArray(int length)
        {
            Span<byte> buffer = stackalloc byte[sizeof(char) * length];
            BufferReader.Read(ref buffer);

            char[] output = new char[length];
            for (int i = 0; i < length; i++)
            {
                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(char));
                char value = BitConverter.ToChar(slicedBuffer);

                output[i] = value;
            }

            return output;
        }

        public virtual string ReadString()
        {
            int length = (int)ReadUInt32();
            Span<byte> buffer = stackalloc byte[length];
            BufferReader.Read(ref buffer);

            return Encoding.GetString(buffer);
        }
        public virtual string[] ReadStringArray(int length)
        {
            string[] output = new string[length];

            for (int i = 0; i < length; i++)
            {
                output[i] = ReadString();
            }

            return output;
        }

        public virtual bool ShouldReverseEndianess()
        {
            return !BitConverter.IsLittleEndian;
        }
    }
}
