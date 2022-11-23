using Moq;
using Common.Io.Outputs;
using Common.Io.Serialisers;
using Xunit;
using static Common.Tests.MockHelpers;

namespace Common.Io.UnitTests.Outputs
{
    public class TestJsonOutput
    {
        [Fact]
        public void JsonOutputConstruct()
        {
            var mockStringWriter = Mock<IOutput<string>>();
            var mockSerialiser = Mock<ISerialiser<It.IsAnyType>>();
            var output = new JsonOutput<It.IsAnyType>(mockStringWriter, mockSerialiser);
            Assert.Equal(mockStringWriter, output.StringOutput);
            Assert.Equal(mockSerialiser, output.Serialiser);
        }

        [Fact]
        public void JsonOutputWrite()
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