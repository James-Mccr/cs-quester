namespace Common.Io.Serialisers
{
    public interface ISerialiser<T>
    {
        string Serialise(T value);

        T Deserialise(string s);
    }
}