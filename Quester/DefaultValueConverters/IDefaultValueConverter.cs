namespace Quester.DefaultValueConverters
{
    public interface IDefaultValueConverter<T>
    {
        T Convert(T item);
    }
}