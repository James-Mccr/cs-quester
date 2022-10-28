using System.Collections.Generic;
using Quester.Models;

namespace Quester.QuestSerialisers
{
    public interface IQuestSerialiser
    {
        string Serialise(IEnumerable<Quest> quests);

        IEnumerable<Quest> Deserialise(string s);
    }
}