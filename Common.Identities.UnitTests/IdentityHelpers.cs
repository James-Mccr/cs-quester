using Common.Identities.Identifiers;
using Common.Identities.Priorities;

namespace Common.Identities.UnitTests
{
    public static class IdentityHelpers
    {
        public static Identifier Id(int id) => new Identifier(id);
        public static BasicPriority Priority(int priority) => new BasicPriority(priority);
    }
}