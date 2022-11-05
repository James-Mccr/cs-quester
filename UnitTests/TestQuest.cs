using Xunit;
using Quester.Models;

namespace Quester.UnitTests
{
    public class TestQuest
    {
        [Fact]
        public void CreateQuest()
        {
            var q = new Quest(0, 0, string.Empty, false);
            Assert.Equal(0, q.Id);
            Assert.Equal(0, q.Reward);
            Assert.Empty(q.Goal);
            Assert.False(q.Complete);
        }

        [Fact]
        public void UpdateQuest()
        {
            var q = new Quest(0, 0, string.Empty, false);
            q.Id = 1;
            q.Reward = 1;
            q.Goal = "goal";
            q.Complete = true;
            Assert.Equal(1, q.Id);
            Assert.Equal(1, q.Reward);
            Assert.Equal("goal", q.Goal);
            Assert.True(q.Complete);
        }
    }
}