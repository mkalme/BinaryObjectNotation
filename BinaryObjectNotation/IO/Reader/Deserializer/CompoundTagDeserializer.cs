namespace BinaryObjectNotation.IO
{
    public class CompoundTagDeserializer : ITagDeserializer<CompoundTag>
    {
        public ITagDeserializer<Tag> TagDeserializer { get; set; }

        public CompoundTagDeserializer(ITagDeserializer<Tag> tagDeserializer) 
        {
            TagDeserializer = tagDeserializer;
        }

        public CompoundTag? Deserialize(IReader reader)
        {
            int length = reader.ReadInt32();

            CompoundTag output = new CompoundTag();
            for (int i = 0; i < length; i++) 
            {
                string name = reader.ReadString();
                Tag? child = TagDeserializer.Deserialize(reader);

                if (child is null) continue;

                output.Add(name, child);
            }

            return output;
        }
    }
}
