using System.IO;
using Moq;
using Quester.Io.Inputs;
using Quester.Io.TextReaderProviders;
using Xunit;
using static UnitTests.MockHelpers;

namespace UnitTests.Io.Inputs
{
    public class TestStringInput
    {
        [Fact]
        public void StringInputConstruct()
        {
            var mockTextReaderProvider = Mock<ITextReaderProvider>();
            var reader = new StringInput(mockTextReaderProvider);
            Assert.Equal(mockTextReaderProvider, reader.TextReaderProvider);
        }

        [Fact]
        public void StringInputRead()
        {
            var mockTextReader = new Mock<TextReader>();
            var mockTextReaderProvider = new Mock<ITextReaderProvider>();
            mockTextReaderProvider.Setup(m => m.Provide()).Returns(mockTextReader.Object);
            var input = new StringInput(mockTextReaderProvider.Object);

            input.Get();

            mockTextReaderProvider.Verify(m => m.Provide(), Times.Once);
            mockTextReader.Verify(m => m.ReadToEnd(), Times.Once);
        }
    }
}