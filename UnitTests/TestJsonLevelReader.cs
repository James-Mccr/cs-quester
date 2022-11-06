using System.IO;
using Moq;
using Quester.LevelReaders;
using Quester.LevelSerialisers;
using Xunit;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestJsonLevelReader
    {
        [Fact]
        public void JsonLevelReaderConstruct()
        {
            var mockLevelSerialiser = Mock<ILevelSerialiser>();
            var mockTextReader = Mock<TextReader>();
            var reader = new JsonLevelReader(mockLevelSerialiser, mockTextReader);
            Assert.Equal(mockLevelSerialiser, reader.LevelSerialiser);
            Assert.Equal(mockTextReader, reader.TextReader);
        }

        [Fact]
        public void JsonLevelReaderRead()
        {
            var mockLevelSerialiser = new Mock<ILevelSerialiser>();
            var mockTextReader = new Mock<TextReader>();

            var reader = new JsonLevelReader(mockLevelSerialiser.Object, mockTextReader.Object);
            reader.Read();

            mockLevelSerialiser.Verify(m => m.Deserialise(It.IsAny<string>()), Times.Once);
            mockTextReader.Verify(m => m.ReadToEnd(), Times.Once);
        }
    }
}