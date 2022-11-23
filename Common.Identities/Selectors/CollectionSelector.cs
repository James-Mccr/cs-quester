using System.Collections.Generic;
using System.Linq;
using Common.Identities.Identifiers;

namespace Common.Identities.Selectors
{
    public class CollectionSelector<T> : ISelector<T> where T : IIdentifier
    {
        public T Select(IEnumerable<T> items, IIdentifier item) => items.FirstOrDefault(i => i.Id == item.Id);
    }
}