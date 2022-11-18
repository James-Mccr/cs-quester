using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Quester.Quests;

namespace Quester.Comparisons.EqualityComparers
{
    public class QuestEqualityComparer : IEqualityComparer<Quest>
    {
        public bool Equals(Quest x, Quest y)
        {
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;
            if (ReferenceEquals(x, y))
                return true;
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Quest obj)
        {
            throw new System.NotImplementedException();
        }
    }
}