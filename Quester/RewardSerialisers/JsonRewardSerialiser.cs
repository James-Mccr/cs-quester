using System.Collections.Generic;
using Newtonsoft.Json;
using Quester.Models;

namespace Quester.RewardSerialisers
{
    public class JsonRewardSerialiser : IRewardSerialiser
    {
        public JsonSerializerSettings Settings { get; }

        public JsonRewardSerialiser(JsonSerializerSettings settings)
        {
            Settings = settings;
        }

        public IEnumerable<Reward> Deserialise(string s) => JsonConvert.DeserializeObject<IEnumerable<Reward>>(s);
        public string Serialise(IEnumerable<Reward> rewards) => JsonConvert.SerializeObject(rewards);
    }
}