using System.Collections.Generic;
using Quester.Identities;

namespace Quester.Collections.Selectors
{
    public interface ISelector<T> where T : IIdentifier
    {
        T Select(IEnumerable<T> items, IIdentifier item);
    }
}