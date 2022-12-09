using System;
using Common.Identities.Identifiers;
using Common.Identities.Priorities;

namespace Quester
{
    public class Quest : IIdentifier, IPriority, IEquatable<Quest>
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public string Goal { get; set; }

        public Quest(int id, int priority, string goal)
        {
            Id = id;
            Priority = priority;
            Goal = goal;
        }

        public bool Equals(Quest other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Id == other.Id;
        }
    }
}