using System;
using System.Collections.Generic;
using Xunit;
using Quester.Models;

namespace Quester.UnitTests
{
    public class TestQuest
    {
        private static Quest CreateTestQuest() => new Quest(0, 0, string.Empty, null, null);

        [Fact]
        public void CreateQuest()
        {
            var q = CreateTestQuest();
            Assert.Equal(0, q.Id);
            Assert.Equal(0, q.Reward);
            Assert.Empty(q.Goal);
            Assert.Null(q.DateCreated);
            Assert.Null(q.DateCompleted);
        }

        [Fact]
        public void UpdateQuest()
        {
            var q = CreateTestQuest();
            q.Id = 1;
            q.Reward = 1;
            q.Goal = "goal";
            q.DateCreated = new DateTime(1);
            q.DateCompleted = new DateTime(1);
            Assert.Equal(1, q.Id);
            Assert.Equal(1, q.Reward);
            Assert.Equal("goal", q.Goal);
            Assert.Equal(1, q.DateCreated.Value.Ticks);
            Assert.Equal(1, q.DateCompleted.Value.Ticks);
        }

        public static IEnumerable<object[]> GetQuests()
        {
            yield return new object[] { CreateTestQuest(), false };
            yield return new object[] { new Quest(0, 0, string.Empty, null, new DateTime(1)), true };
        }

        [Theory]
        [MemberData(nameof(GetQuests))]
        public void IsQuestComplete(Quest quest, bool isComplete) => Assert.Equal(isComplete, quest.IsComplete());
    }
}