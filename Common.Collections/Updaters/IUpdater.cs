namespace Common.Collections.Updaters
{
    public interface IUpdater<T>
    {
        void Update(T item);
    }
}