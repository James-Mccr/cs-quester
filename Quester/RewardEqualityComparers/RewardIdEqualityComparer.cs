using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Quester.Models;

namespace Quester.RewardEqualityComparers
{
    public class RewardIdEqualityComparer : IEqualityComparer<Reward>
    {
        public bool Equals(Reward x, Reward y)
        {
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;
            if (ReferenceEquals(x, y))
                return true;
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Reward obj) => obj.Id;
    }
}