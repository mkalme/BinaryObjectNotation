namespace BinaryObjectNotation.IO
{
    public class IdTagDeserializer : IIdTagDeserializer<Tag>
    {
        public IIdTagDeserializer<ValueTag> ValueTagDeserializer { get; set; }
        public ITagDeserializer<CompoundTag> CompoundTagDeserializer { get; set; }
        public IIdTagDeserializer<ArrayTag> ArrayTagDeserializer { get; set; }

        public IdTagDeserializer(ITagDeserializer<Tag> tagDeserializer)
        {
            ValueTagDeserializer = new ValueTagDeserializer();
            CompoundTagDeserializer = new CompoundTagDeserializer(tagDeserializer);
            ArrayTagDeserializer = new ArrayTagDeserializer(CompoundTagDeserializer);
        }

        public Tag? Deserialize(TagId id, IReader reader)
        {
            switch (id)
            {
                case TagId.Byte:
                case TagId.Int16:
                case TagId.UInt16:
                case TagId.Int32:
                case TagId.UInt32:
                case TagId.Int64:
                case TagId.UInt64:
                case TagId.Single:
                case TagId.Double:
                case TagId.Boolean:
                case TagId.Char:
                case TagId.String:
                    return ValueTagDeserializer.Deserialize(id, reader);
                case TagId.Compound:
                    return CompoundTagDeserializer.Deserialize(reader);
                case TagId.ByteArray:
                case TagId.Int16Array:
                case TagId.UInt16Array:
                case TagId.Int32Array:
                case TagId.UInt32Array:
                case TagId.Int64Array:
                case TagId.UInt64Array:
                case TagId.SingleArray:
                case TagId.DoubleArray:
                case TagId.BooleanArray:
                case TagId.CharArray:
                case TagId.StringArray:
                case TagId.CompoundArray:
                    return ArrayTagDeserializer.Deserialize(id, reader);
            }

            return null;
        }
    }
}
