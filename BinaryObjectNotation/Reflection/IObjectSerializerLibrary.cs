using System.Reflection;

namespace BinaryObjectNotation.Reflection
{
    public interface IObjectSerializerLibrary
    {
        IObjectSerializer? GetSerializer(Type type);
        void AddSerializer(TypeSettings typeSettings, IObjectSerializer serializer);
    }

    public class ObjectSerializerLibrary : IObjectSerializerLibrary
    {
        private IDictionary<Type, IObjectSerializer> _serializers;

        public ObjectSerializerLibrary() 
        {
            _serializers = new Dictionary<Type, IObjectSerializer>(32);
            AddDefaultSerializers();
        }

        private void AddDefaultSerializers() 
        {
            Add(typeof(byte), obj => (byte)obj);
            Add(typeof(byte[]), obj => (byte[])obj);
            Add(typeof(short), obj => (short)obj);
            Add(typeof(short[]), obj => (short[])obj);
            Add(typeof(ushort), obj => (ushort)obj);
            Add(typeof(ushort[]), obj => (ushort[])obj);
            Add(typeof(int), obj => (int)obj);
            Add(typeof(int[]), obj => (int[])obj);
            Add(typeof(uint), obj => (uint)obj);
            Add(typeof(uint[]), obj => (uint[])obj);
            Add(typeof(long), obj => (long)obj);
            Add(typeof(long[]), obj => (long[])obj);
            Add(typeof(ulong), obj => (ulong)obj);
            Add(typeof(ulong[]), obj => (ulong[])obj);
            Add(typeof(float), obj => (float)obj);
            Add(typeof(float[]), obj => (float[])obj);
            Add(typeof(double), obj => (double)obj);
            Add(typeof(double[]), obj => (double[])obj);
            Add(typeof(char), obj => (char)obj);
            Add(typeof(char[]), obj => (char[])obj);
            Add(typeof(string), obj => (string)obj);
            Add(typeof(string[]), obj => (string[])obj);
            Add(typeof(Tag), obj => (Tag)obj);

            void Add(TypeSettings typeSettings, Func<object, Tag> function)
            {
                _serializers.Add(typeSettings.AcceptedType, new FunctionalObjectSerializer(function));
            }

            AddSerializer(typeof(Item), new ObjectSerializer());
        }

        public IObjectSerializer? GetSerializer(Type type)
        {
            _serializers.TryGetValue(type, out IObjectSerializer? serializer);
            return serializer;
        }

        public void AddSerializer(TypeSettings typeSettings, IObjectSerializer serializer)
        {
            _serializers.Add(typeSettings.AcceptedType, serializer);
        }
    }

    public interface IObjectSerializer
    {
        Tag? Serialize(object parentObj, PropertyInfo property, BonSerializer caller);
    }

    public class FunctionalObjectSerializer : IObjectSerializer
    {
        public Func<object, Tag> Function { get; set; }

        public FunctionalObjectSerializer(Func<object, Tag> function) 
        {
            Function = function;
        }

        public Tag? Serialize(object parentObj, PropertyInfo property, BonSerializer caller)
        {
            object? value = property.GetValue(parentObj);
            if (value is null) return null;

            return Function(value);
        }
    }

    public readonly struct TypeSettings 
    {
        public Type AcceptedType { get; init; }
        public bool IsAssignable { get; init; }
        public Type? AssignableForm { get; init; }

        public static implicit operator TypeSettings(Type acceptedType) => new(acceptedType);

        public TypeSettings(Type acceptedType, bool isAssignable = false, Type? assignableForm = null) 
        {
            AcceptedType = acceptedType;
            IsAssignable = isAssignable;
            AssignableForm = assignableForm;
        }
    }
}
