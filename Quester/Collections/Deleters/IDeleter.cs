namespace Quester.Collections.Deleters
{
    public interface IDeleter<T>
    {
        void Delete(T item);
    }
}