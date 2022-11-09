using Moq;
using Quester.Readers;
using Quester.Serialiser;
using Xunit;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestJsonReader
    {
        [Fact]
        public void JsonReaderConstruct()
        {
            var mockStringReader = Mock<IReader<string>>();
            var mockSerialiser = Mock<ISerialiser<It.IsAnyType>>();
            var reader = new JsonReader<It.IsAnyType>(mockStringReader, mockSerialiser);
            Assert.Equal(mockStringReader, reader.StringReader);
            Assert.Equal(mockSerialiser, reader.Serialiser);
        }

        [Fact]
        public void JsonReaderRead()
        {
            var mockStringReader = new Mock<IReader<string>>();
            var mockSerialiser = new Mock<ISerialiser<It.IsAnyType>>();
            
            var reader = new JsonReader<It.IsAnyType>(mockStringReader.Object, mockSerialiser.Object);
            reader.Read();

            mockStringReader.Verify(m => m.Read(), Times.Once);
            mockSerialiser.Verify(m => m.Deserialise(It.IsAny<string>()), Times.Once);
        }
    }
}