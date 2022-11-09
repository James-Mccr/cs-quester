using System.Collections.Generic;
using Quester.Models;
using Quester.Readers;
using Quester.SetConverters;

namespace Quester.JournalReaders
{
    public class JournalReader : IJournalReader
    {
        public IReader<IEnumerable<Quest>> QuestsReader { get; }
        public IReader<IEnumerable<Reward>> RewardsReader { get; }
        public IReader<Level> LevelReader { get; }
        public ISetConverter<Quest> QuestSetConverter { get; }
        public ISetConverter<Reward> RewardSetConverter { get; }

        public JournalReader(
            IReader<IEnumerable<Quest>> questsReader,
            IReader<IEnumerable<Reward>> rewardsReader,
            IReader<Level> levelReader,
            ISetConverter<Quest> questSetConverter,
            ISetConverter<Reward> rewardSetConverter)
        {
            QuestsReader = questsReader;
            RewardsReader = rewardsReader;
            LevelReader = levelReader;
            QuestSetConverter = questSetConverter;
            RewardSetConverter = rewardSetConverter;
        }

        public Journal Read()
        {
            var quests = QuestsReader.Read();
            var questSet = QuestSetConverter.Convert(quests);
            var rewards = RewardsReader.Read();
            var rewardSet = RewardSetConverter.Convert(rewards);
            var level = LevelReader.Read();
            return new Journal(questSet, rewardSet, level);
        }
    }
}