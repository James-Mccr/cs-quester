using System.Collections.Generic;

namespace Common.Collections.Readers
{
    public interface IReader<T>
    {
        IEnumerable<T> Read();
    }
}