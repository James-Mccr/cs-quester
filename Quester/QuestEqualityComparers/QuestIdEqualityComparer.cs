using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Quester.Models;

namespace Quester.QuestEqualityComparer
{
    public class QuestIdEqualityComparer : IEqualityComparer<Quest>
    {
        public bool Equals(Quest x, Quest y)
        {
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;
            if (ReferenceEquals(x, y))
                return true;
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Quest quest) => quest.Id;
    }
}