using System.Collections.Generic;
using Newtonsoft.Json;
using Quester.Models;

namespace Quester.QuestSerialisers
{
    public class JsonQuestSerialiser : IQuestSerialiser
    {
        public JsonSerializerSettings Settings { get; }

        public JsonQuestSerialiser(JsonSerializerSettings settings)
        {
            Settings = settings;
        }

        public string Serialise(IEnumerable<Quest> quests) => JsonConvert.SerializeObject(quests, Settings);

        public IEnumerable<Quest> Deserialise(string s) => JsonConvert.DeserializeObject<IEnumerable<Quest>>(s, Settings);
    }
}