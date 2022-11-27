using Common.Io.Factories;

namespace Common.Io.Converters
{
    public class NullConverter<T> : IConverter<T>
    {
        public IFactory<T> Factory { get; }
        
        public NullConverter(IFactory<T> factory)
        {
            Factory = factory;
        }

        public T Convert(T item) => item ?? Factory.Make();
    }
}