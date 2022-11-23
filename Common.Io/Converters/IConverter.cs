namespace Common.Io.Converters
{
    public interface IConverter<T>
    {
        T Convert(T item);
    }
}