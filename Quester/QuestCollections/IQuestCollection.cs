using System.Collections.Generic;
using Quester.Models;

namespace Quester.QuestCollections
{
    public interface IQuestCollection
    {
        void Add(IEnumerable<Quest> quests);
        void Remove(IEnumerable<Quest> quests);
        IEnumerable<Quest> Quests { get; }
    }
}