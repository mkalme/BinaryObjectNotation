namespace BinaryObjectNotation.IO
{
    public class ArrayTagSerializer : ITagSerializer<ArrayTag>
    {
        public ITagSerializer<CompoundTag> CompoundTagSerializer { get; set; }

        public ArrayTagSerializer(ITagSerializer<CompoundTag> compoundTagSerializer) 
        {
            CompoundTagSerializer = compoundTagSerializer;
        }

        public void Serialize(ArrayTag tag, IWriter writer)
        {
            writer.Write(tag.Length);

            switch (tag.Id)
            {
                case TagId.ByteArray:
                    writer.Write((byte[])tag);
                    break;
                case TagId.Int16Array:
                    writer.Write((short[])tag);
                    break;
                case TagId.UInt16Array:
                    writer.Write((ushort[])tag);
                    break;
                case TagId.Int32Array:
                    writer.Write((int[])tag);
                    break;
                case TagId.UInt32Array:
                    writer.Write((uint[])tag);
                    break;
                case TagId.Int64Array:
                    writer.Write((long[])tag);
                    break;
                case TagId.UInt64Array:
                    writer.Write((ulong[])tag);
                    break;
                case TagId.SingleArray:
                    writer.Write((float[])tag);
                    break;
                case TagId.DoubleArray:
                    writer.Write((double[])tag);
                    break;
                case TagId.BooleanArray:
                    writer.Write((bool[])tag);
                    break;
                case TagId.CharArray:
                    writer.Write((char[])tag);
                    break;
                case TagId.StringArray:
                    writer.Write((string[])tag);
                    break;
                case TagId.CompoundArray:
                    CompoundTag[] tags = tag;
                    foreach (CompoundTag child in tags) 
                    {
                        CompoundTagSerializer.Serialize(child, writer);
                    }

                    break;
            }
        }
    }
}
