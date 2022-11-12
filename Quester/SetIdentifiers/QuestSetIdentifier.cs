using System.Collections.Generic;
using System.Linq;
using Quester.Models;
using Quester.Utilities;

namespace Quester.SetIdentifiers
{
    public class QuestSetIdentifier : ISetIdentifier<Quest>
    {
        public IComparer<Quest> QuestComparer { get; }

        public QuestSetIdentifier(IComparer<Quest> questComparer)
        {
            QuestComparer = questComparer;
        }

        public int NextId(ISet<Quest> items) => items.IsEmpty() ? 0 : items.Max(QuestComparer).Id + 1;
    }
}