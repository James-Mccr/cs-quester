using Quester.LevelReaders;
using Quester.Models;
using Quester.QuestReaders;
using Quester.RewardReaders;
using Quester.SetConverters;

namespace Quester.JournalReaders
{
    public class JournalReader : IJournalReader
    {
        public IQuestReader QuestReader { get; }
        public IRewardReader RewardReader { get; }
        public ILevelReader LevelReader { get; }
        public ISetConverter<Quest> QuestSetConverter { get; }
        public ISetConverter<Reward> RewardSetConverter { get; }

        public JournalReader(
            IQuestReader questReader,
            IRewardReader rewardReader,
            ILevelReader levelReader,
            ISetConverter<Quest> questSetConverter,
            ISetConverter<Reward> rewardSetConverter)
        {
            QuestReader = questReader;
            RewardReader = rewardReader;
            LevelReader = levelReader;
            QuestSetConverter = questSetConverter;
            RewardSetConverter = rewardSetConverter;
        }

        public Journal Read()
        {
            var quests = QuestReader.Read();
            var questSet = QuestSetConverter.Convert(quests);
            var rewards = RewardReader.Read();
            var rewardSet = RewardSetConverter.Convert(rewards);
            var level = LevelReader.Read();
            return new Journal(questSet, rewardSet, level);
        }
    }
}