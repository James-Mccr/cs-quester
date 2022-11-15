using Newtonsoft.Json;
using Quester.DefaultValueConverters;
using Quester.Serialiser;

namespace Quester.Serialisers
{
    public class JsonSerialiser<T> : ISerialiser<T>
    {
        public JsonSerializerSettings Settings { get; }
        public IDefaultValueConverter<T> DefaultValueConverter { get; }

        public JsonSerialiser(JsonSerializerSettings settings, IDefaultValueConverter<T> defaultValueConverter)
        {
            Settings = settings;
            DefaultValueConverter = defaultValueConverter;
        }

        public string Serialise(T value) => JsonConvert.SerializeObject(value, Settings);

        public T Deserialise(string s) 
        {
            var result = JsonConvert.DeserializeObject<T>(s, Settings);
            return DefaultValueConverter.Convert(result);
        }
    }
}