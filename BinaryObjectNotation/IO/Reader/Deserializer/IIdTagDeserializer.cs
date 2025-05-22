namespace BinaryObjectNotation.IO
{
    public interface IIdTagDeserializer<TTag> where TTag : Tag
    {
        TTag? Deserialize(TagId id, IReader reader);
    }
}
