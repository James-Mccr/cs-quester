using System.Collections.Generic;
using Quester.Models;

namespace Quester.QuestReaders
{
    public interface IQuestReader
    {
        IEnumerable<Quest> Read();
    }
}