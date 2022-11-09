using System;
using Quester.Serialiser;

namespace Quester.Readers
{
    public class JsonReader<T> : IReader<T>
    {
        public IReader<string> StringReader { get; }
        public ISerialiser<T> Serialiser { get; }

        public JsonReader(IReader<string> stringReader, ISerialiser<T> serialiser)
        {
            StringReader = stringReader;
            Serialiser = serialiser ?? throw new ArgumentNullException(nameof(Serialiser));
        }

        public T Read()
        {
            string json = StringReader.Read();
            return Serialiser.Deserialise(json);
        }
    }
}