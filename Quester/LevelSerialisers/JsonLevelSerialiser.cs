using Newtonsoft.Json;
using Quester.Models;

namespace Quester.LevelSerialisers
{
    public class JsonLevelSerialiser : ILevelSerialiser
    {
        public JsonSerializerSettings Setings { get; }

        public JsonLevelSerialiser(JsonSerializerSettings setings)
        {
            Setings = setings;
        }

        public Level Deserialise(string s) => JsonConvert.DeserializeObject<Level>(s);

        public string Serialise(Level level) => JsonConvert.SerializeObject(level);
    }
}