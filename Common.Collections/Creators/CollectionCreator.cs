using System.Collections.Generic;
using Common.Io.Inputs;
using Common.Io.Outputs;

namespace Common.Collections.Creators
{
    public class CollectionCreator<T> : ICreator<T>
    {
        public IInput<ICollection<T>> Input { get; }
        public IOutput<IEnumerable<T>> Output { get; }

        public CollectionCreator(IInput<ICollection<T>> input, IOutput<IEnumerable<T>> output)
        {
            Input = input;
            Output = output;
        }

        public void Create(T item)
        {
            var items = Input.Get();
            items.Add(item);
            Output.Set(items);
        }
    }
}