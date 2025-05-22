using System.Buffers.Binary;
using System.Text;

namespace BinaryObjectNotation.IO
{
    public class Writer : IWriter
    {
        public virtual IBufferWriter BufferWriter { get; set; }
        public virtual Encoding Encoding { get; set; } = Encoding.UTF8;

        public Writer(Stream output) : this(new StreamBufferWriter(output)) { }
        public Writer(IBufferWriter bufferFiller)
        {
            BufferWriter = bufferFiller;
        }

        public virtual void Write(byte value)
        {
            BufferWriter.Write(new ReadOnlySpan<byte>(value));
        }
        public virtual void Write(byte[] array)
        {
            BufferWriter.Write(array);
        }

        public virtual void Write(short value)
        {
            if (ShouldReverseEndianess()) value = BinaryPrimitives.ReverseEndianness(value);

            Span<byte> buffer = stackalloc byte[sizeof(short)];
            if (!BitConverter.TryWriteBytes(buffer, value)) return;

            BufferWriter.Write(buffer);
        }
        public virtual void Write(short[] array)
        {
            bool reverse = ShouldReverseEndianess();
            Span<byte> buffer = stackalloc byte[sizeof(short) * array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                short value = array[i];
                if (reverse) value = BinaryPrimitives.ReverseEndianness(value);

                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(short));
                if (!BitConverter.TryWriteBytes(slicedBuffer, value)) return;
            }

            BufferWriter.Write(buffer);
        }

        public virtual void Write(ushort value)
        {
            if (ShouldReverseEndianess()) value = BinaryPrimitives.ReverseEndianness(value);

            Span<byte> buffer = stackalloc byte[sizeof(ushort)];
            if (!BitConverter.TryWriteBytes(buffer, value)) return;

            BufferWriter.Write(buffer);
        }
        public virtual void Write(ushort[] array)
        {
            bool reverse = ShouldReverseEndianess();
            Span<byte> buffer = stackalloc byte[sizeof(ushort) * array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                ushort value = array[i];
                if (reverse) value = BinaryPrimitives.ReverseEndianness(value);

                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(ushort));
                if (!BitConverter.TryWriteBytes(slicedBuffer, value)) return;
            }

            BufferWriter.Write(buffer);
        }

        public virtual void Write(int value)
        {
            if (ShouldReverseEndianess()) value = BinaryPrimitives.ReverseEndianness(value);

            Span<byte> buffer = stackalloc byte[sizeof(int)];
            if (!BitConverter.TryWriteBytes(buffer, value)) return;

            BufferWriter.Write(buffer);
        }
        public virtual void Write(int[] array)
        {
            bool reverse = ShouldReverseEndianess();
            Span<byte> buffer = stackalloc byte[sizeof(int) * array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int value = array[i];
                if (reverse) value = BinaryPrimitives.ReverseEndianness(value);

                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(int));
                if (!BitConverter.TryWriteBytes(slicedBuffer, value)) return;
            }

            BufferWriter.Write(buffer);
        }

        public virtual void Write(uint value)
        {
            if (ShouldReverseEndianess()) value = BinaryPrimitives.ReverseEndianness(value);

            Span<byte> buffer = stackalloc byte[sizeof(uint)];
            if (!BitConverter.TryWriteBytes(buffer, value)) return;

            BufferWriter.Write(buffer);
        }
        public virtual void Write(uint[] array)
        {
            bool reverse = ShouldReverseEndianess();
            Span<byte> buffer = stackalloc byte[sizeof(uint) * array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                uint value = array[i];
                if (reverse) value = BinaryPrimitives.ReverseEndianness(value);

                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(uint));
                if (!BitConverter.TryWriteBytes(slicedBuffer, value)) return;
            }

            BufferWriter.Write(buffer);
        }

        public virtual void Write(long value)
        {
            if (ShouldReverseEndianess()) value = BinaryPrimitives.ReverseEndianness(value);

            Span<byte> buffer = stackalloc byte[sizeof(long)];
            if (!BitConverter.TryWriteBytes(buffer, value)) return;

            BufferWriter.Write(buffer);
        }
        public virtual void Write(long[] array)
        {
            bool reverse = ShouldReverseEndianess();
            Span<byte> buffer = stackalloc byte[sizeof(long) * array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                long value = array[i];
                if (reverse) value = BinaryPrimitives.ReverseEndianness(value);

                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(long));
                if (!BitConverter.TryWriteBytes(slicedBuffer, value)) return;
            }

            BufferWriter.Write(buffer);
        }

        public virtual void Write(ulong value)
        {
            if (ShouldReverseEndianess()) value = BinaryPrimitives.ReverseEndianness(value);

            Span<byte> buffer = stackalloc byte[sizeof(ulong)];
            if (!BitConverter.TryWriteBytes(buffer, value)) return;

            BufferWriter.Write(buffer);
        }
        public virtual void Write(ulong[] array)
        {
            bool reverse = ShouldReverseEndianess();
            Span<byte> buffer = stackalloc byte[sizeof(ulong) * array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                ulong value = array[i];
                if (reverse) value = BinaryPrimitives.ReverseEndianness(value);

                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(ulong));
                if (!BitConverter.TryWriteBytes(slicedBuffer, value)) return;
            }

            BufferWriter.Write(buffer);
        }

        public virtual void Write(float value)
        {
            Span<byte> buffer = stackalloc byte[sizeof(float)];
            if (!BitConverter.TryWriteBytes(buffer, value)) return;

            BufferWriter.Write(buffer);
        }
        public virtual void Write(float[] array)
        {
            Span<byte> buffer = stackalloc byte[sizeof(float) * array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(float));
                if (!BitConverter.TryWriteBytes(slicedBuffer, array[i])) return;
            }

            BufferWriter.Write(buffer);
        }

        public virtual void Write(double value)
        {
            Span<byte> buffer = stackalloc byte[sizeof(double)];
            if (!BitConverter.TryWriteBytes(buffer, value)) return;

            BufferWriter.Write(buffer);
        }
        public virtual void Write(double[] array)
        {
            Span<byte> buffer = stackalloc byte[sizeof(double) * array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(double));
                if (!BitConverter.TryWriteBytes(slicedBuffer, array[i])) return;
            }

            BufferWriter.Write(buffer);
        }

        public virtual void Write(bool value)
        {
            Span<byte> buffer = stackalloc byte[sizeof(bool)];
            if (!BitConverter.TryWriteBytes(buffer, value)) return;

            BufferWriter.Write(buffer);
        }
        public virtual void Write(bool[] array)
        {
            Span<byte> buffer = stackalloc byte[sizeof(bool) * array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(bool));
                if (!BitConverter.TryWriteBytes(slicedBuffer, array[i])) return;
            }

            BufferWriter.Write(buffer);
        }

        public virtual void Write(char value)
        {
            Span<byte> buffer = stackalloc byte[sizeof(char)];
            if (!BitConverter.TryWriteBytes(buffer, value)) return;

            BufferWriter.Write(buffer);
        }
        public virtual void Write(char[] array)
        {
            Span<byte> buffer = stackalloc byte[sizeof(char) * array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                Span<byte> slicedBuffer = buffer.Slice(i * sizeof(char));
                if (!BitConverter.TryWriteBytes(slicedBuffer, array[i])) return;
            }

            BufferWriter.Write(buffer);
        }

        public virtual void Write(string value)
        {
            int byteCount = Encoding.GetByteCount(value);
            Write((uint)byteCount);

            Span<byte> buffer = stackalloc byte[byteCount];
            Encoding.GetBytes(value, buffer);

            BufferWriter.Write(buffer);
        }
        public virtual void Write(string[] array)
        {
            foreach (string value in array)
            {
                Write(value);
            }
        }

        public virtual bool ShouldReverseEndianess()
        {
            return !BitConverter.IsLittleEndian;
        }
    }
}
