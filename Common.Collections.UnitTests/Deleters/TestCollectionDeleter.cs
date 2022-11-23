using System.Collections.Generic;
using Moq;
using Common.Collections.Deleters;
using Common.Io.Inputs;
using Common.Io.Outputs;
using Xunit;
using static Common.Tests.MockHelpers;

namespace Common.Collections.UnitTests.Deleters
{
    public class TestCollectionDeleter
    {
        [Fact]
        public void CollectionDeleterConstruct()
        {
            var input = Mock<IInput<ICollection<It.IsAnyType>>>();
            var output = Mock<IOutput<IEnumerable<It.IsAnyType>>>();
            var deleter = new CollectionDeleter<It.IsAnyType>(input, output);
            Assert.Equal(input, deleter.Input);
            Assert.Equal(output, deleter.Output);
        }

        [Fact]
        public void CollectionDeleterDelete()
        {
            var items = new Mock<ICollection<It.IsAnyType>>();
            var input = new Mock<IInput<ICollection<It.IsAnyType>>>();
            input.Setup(m => m.Get()).Returns(items.Object);
            var output = new Mock<IOutput<IEnumerable<It.IsAnyType>>>();
            var deleter = new CollectionDeleter<It.IsAnyType>(input.Object, output.Object);

            deleter.Delete(Any());

            input.Verify(m => m.Get(), Times.Once);
            items.Verify(m => m.Remove(Any()));
            output.Verify(m => m.Set(AnyEnumerable()), Times.Once);
        }
    }
}