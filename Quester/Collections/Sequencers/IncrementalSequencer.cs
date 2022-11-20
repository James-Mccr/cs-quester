using System.Collections.Generic;
using System.Linq;
using Quester.Collections.Utilities;
using Quester.Identities;

namespace Quester.Collections.Sequencers
{
    public class IncrementalSequencer : ISequencer<IIdentifier>
    {
        public int Increment { get; }

        public IncrementalSequencer(int increment = 1)
        {
            Increment = increment;
        }

        public IIdentifier Next(IEnumerable<IIdentifier> items) => (items.IsEmpty()
            ? new Identifier(0)
            : new Identifier(items.Max(q => q.Id) + Increment));
    }
}