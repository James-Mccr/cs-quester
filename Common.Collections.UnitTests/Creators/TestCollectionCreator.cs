using Moq;
using Xunit;
using Common.Collections.Creators;
using static Common.Tests.MockHelpers;

namespace Common.Collections.UnitTests.Creators
{
    public class TestCollectionCreator
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void CollectionCreatorCreate(int createCount)
        {
            var mockCollection = MockCollection();
            var mockEnumerable = MockEnumerable();
            mockEnumerable.Setup(m => m.GetEnumerator()).Returns(AnyEnumerator(createCount));
            var creator = new CollectionCreator<It.IsAnyType>();
            
            creator.Create(mockCollection.Object, mockEnumerable.Object);

            mockCollection.Verify(m => m.Add(Any()), Times.Exactly(createCount));
        }

        
    }
}