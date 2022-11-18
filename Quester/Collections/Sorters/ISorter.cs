using System.Collections.Generic;

namespace Quester.Collections.Sorters
{
    public interface ISorter<T>
    {
        IEnumerable<T> Sort(IEnumerable<T> items);
    }
}