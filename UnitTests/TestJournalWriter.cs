using System.Collections.Generic;
using Moq;
using Quester.JournalWriters;
using Quester.LevelWriters;
using Quester.Models;
using Quester.QuestWriters;
using Quester.RewardWriters;
using Xunit;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestJournalWriter
    {
        [Fact]
        public void JournalWriterConstruct()
        {
            var mockQuestWriter = Mock<IQuestWriter>();
            var mockRewardWriter = Mock<IRewardWriter>();
            var mockLevelWriter = Mock<ILevelWriter>();
            var journal = new JournalWriter(mockQuestWriter, mockRewardWriter, mockLevelWriter);
            Assert.Equal(mockQuestWriter, journal.QuestWriter);
            Assert.Equal(mockRewardWriter, journal.RewardWriter);
            Assert.Equal(mockLevelWriter, journal.LevelWriter);
        }

        [Fact]
        public void JournalWriterWrite()
        {
            var mockQuestWriter = new Mock<IQuestWriter>();
            var mockRewardWriter = new Mock<IRewardWriter>();
            var mockLevelWriter = new Mock<ILevelWriter>();
            var mockJournal = new Journal(Mock<ISet<Quest>>(), Mock<ISet<Reward>>(), MockLevel());

            var journalWriter = new JournalWriter(mockQuestWriter.Object, mockRewardWriter.Object, mockLevelWriter.Object);
            journalWriter.Write(mockJournal);

            mockQuestWriter.Verify(m => m.Write(It.IsAny<IEnumerable<Quest>>()), Times.Once);
            mockRewardWriter.Verify(m => m.Write(It.IsAny<IEnumerable<Reward>>()), Times.Once);
            mockLevelWriter.Verify(m => m.Write(It.IsAny<Level>()), Times.Once);
        }
    }
}
