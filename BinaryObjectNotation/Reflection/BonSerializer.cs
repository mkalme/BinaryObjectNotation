using System.Reflection;

namespace BinaryObjectNotation.Reflection
{
    public class BonSerializer
    {
        public IObjectSerializerLibrary SerializerLibrary { get; set; }

        public BonSerializer() 
        {
            SerializerLibrary = new ObjectSerializerLibrary();
        }

        public Tag Serialize(object obj) 
        {
            CompoundTag output = new CompoundTag();

            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                SerializeProperty(obj, property, output);
            }

            return output;
        }

        private void SerializeProperty(object parentObj, PropertyInfo property, CompoundTag parentTag) 
        {
            Tag? tag = SerializerLibrary.GetSerializer(property.PropertyType)?.Serialize(parentObj, property, this);

            if (tag is null) return;
            parentTag.Add(property.Name, tag);
        }
    }
}
