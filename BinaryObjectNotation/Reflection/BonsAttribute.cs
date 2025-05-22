using System.Numerics;
using System.Reflection;

namespace BinaryObjectNotation.Reflection
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class BonsAttribute : Attribute
    {
        public string? PropertyName { get; set; }
        public IObjectSerializer? Serializer { get; set; }

        public BonsAttribute() {}
        public BonsAttribute(string? propertyName) 
        {
            PropertyName = propertyName;
        }
        public BonsAttribute(Type serializerType)
        {
            object? instance = Activator.CreateInstance(serializerType);
            if(instance is not null) Serializer = instance as IObjectSerializer;
        }
    }

    public class BonsAllowedPropertiesAttribute : Attribute
    {
        public ISet<string> Properties { get; set; }

        public BonsAllowedPropertiesAttribute(params string[] properties) 
        {
            Properties = new HashSet<string>(properties);
        }
    }

    public class BonsIgnoreAttribute : Attribute 
    {
        public BonsIgnore BonsIgnore { get; set; }

        public BonsIgnoreAttribute(BonsIgnore bonsIgnore)
        {
            BonsIgnore = bonsIgnore;
        }
    }
    public class BonsClassOrStructAttribute : Attribute 
    {
        public BonsIgnoreClassOrStruct BonsIgnoreClassOrStruct { get; set; }

        public BonsClassOrStructAttribute(BonsIgnoreClassOrStruct bonsIgnoreClassOrStruct) 
        {
            BonsIgnoreClassOrStruct = bonsIgnoreClassOrStruct;
        }
    }

    public enum BonsIgnore 
    {
        DoNotIgnore,
        Ignore
    }
    public enum BonsIgnoreClassOrStruct
    {
        DoNotIgnoreAll,
        IgnoreAll
    }

    [BonsClassOrStruct(BonsIgnoreClassOrStruct.IgnoreAll)]
    public class Settings
    {
        [Bons]
        public string Path { get; set; } = "";

        [Bons]
        public int Count { get; set; } = 10;

        [Bons]
        public string[] Names { get; set; } = new string[] { "a", "b", "cc" };

        [Bons(typeof(ObjectSerializer))]
        [BonsAllowedProperties("X", "Y", "Z")]
        public Vector3 Position { get; set; }

        [Bons]
        public Item Item { get; set; } = new File();
    }

    public class ObjectSerializer : IObjectSerializer
    {
        public Tag? Serialize(object parentObj, PropertyInfo property, BonSerializer caller)
        {
            object? value = property.GetValue(parentObj, null);
            if(value is null) return null;

            return new CompoundTag()
            {
                { "Type", value.GetType().ToString() },
                { "Object", caller.Serialize(value) }
            };
        }
    }

    public class Item 
    {
        public string Name { get; set; } = "Parent";
    }

    public class File : Item 
    {
        public string Path { get; set; } = "Path";
    }
}
