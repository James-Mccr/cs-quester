using System.Collections.Generic;
using Common.Io.Factories;

namespace Common.Io.Converters
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