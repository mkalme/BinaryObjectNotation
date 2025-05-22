namespace BinaryObjectNotation.IO
{
    public interface ITagDeserializer<TTag> where TTag : Tag
    {
        TTag? Deserialize(IReader reader);
    }
}
