using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BinaryObjectNotation
{
    public sealed class CompoundTag : Tag, IDictionary<string, Tag>
    {
        private readonly Dictionary<string, Tag> _internalCollection;

        public ICollection<string> Keys => _internalCollection.Keys;
        public ICollection<Tag> Values => _internalCollection.Values;

        public int Count => _internalCollection.Count;
        public bool IsReadOnly => false;

        public Tag this[string key]
        {
            get => _internalCollection[key];
            set => _internalCollection[key] = value;
        }

        public CompoundTag() : this(2) { }
        public CompoundTag(int capacity) : base(TagId.Compound)
        {
            _internalCollection = new Dictionary<string, Tag>(capacity);
        }
        public CompoundTag(IDictionary<string, Tag> internalCopy) : base(TagId.Compound)
        {
            _internalCollection = new Dictionary<string, Tag>(internalCopy);
        }

        public void Add(string key, Tag value)
        {
            _internalCollection.Add(key, value);
        }
        public void Add(KeyValuePair<string, Tag> item)
        {
            _internalCollection.Add(item.Key, item.Value);
        }

        public bool Contains(KeyValuePair<string, Tag> item)
        {
            return _internalCollection.Contains(item);
        }
        public bool ContainsKey(string key)
        {
            return _internalCollection.ContainsKey(key);
        }
        public bool TryGetValue(string key, [MaybeNullWhen(false)] out Tag value)
        {
            return _internalCollection.TryGetValue(key, out value);
        }

        public void CopyTo(KeyValuePair<string, Tag>[] array, int arrayIndex)
        {
            ((IDictionary<string, Tag>)_internalCollection).CopyTo(array, arrayIndex);
        }

        public bool Remove(string key)
        {
            return _internalCollection.Remove(key);
        }
        public bool Remove(KeyValuePair<string, Tag> item)
        {
            return _internalCollection.Remove(item.Key);
        }
        public void Clear()
        {
            _internalCollection.Clear();
        }

        public IEnumerator<KeyValuePair<string, Tag>> GetEnumerator()
        {
            return _internalCollection.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override bool Equals(Tag? other)
        {
            if(other is null || other is not CompoundTag compoundTag || compoundTag.Count != Count) return false;

            SortedDictionary<string, Tag> first = new SortedDictionary<string, Tag>(_internalCollection);
            SortedDictionary<string, Tag> second = new SortedDictionary<string, Tag>(compoundTag._internalCollection);

            for (int i = 0; i < Count; i++) 
            {
                KeyValuePair<string, Tag> firstPair = first.ElementAt(i);
                KeyValuePair<string, Tag> secondPair = second.ElementAt(i);

                if (!firstPair.Key.Equals(secondPair.Key)) return false;
                if (!firstPair.Value.Equals(secondPair.Value)) return false;
            }

            return true;
        }

        public override object Clone()
        {
            CompoundTag output = new CompoundTag(_internalCollection.Count);

            foreach (KeyValuePair<string, Tag> pair in _internalCollection) 
            {
                output.Add(pair);
            }

            return output;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{");

            for (int i = 0; i < _internalCollection.Count; i++) 
            {
                KeyValuePair<string, Tag> pair = _internalCollection.ElementAt(i);

                string value = pair.Value.ToString();
                value = TagStringifier.PadLeftAllLines(value, "\t");

                builder.Append($"\t{NameToString(pair.Key, pair.Value)}: {value}");

                if (i < _internalCollection.Count - 1) builder.Append(", ");
                builder.AppendLine();
            }

            builder.Append("}");
            return builder.ToString();
        }
        private static string? NameToString(string name, Tag tag)
        {
            return $"\"{name}\" ({tag.Id})";
        }
    }
}
