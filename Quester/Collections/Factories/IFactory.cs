namespace Quester.Collections.Factories
{
    public interface IFactory<T>
    {
        T Make();
    }
}