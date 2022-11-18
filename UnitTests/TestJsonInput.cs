using Moq;
using Quester.Io.Inputs;
using Quester.Io.Serialisers;
using Xunit;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestJsonReader
    {
        [Fact]
        public void JsonReaderConstruct()
        {
            var mockStringReader = Mock<IInput<string>>();
            var mockSerialiser = Mock<ISerialiser<It.IsAnyType>>();
            var reader = new JsonInput<It.IsAnyType>(mockStringReader, mockSerialiser);
            Assert.Equal(mockStringReader, reader.StringInput);
            Assert.Equal(mockSerialiser, reader.Serialiser);
        }

        [Fact]
        public void JsonReaderRead()
        {
            var mockStringReader = new Mock<IInput<string>>();
            var mockSerialiser = new Mock<ISerialiser<It.IsAnyType>>();
            
            var reader = new JsonInput<It.IsAnyType>(mockStringReader.Object, mockSerialiser.Object);
            reader.Get();

            mockStringReader.Verify(m => m.Get(), Times.Once);
            mockSerialiser.Verify(m => m.Deserialise(It.IsAny<string>()), Times.Once);
        }
    }
}