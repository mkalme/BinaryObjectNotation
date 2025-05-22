namespace BinaryObjectNotation
{
    internal static class TagStringifier
    {
        public static string? InternalValueToString(TagId id, object? internalValue) 
        {
            if (internalValue is null) return null;

            switch (id)
            {
                case TagId.Byte:
                case TagId.ByteArray:
                case TagId.Int16:
                case TagId.Int16Array:
                case TagId.UInt16:
                case TagId.UInt16Array:
                case TagId.Int32:
                case TagId.Int32Array:
                case TagId.UInt32:
                case TagId.UInt32Array:
                case TagId.Int64:
                case TagId.Int64Array:
                case TagId.UInt64:
                case TagId.UInt64Array:
                case TagId.Single:
                case TagId.SingleArray:
                case TagId.Double:
                case TagId.DoubleArray:
                case TagId.BooleanArray:
                case TagId.Boolean: return internalValue.ToString();
                case TagId.Char:
                case TagId.CharArray: return $"'{internalValue}'";
                case TagId.String:
                case TagId.StringArray: return $"\"{internalValue}\"";
            }

            return null;
        }

        public static string PadLeftAllLines(string text, string padding, bool skipFirstLine = true)
        {
            string[] lines = text.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                if (skipFirstLine && i == 0) continue;

                lines[i] = $"{padding}{lines[i]}";
            }

            return string.Join('\n', lines);
        }
    }
}
