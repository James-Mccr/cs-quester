using System;
using System.Collections.Generic;
using Quester.Models;

namespace Quester.QuestCollections
{
    public class UniqueQuestCollection : IQuestCollection
    {
        private ISet<Quest> QuestSet { get; }
        public IEnumerable<Quest> Quests => QuestSet;

        public UniqueQuestCollection(ISet<Quest> quests)
        {
            QuestSet = quests ?? throw new ArgumentNullException(nameof(Quests));
        }

        public void Add(IEnumerable<Quest> quests)
        {
            foreach (var quest in quests)
            {
                QuestSet.Add(quest);
            }
        }

        public void Remove(IEnumerable<Quest> quests)
        {
            foreach (var quest in quests)
            {
                QuestSet.Remove(quest);
            }
        }
    }
}