using System.Collections.Generic;
using Common.Identities.Priorities;

namespace Common.Identities.Shifters
{
    public class PriorityShifter : IShifter<IPriority>
    {
        public int Increment { get; }

        public PriorityShifter(int increment)
        {
            Increment = increment;
        }

        public void Shift(IEnumerable<IPriority> items, IPriority lower, IPriority upper)
        {        
            foreach (var item in items)
            {
                if (item.Priority >= lower.Priority && item.Priority <= upper.Priority)
                {
                    item.Priority += Increment;
                }
            }
        }
    }
}