using System.Collections.Generic;
using Moq;
using Quester.Collections.Deleters;
using Quester.Io.Inputs;
using Quester.Io.Outputs;
using Xunit;
using static UnitTests.MockHelpers;

namespace UnitTests.Collections.Deleters
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