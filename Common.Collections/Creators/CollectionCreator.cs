using System.Collections.Generic;

namespace Common.Collections.Creators
{
    public class CollectionCreator<T> : ICreator<T>
    {
        public void Create(ICollection<T> items, IEnumerable<T> itemsToCreate)
        {
            foreach (var item in itemsToCreate)
            {
                items.Add(item);
            }
        }
    }
}