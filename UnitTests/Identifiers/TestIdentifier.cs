using Quester.Identities;
using Xunit;

namespace UnitTests.Identifiers
{
    public class TestIdentifier
    {
        [Fact]
        public void IdentifierConstruct()
        {
            var identifier = new Identifier(1);
            Assert.Equal(1, identifier.Id);
        }

                [Fact]
        public void IdentifierSet()
        {
            var identifier = new Identifier(0);
            identifier.Id = 2;
            Assert.Equal(2, identifier.Id);
        }
    }
}