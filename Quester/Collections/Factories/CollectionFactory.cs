using System.Collections.Generic;

namespace Quester.Collections.Factories
{
    public class CollectionFactory<T> : IFactory<ICollection<T>>
    {
        public ICollection<T> Make() => new List<T>();
    }
}