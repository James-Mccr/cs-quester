using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Common.Identities.Identifiers;

namespace Common.Identities.UnitTests
{
    public class IdentifierTestEqualityComparer : IEqualityComparer<IIdentifier>
    {
        public bool Equals(IIdentifier x, IIdentifier y) 
        {
            if (ReferenceEquals(x, y))
                return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;
            return x.Id == y.Id;
                
        } 

        public int GetHashCode([DisallowNull] IIdentifier obj) => throw new System.NotImplementedException();
    }
}