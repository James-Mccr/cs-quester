using System.Collections.Generic;
using Moq;

namespace Common.Tests
{
    public static class MockHelpers
    {
        public static T Mock<T>() where T : class => new Mock<T>().Object;
        public static T Any<T>() => It.IsAny<T>();
        public static It.IsAnyType Any() => Any<It.IsAnyType>();
        public static IEnumerator<It.IsAnyType> AnyEnumerator(int size) => ((IEnumerable<It.IsAnyType>)new It.IsAnyType[size]).GetEnumerator();
        public static Mock<ICollection<It.IsAnyType>> MockCollection() => new Mock<ICollection<It.IsAnyType>>();
        public static Mock<IEnumerable<It.IsAnyType>> MockEnumerable() => new Mock<IEnumerable<It.IsAnyType>>();
    }
}