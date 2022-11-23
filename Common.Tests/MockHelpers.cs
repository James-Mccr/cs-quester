using System.Collections.Generic;
using Moq;

namespace Common.Tests
{
    public static class MockHelpers
    {
        public static T Mock<T>() where T : class => new Mock<T>().Object;
        public static T Any<T>() => It.IsAny<T>();
        public static It.IsAnyType Any() => Any<It.IsAnyType>();
        public static IEnumerable<It.IsAnyType> AnyEnumerable() => It.IsAny<IEnumerable<It.IsAnyType>>();
        public static ICollection<It.IsAnyType> AnyCollection() => It.IsAny<ICollection<It.IsAnyType>>();
    }
}