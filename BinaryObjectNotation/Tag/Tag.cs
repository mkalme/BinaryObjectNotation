namespace BinaryObjectNotation
{
    public abstract class Tag : IEquatable<Tag>, ICloneable
    {
        public virtual TagId Id { get; private set; }

        public static implicit operator Tag(byte value) => new ValueTag(value);
        public static implicit operator Tag(short value) => new ValueTag(value);
        public static implicit operator Tag(ushort value) => new ValueTag(value);
        public static implicit operator Tag(int value) => new ValueTag(value);
        public static implicit operator Tag(uint value) => new ValueTag(value);
        public static implicit operator Tag(long value) => new ValueTag(value);
        public static implicit operator Tag(ulong value) => new ValueTag(value);
        public static implicit operator Tag(float value) => new ValueTag(value);
        public static implicit operator Tag(double value) => new ValueTag(value);
        public static implicit operator Tag(bool value) => new ValueTag(value);
        public static implicit operator Tag(char value) => new ValueTag(value);
        public static implicit operator Tag(string value) => new ValueTag(value);
        
        public static implicit operator Tag(byte[] array) => new ArrayTag(array);
        public static implicit operator Tag(short[] array) => new ArrayTag(array);
        public static implicit operator Tag(ushort[] array) => new ArrayTag(array);
        public static implicit operator Tag(int[] array) => new ArrayTag(array);
        public static implicit operator Tag(uint[] array) => new ArrayTag(array);
        public static implicit operator Tag(long[] array) => new ArrayTag(array);
        public static implicit operator Tag(ulong[] array) => new ArrayTag(array);
        public static implicit operator Tag(float[] array) => new ArrayTag(array);
        public static implicit operator Tag(double[] array) => new ArrayTag(array);
        public static implicit operator Tag(bool[] array) => new ArrayTag(array);
        public static implicit operator Tag(char[] array) => new ArrayTag(array);
        public static implicit operator Tag(string[] array) => new ArrayTag(array);
        public static implicit operator Tag(CompoundTag[] array) => new ArrayTag(array);

        public static implicit operator byte(Tag tag) => (ValueTag)tag;
        public static implicit operator short(Tag tag) => (ValueTag)tag;
        public static implicit operator ushort(Tag tag) => (ValueTag)tag;
        public static implicit operator int(Tag tag) => (ValueTag)tag;
        public static implicit operator uint(Tag tag) => (ValueTag)tag;
        public static implicit operator long(Tag tag) => (ValueTag)tag;
        public static implicit operator ulong(Tag tag) => (ValueTag)tag;
        public static implicit operator float(Tag tag) => (ValueTag)tag;
        public static implicit operator double(Tag tag) => (ValueTag)tag;
        public static implicit operator bool(Tag tag) => (ValueTag)tag;
        public static implicit operator char(Tag tag) => (ValueTag)tag;
        public static implicit operator string(Tag tag) => (ValueTag)tag;

        public static implicit operator byte[](Tag tag) => (ArrayTag)tag;
        public static implicit operator short[](Tag tag) => (ArrayTag)tag;
        public static implicit operator ushort[](Tag tag) => (ArrayTag)tag;
        public static implicit operator int[](Tag tag) => (ArrayTag)tag;
        public static implicit operator uint[](Tag tag) => (ArrayTag)tag;
        public static implicit operator long[](Tag tag) => (ArrayTag)tag;
        public static implicit operator ulong[](Tag tag) => (ArrayTag)tag;
        public static implicit operator float[](Tag tag) => (ArrayTag)tag;
        public static implicit operator double[](Tag tag) => (ArrayTag)tag;
        public static implicit operator bool[](Tag tag) => (ArrayTag)tag;
        public static implicit operator char[](Tag tag) => (ArrayTag)tag;
        public static implicit operator string[](Tag tag) => (ArrayTag)tag;
        public static implicit operator CompoundTag[](Tag tag) => (ArrayTag)tag;

        internal Tag(TagId id) 
        {
            Id = id;
        }

        public abstract bool Equals(Tag? other);
        public override bool Equals(object? obj)
        {
            if(obj is null || obj is not Tag tag) return false;
            return Equals(tag);
        }

        public abstract object Clone();

        public override abstract string ToString();
    }
}
