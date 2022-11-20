using System.Collections.Generic;
using Quester.Io.Inputs;
using Quester.Io.Outputs;

namespace Quester.Collections.Updaters
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