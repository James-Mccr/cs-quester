namespace Quester.Deleters
{
    public interface IDeleter<T>
    {
        bool Delete(T item);
    }
}