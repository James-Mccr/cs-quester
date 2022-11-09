namespace Quester.Readers
{
    public interface IReader<T>
    {
        T Read();
    }
}