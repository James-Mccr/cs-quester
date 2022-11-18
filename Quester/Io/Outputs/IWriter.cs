namespace Quester.Io.Outputs
{
    public interface IOutput<T>
    {
        void Set(T value);
    }
}