using Moq;
using Quester.Io.Outputs;
using Quester.Io.Serialisers;
using Xunit;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestJsonWriter
    {
        [Fact]
        public void JsonWriterConstruct()
        {
            var mockStringWriter = Mock<IOutput<string>>();
            var mockSerialiser = Mock<ISerialiser<It.IsAnyType>>();
            var output = new JsonOutput<It.IsAnyType>(mockStringWriter, mockSerialiser);
            Assert.Equal(mockStringWriter, output.StringOutput);
            Assert.Equal(mockSerialiser, output.Serialiser);
        }

        [Fact]
        public void JsonWriterWrite()
        {
            var mockStringWriter = new Mock<IOutput<string>>();
            var mockSerialiser = new Mock<ISerialiser<It.IsAnyType>>();
            
            var output = new JsonOutput<It.IsAnyType>(mockStringWriter.Object, mockSerialiser.Object);
            output.Set(It.IsAny<It.IsAnyType>());

            mockSerialiser.Verify(m => m.Serialise(It.IsAny<It.IsAnyType>()), Times.Once);
            mockStringWriter.Verify(m => m.Set(It.IsAny<string>()), Times.Once);
        }
    }
}