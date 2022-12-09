using System.Collections.Generic;

namespace Common.Collections.Deleters
{
    public class CollectionDeleter<T> : IDeleter<T>
    {
        public void Delete(ICollection<T> items, IEnumerable<T> itemsToDelete) 
        {
            foreach (var item in itemsToDelete)
            {
                items.Remove(item);
            }
        }
    }
}