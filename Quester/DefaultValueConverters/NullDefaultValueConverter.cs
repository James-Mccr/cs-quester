using Quester.Factories;

namespace Quester.DefaultValueConverters
{
    public class NullDefaultValueConverter<T> : IDefaultValueConverter<T> where T : class
    {
        public IFactory<T> Factory { get; }

        public NullDefaultValueConverter(IFactory<T> factory)
        {
            Factory = factory;
        }

        public T Convert(T item) => item ?? Factory.Make();
    }
}