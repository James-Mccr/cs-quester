using System.Collections.Generic;

namespace Quester.Factories
{
    public class KeyValueFactory<T1, T2> : IFactory<IDictionary<T1, T2>>
    {
        public IDictionary<T1, T2> Make() => new Dictionary<T1, T2>();
    }
}