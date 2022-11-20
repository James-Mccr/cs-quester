using System;
using Quester.Identities;

namespace Quester.Quests
{
    public class Quest : IIdentifier, IEquatable<Quest>
    {
        public int Id { get; set; }
        public int Reward { get; set; }
        public string Goal { get; set; }
        public bool Complete { get; set; }

        public Quest(int id, int reward, string goal, bool complete)
        {
            Id = id;
            Reward = reward;
            Goal = goal;
            Complete = complete;
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