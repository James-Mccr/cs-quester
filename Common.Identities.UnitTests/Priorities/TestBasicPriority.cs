using Common.Identities.Priorities;
using Xunit;

namespace Common.Identities.UnitTests.Priorities
{
    public class TestBasicPriority
    {
        [Fact]
        public void BasicPriorityConstruct()
        {
            var test = new BasicPriority(1);
            Assert.Equal(1, test.Priority);
        }

        [Fact]
        public void BasicPrioritySet()
        {
            var test = new BasicPriority(1);
            test.Priority = 2;
            Assert.Equal(2, test.Priority);
        }
    }
}