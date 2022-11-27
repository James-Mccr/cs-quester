using Moq;
using Common.Io.Converters;
using Common.Io.Factories;
using Xunit;
using static Common.Tests.MockHelpers;

namespace Common.Io.UnitTests.Converters
{
    public class TestNullConverter
    {
        [Fact]
        public void NullConverterConstruct()
        {
            var factory = Mock<IFactory<It.IsAnyType>>();
            var converter = new NullConverter<It.IsAnyType>(factory);
            Assert.Equal(factory, converter.Factory);
        }

        [Fact]
        public void NullConverterConvertNull()
        {
            var factory = new Mock<IFactory<It.IsAnyType>>();
            var converter = new NullConverter<It.IsAnyType>(factory.Object);

            converter.Convert(null);

            factory.Verify(m => m.Make(), Times.Once);
        }

        [Fact]
        public void NullCollectionConverterConvertNonNull()
        {
            var item = new It.IsAnyType();
            var factory = new Mock<IFactory<It.IsAnyType>>();
            var converter = new NullConverter<It.IsAnyType>(factory.Object);

            var output = converter.Convert(item);

            factory.Verify(m => m.Make(), Times.Never);
            Assert.Equal(item, output);
        }
    }
}