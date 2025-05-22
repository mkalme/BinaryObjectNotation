namespace BinaryObjectNotation
{
    public sealed class ValueTag : Tag
    {
        private readonly object _internalValue;

        public static implicit operator ValueTag(byte value) => new(value);
        public static implicit operator ValueTag(short value) => new(value);
        public static implicit operator ValueTag(ushort value) => new(value);
        public static implicit operator ValueTag(int value) => new(value);
        public static implicit operator ValueTag(uint value) => new(value);
        public static implicit operator ValueTag(long value) => new(value);
        public static implicit operator ValueTag(ulong value) => new(value);
        public static implicit operator ValueTag(float value) => new(value);
        public static implicit operator ValueTag(double value) => new(value);
        public static implicit operator ValueTag(bool value) => new(value);
        public static implicit operator ValueTag(char value) => new(value);
        public static implicit operator ValueTag(string value) => new(value);

        public static implicit operator byte(ValueTag tag) => (byte)tag._internalValue;
        public static implicit operator short(ValueTag tag) => (short)tag._internalValue;
        public static implicit operator ushort(ValueTag tag) => (ushort)tag._internalValue;
        public static implicit operator int(ValueTag tag) => (int)tag._internalValue;
        public static implicit operator uint(ValueTag tag) => (uint)tag._internalValue;
        public static implicit operator long(ValueTag tag) => (long)tag._internalValue;
        public static implicit operator ulong(ValueTag tag) => (ulong)tag._internalValue;
        public static implicit operator float(ValueTag tag) => (float)tag._internalValue;
        public static implicit operator double(ValueTag tag) => (double)tag._internalValue;
        public static implicit operator bool(ValueTag tag) => (bool)tag._internalValue;
        public static implicit operator char(ValueTag tag) => (char)tag._internalValue;
        public static implicit operator string(ValueTag tag) => (string)tag._internalValue;

        private ValueTag(TagId id, object internalValue) : base(id)
        {
            _internalValue = internalValue;
        }

        public ValueTag(byte value) : this(TagId.Byte, value) { }
        public ValueTag(short value) : this(TagId.Int16, value) { }
        public ValueTag(ushort value) : this(TagId.UInt16, value) { }
        public ValueTag(int value) : this(TagId.Int32, value) { }
        public ValueTag(uint value) : this(TagId.UInt32, value) { }
        public ValueTag(long value) : this(TagId.Int64, value) { }
        public ValueTag(ulong value) : this(TagId.UInt64, value) { }
        public ValueTag(float value) : this(TagId.Single, value) { }
        public ValueTag(double value) : this(TagId.Double, value) { }
        public ValueTag(bool value) : this(TagId.Boolean, value) { }
        public ValueTag(char value) : this(TagId.Char, value) { }
        public ValueTag(string value) : this(TagId.String, value) { }

        public override bool Equals(Tag? other)
        {
            if(other is null || other is not ValueTag valueTag || valueTag.Id != Id) return false;
            return _internalValue.Equals(valueTag._internalValue);
        }

        public override object Clone()
        {
            switch (Id)
            {
                case TagId.Byte: return new ValueTag((byte)_internalValue);
                case TagId.Int16: return new ValueTag((short)_internalValue);
                case TagId.UInt16: return new ValueTag((ushort)_internalValue);
                case TagId.Int32: return new ValueTag((int)_internalValue);
                case TagId.UInt32: return new ValueTag((uint)_internalValue);
                case TagId.Int64: return new ValueTag((long)_internalValue);
                case TagId.UInt64: return new ValueTag((ulong)_internalValue);
                case TagId.Single: return new ValueTag((float)_internalValue);
                case TagId.Double: return new ValueTag((double)_internalValue);
                case TagId.Boolean: return new ValueTag((bool)_internalValue);
                case TagId.Char: return new ValueTag((char)_internalValue);
                case TagId.String:
                default: return new ValueTag((string)_internalValue);
            }
        }

        public override string ToString()
        {
            return TagStringifier.InternalValueToString(Id, _internalValue) ?? string.Empty;
        }
    }
}
