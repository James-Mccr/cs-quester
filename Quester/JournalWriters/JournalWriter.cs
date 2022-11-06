using Quester.Models;
using Quester.RewardWriters;
using Quester.LevelWriters;
using Quester.QuestWriters;

namespace Quester.JournalWriters
{
    public class JournalWriter : IJournalWriter
    {
        public IQuestWriter QuestWriter { get; }
        public IRewardWriter RewardWriter { get; }
        public ILevelWriter LevelWriter { get; }
    
        public JournalWriter(IQuestWriter questWriter, IRewardWriter rewardWriter, ILevelWriter levelWriter)
        {
            QuestWriter = questWriter;
            RewardWriter = rewardWriter;
            LevelWriter = levelWriter;
        }

        public void Write(Journal journal)
        {
            QuestWriter.Write(journal.Quests);
            RewardWriter.Write(journal.Rewards);
            LevelWriter.Write(journal.Level);
        }
    }
}