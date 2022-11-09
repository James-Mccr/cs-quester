using Newtonsoft.Json;
using Quester.Serialiser;

namespace Quester.Serialisers
{
    public class JsonSerialiser<T> : ISerialiser<T>
    {
        public JsonSerializerSettings Settings { get; }

        public JsonSerialiser(JsonSerializerSettings settings)
        {
            Settings = settings;
        }

        public string Serialise(T value) => JsonConvert.SerializeObject(value, Settings);

        public T Deserialise(string s) => JsonConvert.DeserializeObject<T>(s, Settings);
    }
}