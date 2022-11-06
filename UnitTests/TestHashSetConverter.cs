using Quester.SetConverters;
using Moq;
using Xunit;
using System.Collections.Generic;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestHashSetConverter
    {
        [Fact]
        public void HashSetConverterConstruct()
        {
            var equalityComparer = Mock<IEqualityComparer<It.IsAnyType>>();
            var converter = new HashSetConverter<It.IsAnyType>(equalityComparer);
            Assert.Equal(equalityComparer, converter.EqualityComparer);
        }

        [Fact]
        public void HashSetConverterConvert()
        {
            var mockEqualityComparer = Mock<IEqualityComparer<It.IsAnyType>>();
            var converter = new HashSetConverter<It.IsAnyType>(mockEqualityComparer);
            var mockItems = new It.IsAnyType[0];
            var hashSet = converter.Convert(mockItems);
            Assert.IsType<HashSet<It.IsAnyType>>(hashSet);
        }
    }
}