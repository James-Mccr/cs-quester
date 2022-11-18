using System.Collections.Generic;

namespace Quester.Collections.Readers
{
    public interface IReader<T>
    {
        IEnumerable<T> Read();
    }
}