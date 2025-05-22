using BinaryObjectNotation;
using BinaryObjectNotation.Reflection;

namespace DemoConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Settings settings = new Settings();
            Tag tag = new BonSerializer().Serialize(settings);

            Console.WriteLine(tag.ToString());

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static Tag CreateTestObject()
        {
            CompoundTag parent = new()
            {
                { "Byte", byte.MaxValue },
                { "ByteArray", new byte[]{ 10, 10 } },
                { "Int16", short.MaxValue },
                { "Int16Array", new short[]{ 10, 10 } },
                { "UInt16", ushort.MaxValue },
                { "UInt16Array", new ushort[]{ 10, 10 } },
                { "Int32", int.MaxValue },
                { "Int32Array", new int[]{ 10, 10 } },
                { "UInt32", uint.MaxValue },
                { "UInt32Array", new uint[]{ 10, 10 } },
                { "Int64", long.MaxValue },
                { "Int64Array", new long[]{ 10, 10 } },
                { "UInt64", ulong.MaxValue },
                { "UInt64Array", new ulong[]{ 10, 10 } },

                { "Single", float.MaxValue },
                { "SingleArray", new float[]{ 10, 10 } },
                { "Double", double.MaxValue },
                { "DoubleArray", new double[]{ 10, 10 } },

                { "Bool", true },
                { "BoolArray", new bool[]{ true, true } },
                { "Char", char.MaxValue },
                { "CharArray", new char[]{ 'z', 'z' } },
                { "String", "12gfdgdfgfd" },
                { "StringArray", new string[]{ "3423432", "6546546" } },

                { "Compound", new CompoundTag() { { "A", 'a' } } },
                { "CompoundArray", new CompoundTag[]{ new CompoundTag() { { "Byte", byte.MaxValue } }, new CompoundTag() { { "Int32", int.MaxValue } } } }
            };

            return parent;
        }
    }
}