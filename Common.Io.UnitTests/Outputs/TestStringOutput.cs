using System.IO;
using Moq;
using Common.Io.Outputs;
using Common.Io.TextWriterProviders;
using Xunit;
using static Common.Tests.MockHelpers;

namespace Common.Io.UnitTests.Outputs
{
    public class TestStringOutput
    {
        [Fact]
        public void StringOutputConstruct()
        {
            var mockTextWriterProvider = Mock<ITextWriterProvider>();
            var output = new StringOutput(mockTextWriterProvider);
            Assert.Equal(mockTextWriterProvider, output.TextWriterProvider);
        }

        [Fact]
        public void StringOutputSet()
        {
            var mockTextWriter = new Mock<TextWriter>();
            var mockTextWriterProvider = new Mock<ITextWriterProvider>();
            mockTextWriterProvider.Setup(m => m.Provide()).Returns(mockTextWriter.Object);
            var output = new StringOutput(mockTextWriterProvider.Object);

            output.Set(It.IsAny<string>());

            mockTextWriterProvider.Verify(m => m.Provide());
            mockTextWriter.Verify(m => m.Write(It.IsAny<string>()));
        }
    }
}