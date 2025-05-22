using System.Text;

namespace BinaryObjectNotation
{
    public sealed class ArrayTag : Tag
    {
        private readonly Array _internalArray;

        public int Length => _internalArray.Length;

        public static implicit operator ArrayTag(byte[] array) => new(array);
        public static implicit operator ArrayTag(short[] array) => new(array);
        public static implicit operator ArrayTag(ushort[] array) => new(array);
        public static implicit operator ArrayTag(int[] array) => new(array);
        public static implicit operator ArrayTag(uint[] array) => new(array);
        public static implicit operator ArrayTag(long[] array) => new(array);
        public static implicit operator ArrayTag(ulong[] array) => new(array);
        public static implicit operator ArrayTag(float[] array) => new(array);
        public static implicit operator ArrayTag(double[] array) => new(array);
        public static implicit operator ArrayTag(bool[] array) => new(array);
        public static implicit operator ArrayTag(char[] array) => new(array);
        public static implicit operator ArrayTag(string[] array) => new(array);
        public static implicit operator ArrayTag(CompoundTag[] array) => new(array);

        public static implicit operator byte[](ArrayTag tag) => (byte[])tag._internalArray;
        public static implicit operator short[](ArrayTag tag) => (short[])tag._internalArray;
        public static implicit operator ushort[](ArrayTag tag) => (ushort[])tag._internalArray;
        public static implicit operator int[](ArrayTag tag) => (int[])tag._internalArray;
        public static implicit operator uint[](ArrayTag tag) => (uint[])tag._internalArray;
        public static implicit operator long[](ArrayTag tag) => (long[])tag._internalArray;
        public static implicit operator ulong[](ArrayTag tag) => (ulong[])tag._internalArray;
        public static implicit operator float[](ArrayTag tag) => (float[])tag._internalArray;
        public static implicit operator double[](ArrayTag tag) => (double[])tag._internalArray;
        public static implicit operator bool[](ArrayTag tag) => (bool[])tag._internalArray;
        public static implicit operator char[](ArrayTag tag) => (char[])tag._internalArray;
        public static implicit operator string[](ArrayTag tag) => (string[])tag._internalArray;
        public static implicit operator CompoundTag[](ArrayTag tag) => (CompoundTag[])tag._internalArray;

        private ArrayTag(TagId id, Array internalArray) : base(id)
        {
            _internalArray = internalArray;
        }

        public ArrayTag(byte[] array) : this(TagId.ByteArray, array) { }
        public ArrayTag(short[] array) : this(TagId.Int16Array, array) { }
        public ArrayTag(ushort[] array) : this(TagId.UInt16Array, array) { }
        public ArrayTag(int[] array) : this(TagId.Int32Array, array) { }
        public ArrayTag(uint[] array) : this(TagId.UInt32Array, array) { }
        public ArrayTag(long[] array) : this(TagId.Int64Array, array) { }
        public ArrayTag(ulong[] array) : this(TagId.UInt64Array, array) { }
        public ArrayTag(float[] array) : this(TagId.SingleArray, array) { }
        public ArrayTag(double[] array) : this(TagId.DoubleArray, array) { }
        public ArrayTag(bool[] array) : this(TagId.BooleanArray, array) { }
        public ArrayTag(char[] array) : this(TagId.CharArray, array) { }
        public ArrayTag(string[] array) : this(TagId.StringArray, array) { }
        public ArrayTag(CompoundTag[] array) : this(TagId.CompoundArray, array) { }

        public override bool Equals(Tag? other)
        {
            if (other is null || other is not ArrayTag arrayTag || arrayTag.Length != Length || arrayTag.Id != Id) return false;

            switch (Id)
            {
                case TagId.ByteArray: return ArrayEquals<byte>(_internalArray, arrayTag._internalArray);
                case TagId.Int16Array: return ArrayEquals<short>(_internalArray, arrayTag._internalArray);
                case TagId.UInt16Array: return ArrayEquals<ushort>(_internalArray, arrayTag._internalArray);
                case TagId.Int32Array: return ArrayEquals<int>(_internalArray, arrayTag._internalArray);
                case TagId.UInt32Array: return ArrayEquals<uint>(_internalArray, arrayTag._internalArray);
                case TagId.Int64Array: return ArrayEquals<long>(_internalArray, arrayTag._internalArray);
                case TagId.UInt64Array: return ArrayEquals<ulong>(_internalArray, arrayTag._internalArray);
                case TagId.SingleArray: return ArrayEquals<float>(_internalArray, arrayTag._internalArray);
                case TagId.DoubleArray: return ArrayEquals<double>(_internalArray, arrayTag._internalArray);
                case TagId.BooleanArray: return ArrayEquals<bool>(_internalArray, arrayTag._internalArray);
                case TagId.CharArray: return ArrayEquals<char>(_internalArray, arrayTag._internalArray);
                case TagId.StringArray: return ArrayEquals<string>(_internalArray, arrayTag._internalArray);
                case TagId.CompoundArray: return ArrayEquals<CompoundTag>(_internalArray, arrayTag._internalArray);
            }

            return false;
        }
        private static bool ArrayEquals<T>(Array left, Array right)
        {
            return Enumerable.SequenceEqual((T[])left, (T[])right);
        }

        public override object Clone()
        {
            switch (Id)
            {
                case TagId.ByteArray: return new ArrayTag(ArrayClone<byte>(_internalArray));
                case TagId.Int16Array: return new ArrayTag(ArrayClone<short>(_internalArray));
                case TagId.UInt16Array: return new ArrayTag(ArrayClone<ushort>(_internalArray));
                case TagId.Int32Array: return new ArrayTag(ArrayClone<int>(_internalArray));
                case TagId.UInt32Array: return new ArrayTag(ArrayClone<uint>(_internalArray));
                case TagId.Int64Array: return new ArrayTag(ArrayClone<long>(_internalArray));
                case TagId.UInt64Array: return new ArrayTag(ArrayClone<ulong>(_internalArray));
                case TagId.SingleArray: return new ArrayTag(ArrayClone<float>(_internalArray));
                case TagId.DoubleArray: return new ArrayTag(ArrayClone<double>(_internalArray));
                case TagId.BooleanArray: return new ArrayTag(ArrayClone<bool>(_internalArray));
                case TagId.CharArray: return new ArrayTag(ArrayClone<char>(_internalArray));
                case TagId.StringArray: return new ArrayTag(ArrayClone<string>(_internalArray));
                case TagId.CompoundArray:
                default:
                    CompoundTag[] copyFrom = this;

                    CompoundTag[] output = new CompoundTag[Length];
                    for (int i = 0; i < Length; i++) 
                    {
                        CompoundTag? copy = copyFrom[i].Clone() as CompoundTag;
                        if (copy is not null) output[i] = copy;
                    }

                    return new ArrayTag(output);
            }
        }
        private static T[] ArrayClone<T>(Array array) 
        {
            T[] output = new T[array.Length];
            array.CopyTo(output, 0);

            return output;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('[');

            if (Id != TagId.CompoundArray)
            {
                for (int i = 0; i < Length; i++)
                {
                    builder.Append(TagStringifier.InternalValueToString(Id, _internalArray.GetValue(i)));
                    if (i < Length - 1) builder.Append(", ");
                }
            }
            else 
            {
                CompoundTag[] compounds = this;

                builder.AppendLine();
                for (int i = 0; i < Length; i++)
                {
                    string value = TagStringifier.PadLeftAllLines(compounds[i].ToString(), "\t", false);
                    builder.Append(value);

                    if (i < Length - 1) builder.AppendLine(",");
                }

                builder.AppendLine();
            }

            builder.Append(']');
            return builder.ToString();
        }
    }
}
