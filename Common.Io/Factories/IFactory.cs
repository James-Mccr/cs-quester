namespace Common.Io.Factories
{
    public interface IFactory<T>
    {
        T Make();
    }
}