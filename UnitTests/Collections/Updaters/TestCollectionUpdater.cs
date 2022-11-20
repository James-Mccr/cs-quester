using System.Collections.Generic;
using Moq;
using Quester.Collections.Updaters;
using Quester.Io.Inputs;
using Quester.Io.Outputs;
using Xunit;
using static UnitTests.MockHelpers;

namespace UnitTests.Collections.Updaters
{
    public class TestCollectionUpdater
    {
        [Fact]
        public void CollectionUpdaterConstruct()
        {
            var input = Mock<IInput<ICollection<It.IsAnyType>>>();
            var output = Mock<IOutput<IEnumerable<It.IsAnyType>>>();
            var updater = new CollectionUpdater<It.IsAnyType>(input, output);
            Assert.Equal(input, updater.Input);
            Assert.Equal(output, updater.Output);
        }

        [Fact]
        public void CollectionUpdaterUpdate()
        {
            var items = new Mock<ICollection<It.IsAnyType>>();
            var input = new Mock<IInput<ICollection<It.IsAnyType>>>();
            input.Setup(m => m.Get()).Returns(items.Object);
            var output = new Mock<IOutput<IEnumerable<It.IsAnyType>>>();
            var updater = new CollectionUpdater<It.IsAnyType>(input.Object, output.Object);

            updater.Update(Any());

            input.Verify(m => m.Get(), Times.Once);
            items.Verify(m => m.Remove(Any()), Times.Once);
            items.Verify(m => m.Add(Any()), Times.Once);
            output.Verify(m => m.Set(AnyEnumerable()), Times.Once);
        }
    }
}