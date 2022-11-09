namespace Quester.Serialiser
{
    public interface ISerialiser<T>
    {
        string Serialise(T value);

        T Deserialise(string s);
    }
}