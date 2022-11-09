using System.Collections.Generic;
using Moq;
using Quester.JournalWriters;
using Quester.Models;
using Quester.Writers;
using Xunit;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestJournalWriter
    {
        [Fact]
        public void JournalWriterConstruct()
        {
            var mockQuestsWriter = Mock<IWriter<IEnumerable<Quest>>>();
            var mockRewardsWriter = Mock<IWriter<IEnumerable<Reward>>>();
            var mockLevelWriter = Mock<IWriter<Level>>();
            var journal = new JournalWriter(mockQuestsWriter, mockRewardsWriter, mockLevelWriter);
            Assert.Equal(mockQuestsWriter, journal.QuestsWriter);
            Assert.Equal(mockRewardsWriter, journal.RewardsWriter);
            Assert.Equal(mockLevelWriter, journal.LevelWriter);
        }

        [Fact]
        public void JournalWriterWrite()
        {
            var mockQuestsWriter = new Mock<IWriter<IEnumerable<Quest>>>();
            var mockRewardsWriter = new Mock<IWriter<IEnumerable<Reward>>>();
            var mockLevelWriter = new Mock<IWriter<Level>>();
            var mockJournal = new Journal(Mock<ISet<Quest>>(), Mock<ISet<Reward>>(), MockLevel());

            var journalWriter = new JournalWriter(mockQuestsWriter.Object, mockRewardsWriter.Object, mockLevelWriter.Object);
            journalWriter.Write(mockJournal);

            mockQuestsWriter.Verify(m => m.Write(It.IsAny<IEnumerable<Quest>>()), Times.Once);
            mockRewardsWriter.Verify(m => m.Write(It.IsAny<IEnumerable<Reward>>()), Times.Once);
            mockLevelWriter.Verify(m => m.Write(It.IsAny<Level>()), Times.Once);
        }
    }
}
