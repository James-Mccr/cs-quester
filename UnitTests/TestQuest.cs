using Quester.Quests;
using Xunit;

namespace Quester.UnitTests
{
    public class TestQuest
    {
        [Fact]
        public void CreateQuest()
        {
            var q = new Quest(1, 1, string.Empty, true);
            Assert.Equal(1, q.Id);
            Assert.Equal(1, q.Reward);
            Assert.Empty(q.Goal);
            Assert.True(q.Complete);
        }

        [Fact]
        public void UpdateQuest()
        {
            var q = new Quest(1, 1, string.Empty, true);
            q.Reward = 2;
            q.Goal = "goal";
            q.Complete = false;
            Assert.Equal(2, q.Id);
            Assert.Equal(2, q.Reward);
            Assert.Equal("goal", q.Goal);
            Assert.False(q.Complete);
        }
    }
}