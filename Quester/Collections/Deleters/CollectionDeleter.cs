using System.Collections.Generic;
using Quester.Io.Inputs;
using Quester.Io.Outputs;

namespace Quester.Collections.Deleters
{
    public class CollectionDeleter<T> : IDeleter<T>
    {
        public IInput<ICollection<T>> Input { get; }
        public IOutput<IEnumerable<T>> Output { get; }

        public CollectionDeleter(
            IInput<ICollection<T>> input,
            IOutput<IEnumerable<T>> output)
        {
            Input = input;
            Output = output;
        }

        public void Delete(T itemToDelete)
        {
            var items = Input.Get();
            items.Remove(itemToDelete);
            Output.Set(items);
        }
    }
}