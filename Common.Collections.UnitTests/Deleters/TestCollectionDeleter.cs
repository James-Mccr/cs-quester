using Moq;
using Common.Collections.Deleters;
using Xunit;
using static Common.Tests.MockHelpers;

namespace Common.Collections.UnitTests.Deleters
{
    public class TestCollectionDeleter
    {

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void CollectionDeleterDelete(int deleteCount)
        {
            var mockCollection = MockCollection();
            var mockEnumerable = MockEnumerable();
            mockEnumerable.Setup(m => m.GetEnumerator()).Returns(AnyEnumerator(deleteCount));
            var deleter = new CollectionDeleter<It.IsAnyType>();

            deleter.Delete(mockCollection.Object, mockEnumerable.Object);

            mockCollection.Verify(m => m.Remove(Any()), Times.Exactly(deleteCount));
        }
    }
}