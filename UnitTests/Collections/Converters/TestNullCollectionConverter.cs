using System.Collections.Generic;
using Moq;
using Quester.Collections.Converters;
using Quester.Collections.Factories;
using Xunit;
using static UnitTests.MockHelpers;

namespace UnitTests.Collections.Converters
{
    public class TestNullCollectionConverter
    {
        [Fact]
        public void NullCollectionConverterConstruct()
        {
            var factory = Mock<IFactory<ICollection<It.IsAnyType>>>();
            var converter = new NullCollectionConverter<It.IsAnyType>(factory);
            Assert.Equal(factory, converter.Factory);
        }

        [Fact]
        public void NullCollectionConverterConvertNull()
        {
            var factory = new Mock<IFactory<ICollection<It.IsAnyType>>>();
            var converter = new NullCollectionConverter<It.IsAnyType>(factory.Object);

            converter.Convert(null);

            factory.Verify(m => m.Make(), Times.Once);
        }

        [Fact]
        public void NullCollectionConverterConvertNonNull()
        {
            var items = new It.IsAnyType[0];
            var factory = new Mock<IFactory<ICollection<It.IsAnyType>>>();
            var converter = new NullCollectionConverter<It.IsAnyType>(factory.Object);

            var output = converter.Convert(items);

            factory.Verify(m => m.Make(), Times.Never);
            Assert.Equal(items, output);
        }
    }
}