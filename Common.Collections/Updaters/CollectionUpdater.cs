using System.Collections.Generic;
using Common.Io.Inputs;
using Common.Io.Outputs;

namespace Common.Collections.Updaters
{
    public class CollectionUpdater<T> : IUpdater<T>
    {
        public IInput<ICollection<T>> Input { get; }
        public IOutput<IEnumerable<T>> Output { get; }

        public CollectionUpdater(
            IInput<ICollection<T>> input,
            IOutput<IEnumerable<T>> output)
        {
            Input = input;
            Output = output;
        }

        public void Update(T itemToUpdate)
        {
            var items = Input.Get();
            items.Remove(itemToUpdate);
            items.Add(itemToUpdate);
            Output.Set(items);
        }
    }
}