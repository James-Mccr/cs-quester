using System.Collections.Generic;
using Moq;
using Quester.Collections.Readers;
using Quester.Io.Inputs;
using Xunit;
using static UnitTests.MockHelpers;

namespace UnitTests.Collections.Readers
{
    public class TestCollectionReader
    {
        [Fact]
        public void CollectionReaderConstruct()
        {
            var input = Mock<IInput<ICollection<It.IsAnyType>>>();
            var reader = new CollectionReader<It.IsAnyType>(input);
            Assert.Equal(input, reader.Input);
        }

        [Fact]
        public void CollectionReaderRead()
        {
            var input = new Mock<IInput<ICollection<It.IsAnyType>>>();
            var reader = new CollectionReader<It.IsAnyType>(input.Object);

            reader.Read();

            input.Verify(m => m.Get(), Times.Once);
        }
    }
}