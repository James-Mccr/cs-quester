using System.Collections.Generic;
using Newtonsoft.Json;
using Quester.Models;

namespace Quester.QuestSerialisers
{
    public class JsonQuestSerialiser : IQuestSerialiser
    {
        public Formatting Format { get; }

        public JsonQuestSerialiser(Formatting format = Formatting.None)
        {
            Format = format;
        }

        public string Serialise(IEnumerable<Quest> quests) => JsonConvert.SerializeObject(quests, Format);
    }
}