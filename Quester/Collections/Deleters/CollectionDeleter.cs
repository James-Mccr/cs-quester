using System.Collections.Generic;
using Quester.Io.Inputs;
using Quester.Io.Outputs;

namespace Quester.Collections.Deleters
{
    public class CollectionDeleter<T> : IDeleter<T>
    {
        public IInput<ICollection<T>> Input { get; }
        public IOutput<IEnumerable<T>> Output { get; }
        public IEqualityComparer<T> EqualityComparer { get; }

        public CollectionDeleter(
            IInput<ICollection<T>> input,
            IOutput<IEnumerable<T>> output,
            IEqualityComparer<T> equalityComparer)
        {
            Input = input;
            Output = output;
            EqualityComparer = equalityComparer;
        }

        public void Delete(T itemToDelete)
        {
            var items = Input.Get();
            foreach (var item in items)
            {
                if (EqualityComparer.Equals(itemToDelete, item))
                {
                    items.Remove(item);
                    break;
                }
                
            }
            Output.Set(items);
        }
    }
}