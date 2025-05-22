namespace BinaryObjectNotation.IO
{
    public interface ITagSerializer<TTag> where TTag : Tag
    {
        void Serialize(TTag tag, IWriter writer);
    }
}
