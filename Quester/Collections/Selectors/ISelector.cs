namespace Quester.Collections.Selectors
{
    public interface ISelector<T>
    {
        T Select(int index);
    }
}