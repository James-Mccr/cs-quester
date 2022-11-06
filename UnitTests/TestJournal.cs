using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Quester.Models;
using Xunit;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestJournal
    {
        [Fact]
        public void JournalConstruct()
        {
            var quests = Mock<ISet<Quest>>();
            var rewards = Mock<ISet<Reward>>();
            var level = MockLevel();
            var journal = new Journal(quests, rewards, level);
            Assert.Equal(quests, journal.Quests, new SetEqualityComparer<Quest>());
            Assert.Equal(rewards, journal.Rewards, new SetEqualityComparer<Reward>());
            Assert.Equal(level, journal.Level);
        }

        public class SetEqualityComparer<T> : IEqualityComparer<ISet<T>>
        {
            public bool Equals(ISet<T> x, ISet<T> y) => ReferenceEquals(x, y);

            public int GetHashCode([DisallowNull] ISet<T> obj)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}