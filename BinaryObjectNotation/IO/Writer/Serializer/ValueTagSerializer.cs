namespace BinaryObjectNotation.IO
{
    public class ValueTagSerializer : ITagSerializer<ValueTag>
    {
        public void Serialize(ValueTag tag, IWriter writer)
        {
            switch (tag.Id)
            {
                case TagId.Byte:
                    writer.Write((byte)tag);
                    break;
                case TagId.Int16:
                    writer.Write((short)tag);
                    break;
                case TagId.UInt16:
                    writer.Write((ushort)tag);
                    break;
                case TagId.Int32:
                    writer.Write((int)tag);
                    break;
                case TagId.UInt32:
                    writer.Write((uint)tag);
                    break;
                case TagId.Int64:
                    writer.Write((long)tag);
                    break;
                case TagId.UInt64:
                    writer.Write((ulong)tag);
                    break;
                case TagId.Single:
                    writer.Write((float)tag);
                    break;
                case TagId.Double:
                    writer.Write((double)tag);
                    break;
                case TagId.Boolean:
                    writer.Write((bool)tag);
                    break;
                case TagId.Char:
                    writer.Write((char)tag);
                    break;
                case TagId.String:
                    writer.Write((string)tag);
                    break;
            }
        }
    }
}
