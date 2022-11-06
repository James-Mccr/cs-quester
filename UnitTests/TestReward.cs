using Quester.Models;
using Xunit;

namespace Quester.UnitTests
{
    public class TestReward
    {
        [Fact]
        public void RewardConstruct()
        {
            var reward = new Reward(0, null, 0);
            Assert.Equal(0, reward.Id);
            Assert.Equal(null, reward.Prize);
            Assert.Equal(0, reward.Cost);
        }

        [Fact]
        public void RewardUpdate()
        {
            var reward = new Reward(0, null, 0);
            reward.Id = 1;
            reward.Prize = string.Empty;
            reward.Cost = 1;
            Assert.Equal(1, reward.Id);
            Assert.Equal(string.Empty, reward.Prize);
            Assert.Equal(1, reward.Cost);
        }
    }
}
