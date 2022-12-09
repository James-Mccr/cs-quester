using Moq;
using Common.Collections.Readers;
using Xunit;
using static Common.Tests.MockHelpers;

namespace Common.Collections.UnitTests.Readers
{
    public class TestCollectionReader
    {
        [Fact]
        public void CollectionReaderConstruct()
        {
            var mockCollection = MockCollection();
            var reader = new CollectionReader<It.IsAnyType>(mockCollection.Object);
            Assert.Same(mockCollection.Object, reader.Collection);
        }

        [Fact]
        public void CollectionReaderRead()
        {
            var mockCollection = MockCollection();
            var reader = new CollectionReader<It.IsAnyType>(mockCollection.Object);

            var actual = reader.Read();

            Assert.Same(mockCollection.Object, actual);
        }
    }
}