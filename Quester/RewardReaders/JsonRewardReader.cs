using System.Collections.Generic;
using System.IO;
using Quester.Models;
using Quester.RewardSerialisers;

namespace Quester.RewardReaders
{
    public class JsonRewardReader : IRewardReader
    {
        public IRewardSerialiser RewardSerialiser { get; }
        public TextReader TextReader { get; }

        public JsonRewardReader(IRewardSerialiser rewardSerialiser, TextReader textReader)
        {
            RewardSerialiser = rewardSerialiser;
            TextReader = textReader;
        }

        public IEnumerable<Reward> Read()
        {
            var json = TextReader.ReadToEnd();
            return RewardSerialiser.Deserialise(json);
        }
    }
}