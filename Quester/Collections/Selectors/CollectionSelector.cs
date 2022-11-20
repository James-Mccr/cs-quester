using System.Collections.Generic;
using System.Linq;
using Quester.Identities;

namespace Quester.Collections.Selectors
{
    public class CollectionSelector<T> : ISelector<T> where T : IIdentifier
    {
        public T Select(IEnumerable<T> items, IIdentifier item) => items.FirstOrDefault(i => i.Id == item.Id);
    }
}