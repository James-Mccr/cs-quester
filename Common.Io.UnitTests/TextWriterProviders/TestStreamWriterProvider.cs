using System.IO;
using Moq;
using Common.Io.StreamProviders;
using Common.Io.TextWriterProviders;
using Xunit;
using static Common.Tests.MockHelpers;

namespace Common.Io.UnitTests.TextWriterProviders
{
    public class TestStreamWriterProvider
    {
        [Fact]
        public void StreamWriterProviderConstruct()
        {
            var streamProvider = Mock<IStreamProvider>();
            var writerProvider = new StreamWriterProvider(streamProvider);
            Assert.Equal(streamProvider, writerProvider.StreamProvider);
        }

        [Fact]
        public void StreamWriterProviderProvide()
        {
            var stream = new Mock<Stream>();
            stream.Setup(m => m.CanWrite).Returns(true);
            var streamProvider = new Mock<IStreamProvider>();
            streamProvider.Setup(m => m.Provide()).Returns(stream.Object);
            var writerProvider = new StreamWriterProvider(streamProvider.Object);

            writerProvider.Provide();

            streamProvider.Verify(m => m.Provide(), Times.Once);
        }
    }
}