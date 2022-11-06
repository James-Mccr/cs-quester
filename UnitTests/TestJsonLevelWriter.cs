using System.IO;
using Moq;
using Quester.LevelSerialisers;
using Quester.LevelWriters;
using Quester.Models;
using Xunit;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestJsonLevelWriter
    {
        [Fact]
        public void JsonLevelWriterConstruct()
        {
            var mockLevelSerialiser = Mock<ILevelSerialiser>();
            var mockTextWriter = Mock<TextWriter>();
            var writer = new JsonLevelWriter(mockLevelSerialiser, mockTextWriter);
            Assert.Equal(mockLevelSerialiser, writer.LevelSerialiser);
            Assert.Equal(mockTextWriter, writer.TextWriter);
        }

        [Fact]
        public void JsonLevelWriterWrite()
        {
            var mockLevelSerialiser = new Mock<ILevelSerialiser>();
            var mockTextWriter = new Mock<TextWriter>();
            
            var writer = new JsonLevelWriter(mockLevelSerialiser.Object, mockTextWriter.Object);
            writer.Write(It.IsAny<Level>());

            mockLevelSerialiser.Verify(m => m.Serialise(It.IsAny<Level>()), Times.Once);
            mockTextWriter.Verify(m => m.Write(It.IsAny<string>()), Times.Once);
        }
    }
}