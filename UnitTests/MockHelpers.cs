using Moq;
using Quester.Models;
using Quester.Quests;

namespace Quester.UnitTests
{
    public static class MockHelpers
    {
        public static Quest MockQuest() => new Quest(0, 0, null, false);
        public static Reward MockReward() => new Reward(null, 0);
        public static Journal MockJournal() => new Journal(0);

        public static T Mock<T>() where T : class => new Mock<T>().Object;
    }
}