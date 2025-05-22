namespace BinaryObjectNotation.IO
{
    public class ArrayTagDeserializer : IIdTagDeserializer<ArrayTag>
    {
        public ITagDeserializer<CompoundTag> CompoundTagDeserializer { get; set; }

        public ArrayTagDeserializer(ITagDeserializer<CompoundTag> compoundTagDeserializer) 
        {
            CompoundTagDeserializer = compoundTagDeserializer;
        }

        public ArrayTag? Deserialize(TagId id, IReader reader)
        {
            int length = reader.ReadInt32();

            switch (id)
            {
                case TagId.ByteArray: return reader.ReadByteArray(length);
                case TagId.Int16Array: return reader.ReadInt16Array(length);
                case TagId.UInt16Array: return reader.ReadUInt16Array(length);
                case TagId.Int32Array: return reader.ReadInt32Array(length);
                case TagId.UInt32Array: return reader.ReadUInt32Array(length);
                case TagId.Int64Array: return reader.ReadInt64Array(length);
                case TagId.UInt64Array: return reader.ReadUInt64Array(length);
                case TagId.SingleArray: return reader.ReadSingleArray(length);
                case TagId.DoubleArray: return reader.ReadDoubleArray(length);
                case TagId.BooleanArray: return reader.ReadBooleanArray(length);
                case TagId.CharArray: return reader.ReadCharArray(length);
                case TagId.StringArray: return reader.ReadStringArray(length);
                case TagId.CompoundArray:
                    CompoundTag[] output = new CompoundTag[length];
                    for (int i = 0; i < length; i++) 
                    {
                        output[i] = CompoundTagDeserializer.Deserialize(reader) ?? null!;
                    }

                    return output;
            }

            return null;
        }
    }
}
