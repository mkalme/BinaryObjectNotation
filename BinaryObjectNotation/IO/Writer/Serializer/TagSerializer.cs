namespace BinaryObjectNotation.IO
{
    public class TagSerializer : ITagSerializer<Tag>
    {
        public ITagSerializer<ValueTag> ValueTagSerializer { get; set; }
        public ITagSerializer<CompoundTag> CompoundTagSerializer { get; set; }
        public ITagSerializer<ArrayTag> ArrayTagSerializer { get; set; }

        public TagSerializer() 
        {
            ValueTagSerializer = new ValueTagSerializer();
            CompoundTagSerializer = new CompoundTagSerializer(this);
            ArrayTagSerializer = new ArrayTagSerializer(CompoundTagSerializer);
        }

        public void Serialize(Tag tag, IWriter writer)
        {
            writer.Write((byte)tag.Id);

            switch (tag) 
            {
                case ValueTag valueTag:
                    ValueTagSerializer.Serialize(valueTag, writer);
                    break;
                case CompoundTag compoundTag:
                    CompoundTagSerializer.Serialize(compoundTag, writer);
                    break;
                case ArrayTag arrayTag:
                    ArrayTagSerializer.Serialize(arrayTag, writer);
                    break;
            }
        }
    }
}
