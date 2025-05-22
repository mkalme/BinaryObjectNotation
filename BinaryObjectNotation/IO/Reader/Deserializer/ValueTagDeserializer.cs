namespace BinaryObjectNotation.IO
{
    public class ValueTagDeserializer : IIdTagDeserializer<ValueTag>
    {
        public ValueTag? Deserialize(TagId id, IReader reader)
        {
            switch (id)
            {
                case TagId.Byte: return reader.ReadByte();
                case TagId.Int16: return reader.ReadInt16();
                case TagId.UInt16: return reader.ReadUInt16();
                case TagId.Int32: return reader.ReadInt32();
                case TagId.UInt32: return reader.ReadUInt32();
                case TagId.Int64: return reader.ReadInt64();
                case TagId.UInt64: return reader.ReadUInt64();
                case TagId.Single: return reader.ReadSingle();
                case TagId.Double: return reader.ReadDouble();
                case TagId.Boolean: return reader.ReadBoolean();
                case TagId.Char: return reader.ReadChar();
                case TagId.String: return reader.ReadString();
            }

            return null;
        }
    }
}
