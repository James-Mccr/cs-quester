using System.Collections.Generic;

namespace Quester.Collections.Sorters
{
    public class CollectionSorter<T> : ISorter<T>
    {
        public IComparer<T> Comparer { get; }

        public CollectionSorter(IComparer<T> comparer)
        {
            Comparer = comparer;
        }

        public IEnumerable<T> Sort(IEnumerable<T> items)
        {
            var list = new List<T>(items);
            list.Sort(Comparer);
            return list;
        }
    }
}