using Common.Identities.Identifiers;

namespace Common.Identities.UnitTests
{
    public static class Helpers
    {
        public static Identifier Id(int id) => new Identifier(id);
    }
}