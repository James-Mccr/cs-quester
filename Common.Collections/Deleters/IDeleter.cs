using System.Collections.Generic;

namespace Common.Collections.Deleters
{
    public interface IDeleter<T>
    {
        void Delete(ICollection<T> items, IEnumerable<T> itemsToDelete);
    }
}