namespace Quester.Factories
{
    public interface IFactory<T>
    {
        T Make();
    }
}