using System.Collections.Generic;
using Quester.Models;

namespace Quester.QuestWriters
{
    public interface IQuestWriter
    {
        void Write(IEnumerable<Quest> quests);
    }
}