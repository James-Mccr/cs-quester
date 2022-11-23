using System.Collections.Generic;
using Moq;
using Common.Collections.Readers;
using Common.Io.Inputs;
using Xunit;
using static Common.Tests.MockHelpers;

namespace Common.Collections.UnitTests.Readers
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