using System.Collections.Generic;
using Quester.Models;
using Quester.RewardEqualityComparers;
using Xunit;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestRewardIdEqualityComparer
    {
        [Theory]
        [MemberData(nameof(RewardIdEqualityComparerEqualsData))]
        public void RewardIdEqualityComparerEquals(Reward x, Reward y, bool rewardsEqual)
        {
            var comparer = new RewardIdEqualityComparer();
            Assert.Equal(rewardsEqual, comparer.Equals(x, y));
        }

        [Theory]
        [MemberData(nameof(RewardIdEqualityComparerGetHashCodeData))]
        public void RewardIdEqualityComparerGetHashCode(Reward r, int hashCode)
        {
            var comparer = new RewardIdEqualityComparer();
            Assert.Equal(hashCode, comparer.GetHashCode(r));
        }

        public static IEnumerable<object[]> RewardIdEqualityComparerEqualsData()
        {
            yield return new object[] { null, null, false };
            yield return new object[] { MockReward(0), null, false };
            yield return new object[] { MockReward(0), MockReward(0), true };
            yield return new object[] { MockReward(0), MockReward(1), false };
            yield return new object[] { MockReward(int.MinValue), MockReward(int.MinValue), true };
            yield return new object[] { MockReward(int.MaxValue), MockReward(int.MaxValue), true };
        }

        public static IEnumerable<object[]> RewardIdEqualityComparerGetHashCodeData()
        {
            yield return new object[] { MockReward(0), 0 };
            yield return new object[] { MockReward(1), 1 };
            yield return new object[] { MockReward(int.MinValue), int.MinValue };
            yield return new object[] { MockReward(int.MaxValue), int.MaxValue };

        }
    }
}