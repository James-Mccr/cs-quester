using System.Collections.Generic;

namespace Quester.SetSelectors
{
    public interface ISetSelector<T>
    {
        T Select(ISet<T> items, int id);
    }
}