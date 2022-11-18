using System.Collections.Generic;
using Quester.Io.Inputs;

namespace Quester.Collections.Readers
{
    public class CollectionReader<T> : IReader<T>
    {
        public IInput<ICollection<T>> Input { get; }

        public CollectionReader(IInput<ICollection<T>> input)
        {
            Input = input;
        }

        public IEnumerable<T> Read() => Input.Get();
    }
}