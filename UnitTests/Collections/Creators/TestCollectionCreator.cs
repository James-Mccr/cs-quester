using System.Collections.Generic;
using Moq;
using Quester.Collections.Creators;
using Quester.Io.Inputs;
using Quester.Io.Outputs;
using Xunit;
using static UnitTests.MockHelpers;

namespace UnitTests.Collections.Creators
{
    public class TestCollectionCreator
    {
        [Fact]
        public void CollectionCreatorConstruct()
        {
            var input = Mock<IInput<ICollection<It.IsAnyType>>>();
            var output = Mock<IOutput<IEnumerable<It.IsAnyType>>>();
            var creator = new CollectionCreator<It.IsAnyType>(input, output);
            Assert.Equal(input, creator.Input);
            Assert.Equal(output, creator.Output);
        }

        [Fact]
        public void CollectionCreatorCreate()
        {
            var items = new Mock<ICollection<It.IsAnyType>>();
            var input = new Mock<IInput<ICollection<It.IsAnyType>>>();
            input.Setup(m => m.Get()).Returns(items.Object);
            var output = new Mock<IOutput<IEnumerable<It.IsAnyType>>>();
            var creator = new CollectionCreator<It.IsAnyType>(input.Object, output.Object);

            creator.Create(Any());

            input.Verify(m => m.Get(), Times.Once);
            items.Verify(m => m.Add(Any()), Times.Once);
            output.Verify(m => m.Set(AnyEnumerable()), Times.Once);
        }
    }
}