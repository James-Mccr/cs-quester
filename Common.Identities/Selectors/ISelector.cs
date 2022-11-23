using System.Collections.Generic;
using Common.Identities.Identifiers;

namespace Common.Identities.Selectors
{
    public interface ISelector<T> where T : IIdentifier
    {
        T Select(IEnumerable<T> items, IIdentifier item);
    }
}