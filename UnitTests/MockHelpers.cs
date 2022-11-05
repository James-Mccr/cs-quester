using Moq;
using Quester.Models;

namespace Quester.UnitTests
{
    public static class MockHelpers
    {
        public static Quest MockQuest(int id) => new Quest(id, 0, null, false);
        
        public static T Mock<T>() where T : class => new Mock<T>().Object;
    }
}