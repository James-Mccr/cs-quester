using System.Collections.Generic;
using Moq;
using Quester.JournalReaders;
using Quester.LevelReaders;
using Quester.Models;
using Quester.QuestReaders;
using Quester.RewardReaders;
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
            var mockQuestReader = Mock<IQuestReader>();
            var mockRewardReader = Mock<IRewardReader>();
            var mockLevelReader = Mock<ILevelReader>();
            var mockQuestSetConverter = Mock<ISetConverter<Quest>>();
            var mockRewardSetConverter = Mock<ISetConverter<Reward>>();
            var journal = new JournalReader(mockQuestReader, mockRewardReader, mockLevelReader, mockQuestSetConverter, mockRewardSetConverter);
            Assert.Equal(mockQuestReader, journal.QuestReader);
            Assert.Equal(mockRewardReader, journal.RewardReader);
            Assert.Equal(mockLevelReader, journal.LevelReader);

        }

        [Fact]
        public void JournalReaderRead()
        {
            var mockQuestReader = new Mock<IQuestReader>();
            var mockRewardReader = new Mock<IRewardReader>();
            var mockLevelReader = new Mock<ILevelReader>();
            var mockQuestSetConverter = new Mock<ISetConverter<Quest>>();
            var mockRewardSetConverter = new Mock<ISetConverter<Reward>>();

            var journal = new JournalReader(
                mockQuestReader.Object, 
                mockRewardReader.Object, 
                mockLevelReader.Object,
                mockQuestSetConverter.Object, 
                mockRewardSetConverter.Object);
            journal.Read();

            mockQuestReader.Verify(m => m.Read(), Times.Once);
            mockRewardReader.Verify(m => m.Read(), Times.Once);
            mockLevelReader.Verify(m => m.Read(), Times.Once);
            mockQuestSetConverter.Verify(m => m.Convert(It.IsAny<IEnumerable<Quest>>()), Times.Once);
            mockRewardSetConverter.Verify(m => m.Convert(It.IsAny<IEnumerable<Reward>>()), Times.Once);
        }
    }
}