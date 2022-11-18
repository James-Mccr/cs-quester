using System.Collections.Generic;
using Quester.Io.Inputs;
using Quester.Io.Outputs;

namespace Quester.Collections.Updaters
{
    public class CollectionUpdater<T> : IUpdater<T>
    {
        public IInput<ICollection<T>> Input { get; }
        public IOutput<IEnumerable<T>> Output { get; }
        public IEqualityComparer<T> EqualityComparer { get; }

        public CollectionUpdater(
            IInput<ICollection<T>> input,
            IOutput<IEnumerable<T>> output,
            IEqualityComparer<T> equalityComparer)
        {
            Input = input;
            Output = output;
            EqualityComparer = equalityComparer;
        }

        public void Update(T itemToUpdate)
        {
            var items = Input.Get();
            foreach (var item in items)
            {
                if (EqualityComparer.Equals(itemToUpdate, item))
                {
                    items.Remove(item);
                    items.Add(itemToUpdate);
                    Output.Set(items);
                    break;
                }
            }
        }
    }
}