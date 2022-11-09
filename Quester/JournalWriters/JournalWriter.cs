using Quester.Models;
using Quester.Writers;
using System.Collections.Generic;

namespace Quester.JournalWriters
{
    public class JournalWriter : IJournalWriter
    {
        public IWriter<IEnumerable<Quest>> QuestsWriter { get; }
        public IWriter<IEnumerable<Reward>> RewardsWriter { get; }
        public IWriter<Level> LevelWriter { get; }
    
        public JournalWriter(IWriter<IEnumerable<Quest>> questsWriter, IWriter<IEnumerable<Reward>> rewardsWriter, IWriter<Level> levelWriter)
        {
            QuestsWriter = questsWriter;
            RewardsWriter = rewardsWriter;
            LevelWriter = levelWriter;
        }

        public void Write(Journal journal)
        {
            QuestsWriter.Write(journal.Quests);
            RewardsWriter.Write(journal.Rewards);
            LevelWriter.Write(journal.Level);
        }
    }
}