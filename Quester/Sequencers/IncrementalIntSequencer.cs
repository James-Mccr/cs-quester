using System.Collections.Generic;
using System.Linq;
using Quester.Utilities;

namespace Quester.Sequencers
{
    public class IncrementalIntSequencer : ISequencer<int>
    {
        public int Increment { get; }

        public IncrementalIntSequencer(int increment = 1)
        {
            Increment = increment;
        }

        public int Next(IEnumerable<int> ints) => ints.IsEmpty() ? 0 : ints.Max() + Increment;
    }
}