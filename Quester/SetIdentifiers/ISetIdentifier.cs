using System.Collections.Generic;

namespace Quester.SetIdentifiers
{
    public interface ISetIdentifier<T>
    {
        int NextId(ISet<T> items);
    }
}