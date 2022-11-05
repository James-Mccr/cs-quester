using Quester.Models;

namespace Quester.UnitTests
{
    public static class QuestHelpers
    {
        public static Quest MakeQuest(int id) => new Quest(id, 0, null, false);
    }
}