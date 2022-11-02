using System.Collections.Generic;
using Quester.Models;
using Quester.QuestEqualityComparer;
using Xunit;
using static Quester.UnitTests.QuestHelpers;

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
            yield return new object[] { MakeQuest(0), null, false };
            yield return new object[] { MakeQuest(0), MakeQuest(0), true };
            yield return new object[] { MakeQuest(0), MakeQuest(1), false };
            yield return new object[] { MakeQuest(int.MaxValue), MakeQuest(int.MaxValue), true };
            yield return new object[] { MakeQuest(int.MinValue), MakeQuest(int.MinValue), true };
        }

        public static IEnumerable<object[]> QuestIdEqualityComparerGetHashCodeData()
        {
            yield return new object[] { MakeQuest(0), 0 };
            yield return new object[] { MakeQuest(1), 1 };
            yield return new object[] { MakeQuest(int.MaxValue), int.MaxValue };
            yield return new object[] { MakeQuest(int.MinValue), int.MinValue };
        }
    }
}