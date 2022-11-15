namespace Quester.Updaters
{
    public interface IUpdater<T1, T2>
    {
        bool Update(T1 key, T2 value);
    }
}