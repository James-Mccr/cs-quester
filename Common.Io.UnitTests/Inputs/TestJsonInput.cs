using Moq;
using Common.Io.Inputs;
using Common.Io.Serialisers;
using Xunit;
using static Common.Tests.MockHelpers;

namespace Common.Io.UnitTests.Inputs
{
    public class TestJsonInput
    {
        [Fact]
        public void JsonInputConstruct()
        {
            var mockStringReader = Mock<IInput<string>>();
            var mockSerialiser = Mock<ISerialiser<It.IsAnyType>>();
            var reader = new JsonInput<It.IsAnyType>(mockStringReader, mockSerialiser);
            Assert.Equal(mockStringReader, reader.StringInput);
            Assert.Equal(mockSerialiser, reader.Serialiser);
        }

        [Fact]
        public void JsonInputRead()
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