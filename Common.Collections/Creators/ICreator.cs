namespace Common.Collections.Creators
{
    public interface ICreator<T>
    {
        void Create(T item);
    }
}