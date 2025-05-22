namespace BinaryObjectNotation.IO
{
    internal class CompoundTagSerializer : ITagSerializer<CompoundTag>
    {
        public ITagSerializer<Tag> TagSerializer { get; set; }

        public CompoundTagSerializer(ITagSerializer<Tag> tagSerializer) 
        {
            TagSerializer = tagSerializer;
        }

        public void Serialize(CompoundTag tag, IWriter writer)
        {
            writer.Write(tag.Count);

            foreach (KeyValuePair<string, Tag> pair in tag) 
            {
                writer.Write(pair.Key);
                TagSerializer.Serialize(pair.Value, writer);
            }
        }
    }
}
