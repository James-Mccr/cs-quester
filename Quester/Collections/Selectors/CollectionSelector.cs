using System.Linq;
using Quester.Collections.Readers;
using Quester.Collections.Sorters;

namespace Quester.Collections.Selectors
{
    public class CollectionSelector<T> : ISelector<T>
    {
        public IReader<T> Reader { get; }
        public ISorter<T> Sorter { get; }
        
        public CollectionSelector(IReader<T> reader, ISorter<T> sorter)
        {
            Reader = reader;
            Sorter = sorter;
        }

        public T Select(int index)
        {
            var items = Reader.Read();
            items = Sorter.Sort(items);
            return items.ElementAt(index);
        }
    }
}