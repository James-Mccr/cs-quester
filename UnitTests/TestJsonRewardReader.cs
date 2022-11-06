using System.IO;
using Moq;
using Quester.RewardReaders;
using Quester.RewardSerialisers;
using Xunit;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestJsonRewardReader
    {
        [Fact]
        public void JsonRewardReaderConstruct()
        {
            var mockserialiser = Mock<IRewardSerialiser>();
            var mockTextReader = Mock<TextReader>();
            var reader = new JsonRewardReader(mockserialiser, mockTextReader);
            Assert.Equal(mockserialiser, reader.RewardSerialiser);
            Assert.Equal(mockTextReader, reader.TextReader);
        }

        [Fact]
        public void JsonRewardReaderRead()
        {
            var mockSerialiser = new Mock<IRewardSerialiser>();
            var mockTextReader = new Mock<TextReader>();

            var reader = new JsonRewardReader(mockSerialiser.Object, mockTextReader.Object);
            reader.Read();

            mockSerialiser.Verify(m => m.Deserialise(It.IsAny<string>()), Times.Once);
            mockTextReader.Verify(m => m.ReadToEnd(), Times.Once);
        }
    }
}