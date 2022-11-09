using System.IO;
using Moq;
using Quester.TextReaderProviders;
using Xunit;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestStringReader
    {
        [Fact]
        public void StringReaderConstruct()
        {
            var mockTextReaderProvider = Mock<ITextReaderProvider>();
            var reader = new Readers.StringReader(mockTextReaderProvider);
            Assert.Equal(mockTextReaderProvider, reader.TextReaderProvider);
        }

        [Fact]
        public void StringReaderRead()
        {
            var mockTextReader = new Mock<TextReader>();
            var mockTextReaderProvider = new Mock<ITextReaderProvider>();
            mockTextReaderProvider.Setup(m => m.Provide()).Returns(mockTextReader.Object);
            
            var reader = new Readers.StringReader(mockTextReaderProvider.Object);
            reader.Read();

            mockTextReaderProvider.Verify(m => m.Provide(), Times.Once);
            mockTextReader.Verify(m => m.ReadToEnd(), Times.Once);
        }
    }
}