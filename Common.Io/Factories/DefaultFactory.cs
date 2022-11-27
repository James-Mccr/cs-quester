namespace Common.Io.Factories
{
    public class DefaultFactory<T> : IFactory<T> where T : new()
    {
        public T Make() => new T();
    }
}