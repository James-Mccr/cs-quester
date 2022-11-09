namespace Quester.Writers
{
    public interface IWriter<T>
    {
        void Write(T value);
    }
}