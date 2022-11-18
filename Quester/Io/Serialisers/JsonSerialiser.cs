using Newtonsoft.Json;
using Quester.Collections.Converters;

namespace Quester.Io.Serialisers
{
    public class JsonSerialiser<T> : ISerialiser<T>
    {
        public JsonSerializerSettings Settings { get; }
        public IConverter<T> DefaultValueConverter { get; }

        public JsonSerialiser(JsonSerializerSettings settings, IConverter<T> defaultValueConverter)
        {
            Settings = settings;
            DefaultValueConverter = defaultValueConverter;
        }

        public string Serialise(T value) => JsonConvert.SerializeObject(value, Settings);   // TODO separate serialise and deserialise

        public T Deserialise(string s)
        {
            var result = JsonConvert.DeserializeObject<T>(s, Settings);
            return DefaultValueConverter.Convert(result);
        }
    }
}