namespace Quester.Creators
{
    public interface ICreator<T1, T2>
    {
        T2 Create(T1 item);
    }
}