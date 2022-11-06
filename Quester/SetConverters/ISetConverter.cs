using System.Collections.Generic;

namespace Quester.SetConverters
{
    public interface ISetConverter<T>
    {
        ISet<T> Convert(IEnumerable<T> items);
    }
}