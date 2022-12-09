using System.Collections.Generic;
using System.Linq;
using Common.Identities.Priorities;

namespace Common.Identities.Selectors
{
    public class PrioritySelector<T1> : ISelector<T1, IPriority> where T1 : IPriority
    {
        public T1 Select(IEnumerable<T1> items, IPriority item) => items.Single(i => i.Priority == item.Priority);
    }
}