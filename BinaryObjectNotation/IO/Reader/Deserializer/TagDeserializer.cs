namespace BinaryObjectNotation.IO
{
    public class TagDeserializer : ITagDeserializer<Tag>
    {
        public IIdTagDeserializer<Tag> IdTagDeserializer { get; set; }

        public TagDeserializer()
        {
            IdTagDeserializer = new IdTagDeserializer(this);
        }

        public Tag? Deserialize(IReader reader)
        {
            TagId id = (TagId)reader.ReadByte();
            return IdTagDeserializer.Deserialize(id, reader);
        }
    }
}
