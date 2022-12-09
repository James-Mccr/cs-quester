using System.Collections.Generic;
using System.Linq;
using Common.Identities.Identifiers;

namespace Common.Identities.Selectors
{
    public class IdentifierSelector<T1> : ISelector<T1, IIdentifier> where T1 : IIdentifier
    {
        public T1 Select(IEnumerable<T1> items, IIdentifier item) => items.Single(i => i.Id == item.Id);
    }
}