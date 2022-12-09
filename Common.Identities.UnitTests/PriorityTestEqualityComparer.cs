using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Common.Identities.Priorities;

namespace Common.Identities.UnitTests
{
    public class PriorityTestEqualityComparer : IEqualityComparer<IPriority>
    {
        public bool Equals(IPriority x, IPriority y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;
            return x.Priority == y.Priority;
        }

        public int GetHashCode([DisallowNull] IPriority obj) => throw new System.NotImplementedException();
    }
}