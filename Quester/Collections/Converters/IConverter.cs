namespace Quester.Collections.Converters
{
    public interface IConverter<T>
    {
        T Convert(T item);
    }
}