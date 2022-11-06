using System.Collections.Generic;
using System.IO;
using Quester.Models;
using Quester.RewardSerialisers;

namespace Quester.RewardWriters
{
    public class JsonRewardWriter : IRewardWriter
    {
        public IRewardSerialiser RewardSerialiser { get; }
        public TextWriter TextWriter { get; }

        public JsonRewardWriter(IRewardSerialiser rewardSerialiser, TextWriter textWriter)
        {
            RewardSerialiser = rewardSerialiser;
            TextWriter = textWriter;
        }

        public void Write(IEnumerable<Reward> rewards)
        {
            var json = RewardSerialiser.Serialise(rewards);
            TextWriter.Write(json);
        }
    }
}