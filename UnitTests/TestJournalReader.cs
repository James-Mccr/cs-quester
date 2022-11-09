using System.Collections.Generic;
using Moq;
using Quester.JournalReaders;
using Quester.Models;
using Quester.Readers;
using Quester.SetConverters;
using Xunit;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestJournalReader 
    {
        [Fact]
        public void JournalReaderConstruct()
        {
            var mockQuestsReader = Mock<IReader<IEnumerable<Quest>>>();
            var mockRewardsReader = Mock<IReader<IEnumerable<Reward>>>();
            var mockLevelReader = Mock<IReader<Level>>();
            var mockQuestSetConverter = Mock<ISetConverter<Quest>>();
            var mockRewardSetConverter = Mock<ISetConverter<Reward>>();
            var journal = new JournalReader(mockQuestsReader, mockRewardsReader, mockLevelReader, mockQuestSetConverter, mockRewardSetConverter);
            Assert.Equal(mockQuestsReader, journal.QuestsReader);
            Assert.Equal(mockRewardsReader, journal.RewardsReader);
            Assert.Equal(mockLevelReader, journal.LevelReader);

        }

        [Fact]
        public void JournalReaderRead()
        {
            var mockQuestsReader = new Mock<IReader<IEnumerable<Quest>>>();
            var mockRewardsReader = new Mock<IReader<IEnumerable<Reward>>>();
            var mockLevelReader = new Mock<IReader<Level>>();
            var mockQuestSetConverter = new Mock<ISetConverter<Quest>>();
            var mockRewardSetConverter = new Mock<ISetConverter<Reward>>();

            var journal = new JournalReader(
                mockQuestsReader.Object, 
                mockRewardsReader.Object, 
                mockLevelReader.Object,
                mockQuestSetConverter.Object, 
                mockRewardSetConverter.Object);
            journal.Read();

            mockQuestsReader.Verify(m => m.Read(), Times.Once);
            mockRewardsReader.Verify(m => m.Read(), Times.Once);
            mockLevelReader.Verify(m => m.Read(), Times.Once);
            mockQuestSetConverter.Verify(m => m.Convert(It.IsAny<IEnumerable<Quest>>()), Times.Once);
            mockRewardSetConverter.Verify(m => m.Convert(It.IsAny<IEnumerable<Reward>>()), Times.Once);
        }
    }
}