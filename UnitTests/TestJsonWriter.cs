using Moq;
using Quester.Serialiser;
using Quester.Writers;
using Xunit;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestJsonWriter
    {
        [Fact]
        public void JsonWriterConstruct()
        {
            var mockStringWriter = Mock<IWriter<string>>();
            var mockSerialiser = Mock<ISerialiser<It.IsAnyType>>();
            var writer = new JsonWriter<It.IsAnyType>(mockStringWriter, mockSerialiser);
            Assert.Equal(mockStringWriter, writer.StringWriter);
            Assert.Equal(mockSerialiser, writer.Serialiser);
        }

        [Fact]
        public void JsonWriterWrite()
        {
            var mockStringWriter = new Mock<IWriter<string>>();
            var mockSerialiser = new Mock<ISerialiser<It.IsAnyType>>();
            
            var writer = new JsonWriter<It.IsAnyType>(mockStringWriter.Object, mockSerialiser.Object);
            writer.Write(It.IsAny<It.IsAnyType>());

            mockSerialiser.Verify(m => m.Serialise(It.IsAny<It.IsAnyType>()), Times.Once);
            mockStringWriter.Verify(m => m.Write(It.IsAny<string>()), Times.Once);
        }
    }
}