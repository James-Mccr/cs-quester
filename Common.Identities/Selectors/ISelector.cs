using System.Collections.Generic;

namespace Common.Identities.Selectors
{
    public interface ISelector<T1, T2>
    {
        T1 Select(IEnumerable<T1> items, T2 item);
    }
}