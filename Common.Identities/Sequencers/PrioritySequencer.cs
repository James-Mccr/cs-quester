using System.Collections.Generic;
using System.Linq;
using Common.Identities.Priorities;

namespace Common.Identities.Sequencers
{
    public class PrioritySequencer : ISequencer<IPriority>
    {
        public int Increment { get; }

        public PrioritySequencer(int increment = 1)
        {
            Increment = increment;
        }

        public IPriority Next(IEnumerable<IPriority> items) => items.Count() == 0
            ? new BasicPriority(1)
            : new BasicPriority(items.Max(i => i.Priority) + Increment);
    }
}