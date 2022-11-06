using Moq;
using Quester.Models;

namespace Quester.UnitTests
{
    public static class MockHelpers
    {
        public static Quest MockQuest(int id) => new Quest(id, 0, null, false);
        public static Reward MockReward(int id) => new Reward(id, null, 0);
        public static Journal MockJournal() => new Journal(null, null, null);
        public static Level MockLevel() => new Level(0);

        public static T Mock<T>() where T : class => new Mock<T>().Object;
    }
}