using System.Collections.Generic;

namespace Quester.SetConverters
{
    public class HashSetConverter<T> : ISetConverter<T>
    {
        public IEqualityComparer<T> EqualityComparer { get; }

        public HashSetConverter(IEqualityComparer<T> equalityComparer)
        {
            EqualityComparer = equalityComparer;
        }

        public ISet<T> Convert(IEnumerable<T> items) => new HashSet<T>(items, EqualityComparer);
    }
}