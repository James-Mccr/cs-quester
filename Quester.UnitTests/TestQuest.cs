using Xunit;

namespace Quester.UnitTests
{
    public class TestQuest
    {
        [Fact]
        public void CreateQuest()
        {
            var q = new Quest(1, 1, string.Empty);
            Assert.Equal(1, q.Id);
            Assert.Equal(1, q.Priority);
            Assert.Empty(q.Goal);
        }

        [Fact]
        public void UpdateQuest()
        {
            var q = new Quest(1, 1, string.Empty);
            q.Id = 2;
            q.Priority = 2;
            q.Goal = "goal";
            Assert.Equal(2, q.Id);
            Assert.Equal(2, q.Priority);
            Assert.Equal("goal", q.Goal);
        }
    }
}