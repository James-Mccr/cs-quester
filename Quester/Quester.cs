using System;
using Quester.QuestCollections;
using Quester.QuestReaders;
using Quester.QuestWriters;

namespace Quester
{
    public class Quester
    {
        public IQuestCollection QuestCollection { get; }
        public IQuestReader QuestReader { get; }
        public IQuestWriter QuestWriter { get; }

        public Quester(IQuestCollection questCollection, IQuestReader questReader, IQuestWriter questWriter)
        {
            QuestCollection = questCollection ?? throw new ArgumentNullException(nameof(QuestCollection));
            QuestReader = questReader ?? throw new ArgumentNullException(nameof(QuestReader));
            QuestWriter = questWriter ?? throw new ArgumentNullException(nameof(QuestWriter));
        }
    }
}