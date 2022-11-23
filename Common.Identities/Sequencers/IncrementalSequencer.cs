using System.Collections.Generic;
using System.Linq;
using Common.Identities.Identifiers;

namespace Common.Identities.Sequencers
{
    public class IncrementalSequencer : ISequencer<IIdentifier>
    {
        public int Increment { get; }

        public IncrementalSequencer(int increment = 1)
        {
            Increment = increment;
        }

        public IIdentifier Next(IEnumerable<IIdentifier> items) => (items.Count() == 0
            ? new Identifier(0)
            : new Identifier(items.Max(q => q.Id) + Increment));
    }
}