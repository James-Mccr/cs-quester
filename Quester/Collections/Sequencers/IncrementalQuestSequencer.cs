using System.Collections.Generic;
using System.Linq;
using Quester.Collections.Utilities;
using Quester.Quests;

namespace Quester.Collections.Sequencers
{
    public class IncrementalQuestSequencer : ISequencer<Quest>
    {
        public int Increment { get; }

        public IncrementalQuestSequencer(int increment = 1)
        {
            Increment = increment;
        }

        public Quest Next(IEnumerable<Quest> quests) => quests.IsEmpty()
            ? new Quest(0, 0, null, false)
            : new Quest(quests.Max(q => q.Id) + Increment, 0, null, false);
    }
}