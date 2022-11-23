using System.IO;
using Moq;
using Common.Io.Inputs;
using Common.Io.TextReaderProviders;
using Xunit;
using static Common.Tests.MockHelpers;

namespace Common.Io.UnitTests.Inputs
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