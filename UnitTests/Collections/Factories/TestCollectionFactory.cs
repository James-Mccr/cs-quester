using System.Collections.Generic;
using Moq;
using Quester.Collections.Factories;
using Xunit;

namespace UnitTests.Collections.Factories
{
    public class TestCollectionFactory
    {
        [Fact]
        public void CollectionFactoryMake()
        {
            var factory = new CollectionFactory<It.IsAnyType>();
            var collection = factory.Make();
            Assert.Empty(collection);
            Assert.IsType<List<It.IsAnyType>>(collection);
        }
    }
}