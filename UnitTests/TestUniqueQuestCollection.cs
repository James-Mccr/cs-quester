using System;
using System.Collections.Generic;
using Quester.Models;
using Xunit;
using Moq;
using Quester.QuestCollections;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestUniqueQuestCollection
    {
        [Fact]
        public void UniqueQuestCollectionNullThrowsException() 
            => Assert.Throws<ArgumentNullException>(nameof(UniqueQuestCollection.Quests), () => new UniqueQuestCollection(null));


        [Theory]
        [MemberData(nameof(UniqueQuestCollectionData))]
        public void UniqueQuestCollectionAdd(IEnumerable<Quest> quests, int callCount)
        {
            var mockQuests = new Mock<ISet<Quest>>();
            var questCollection = new UniqueQuestCollection(mockQuests.Object);
            questCollection.Add(quests);
            mockQuests.Verify(m => m.Add(It.IsAny<Quest>()), Times.Exactly(callCount));
        }

        [Theory]
        [MemberData(nameof(UniqueQuestCollectionData))]
        public void UniqueQuestCollectionRemove(IEnumerable<Quest> quests, int callCount)
        {
            var mockQuests = new Mock<ISet<Quest>>();
            var questCollection = new UniqueQuestCollection(mockQuests.Object);
            questCollection.Remove(quests);
            mockQuests.Verify(m => m.Remove(It.IsAny<Quest>()), Times.Exactly(callCount));
        }

        public static IEnumerable<object[]> UniqueQuestCollectionData()
        {
            yield return new object[] { new Quest[0], 0 };
            yield return new object[] { new Quest[] { MockQuest(0) }, 1 };
            yield return new object[] { new Quest[] { MockQuest(0), MockQuest(0) }, 2 };
            yield return new object[] { new Quest[] { MockQuest(0), MockQuest(1), MockQuest(2) }, 3 };
        }
    }
}