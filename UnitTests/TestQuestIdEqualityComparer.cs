using System.Collections.Generic;
using Quester.Models;
using Quester.QuestEqualityComparer;
using Xunit;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestQuestIdEqualityComparer
    {
        [Theory]
        [MemberData(nameof(QuestIdEqualityComparerEqualsData))]
        public void QuestIdEqualityComparerEquals(Quest x, Quest y, bool questsEqual)
        {
            var comparer = new QuestIdEqualityComparer();
            Assert.Equal(questsEqual, comparer.Equals(x, y));
        }

        [Theory]
        [MemberData(nameof(QuestIdEqualityComparerGetHashCodeData))]
        public void QuestIdEqualityComparerGetHashCode(Quest q, int hashCode)
        {
            var comparer = new QuestIdEqualityComparer();
            Assert.Equal(hashCode, comparer.GetHashCode(q));
        }

        public static IEnumerable<object[]> QuestIdEqualityComparerEqualsData()
        {
            yield return new object[] { null, null, false };
            yield return new object[] { MockQuest(0), null, false };
            yield return new object[] { MockQuest(0), MockQuest(0), true };
            yield return new object[] { MockQuest(0), MockQuest(1), false };
            yield return new object[] { MockQuest(int.MaxValue), MockQuest(int.MaxValue), true };
            yield return new object[] { MockQuest(int.MinValue), MockQuest(int.MinValue), true };
        }

        public static IEnumerable<object[]> QuestIdEqualityComparerGetHashCodeData()
        {
            yield return new object[] { MockQuest(0), 0 };
            yield return new object[] { MockQuest(1), 1 };
            yield return new object[] { MockQuest(int.MaxValue), int.MaxValue };
            yield return new object[] { MockQuest(int.MinValue), int.MinValue };
        }
    }
}