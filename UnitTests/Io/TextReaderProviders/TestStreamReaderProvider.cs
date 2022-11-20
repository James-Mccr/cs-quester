using System.IO;
using Moq;
using Quester.Io.StreamProviders;
using Quester.Io.TextReaderProviders;
using Xunit;
using static UnitTests.MockHelpers;

namespace UnitTests.Io.TextReaderProviders
{
    public class TestStreamReaderProvider
    {
        [Fact]
        public void StreamReaderProviderConstruct()
        {
            var streamProvider = Mock<IStreamProvider>();
            var readerProvider = new StreamReaderProvider(streamProvider);
            Assert.Equal(streamProvider, readerProvider.StreamProvider);
        }

            [Fact]
        public void StreamReaderProviderProvide()
        {
            var stream = new Mock<Stream>();
            stream.Setup(m => m.CanRead).Returns(true);
            var streamProvider = new Mock<IStreamProvider>();
            streamProvider.Setup(m => m.Provide()).Returns(stream.Object);
            var readerProvider = new StreamReaderProvider(streamProvider.Object);

            readerProvider.Provide();

            streamProvider.Verify(m => m.Provide(), Times.Once);
        }
    }
}