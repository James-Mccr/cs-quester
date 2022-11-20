using System.Collections.Generic;
using Moq;
using Quester.Identities;
using Quester.Quests;

namespace UnitTests
{
    public static class MockHelpers
    {
        public static Quest MockQuest() => new Quest(0, 0, null, false);
        public static Identifier Id(int i) => new Identifier(i);
        public static T Mock<T>() where T : class => new Mock<T>().Object;
        public static It.IsAnyType Any() => It.IsAny<It.IsAnyType>();
        public static IEnumerable<It.IsAnyType> AnyEnumerable() => It.IsAny<IEnumerable<It.IsAnyType>>();
        public static ICollection<It.IsAnyType> AnyCollection() => It.IsAny<ICollection<It.IsAnyType>>();
    }
}