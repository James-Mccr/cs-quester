using Quester.Models;
using Xunit;

namespace Quester.UnitTests
{
    public class TestReward
    {
        [Fact]
        public void RewardConstruct()
        {
            var reward = new Reward(string.Empty, 1);
            Assert.Empty(reward.Prize);
            Assert.Equal(1, reward.Cost);
        }

        [Fact]
        public void RewardUpdate()
        {
            var reward = new Reward(string.Empty, 1);
            reward.Prize = null;
            reward.Cost = 2;
            Assert.Null(reward.Prize);
            Assert.Equal(2, reward.Cost);
        }
    }
}
