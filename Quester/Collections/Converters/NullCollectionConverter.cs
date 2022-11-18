using System.Collections.Generic;
using Quester.Collections.Factories;

namespace Quester.Collections.Converters
{
    public class NullCollectionConverter<T> : IConverter<ICollection<T>>
    {
        public IFactory<ICollection<T>> Factory { get; }

        public NullCollectionConverter(IFactory<ICollection<T>> factory)
        {
            Factory = factory;
        }

        public ICollection<T> Convert(ICollection<T> items) => items ?? Factory.Make();
    }
}