using System.Collections.Generic;

namespace Common.Io.Factories
{
    public class CollectionFactory<T> : IFactory<ICollection<T>>
    {
        public ICollection<T> Make() => new List<T>();
    }
}