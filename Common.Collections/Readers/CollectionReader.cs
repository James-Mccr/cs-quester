using System.Collections.Generic;

namespace Common.Collections.Readers
{
    public class CollectionReader<T> : IReader<T>
    {
        public CollectionReader(ICollection<T> collection)
        {
            Collection = collection;
        }

        public ICollection<T> Collection { get; }

        public ICollection<T> Read() => Collection;
    }
}