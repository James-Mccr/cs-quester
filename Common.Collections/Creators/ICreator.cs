using System.Collections.Generic;

namespace Common.Collections.Creators
{
    public interface ICreator<T>
    {
        void Create(ICollection<T> items, IEnumerable<T> itemsToCreate);
    }
}