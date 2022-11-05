using System;
using System.Collections.Generic;
using Quester.QuestCollections;
using Quester.QuestReaders;
using Quester.QuestWriters;
using Xunit;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestQuester
    {
        [Theory]
        [MemberData(nameof(QuesterNullThrowsExceptionData))]
        public void QuesterNullThrowsException(IQuestCollection questCollection, IQuestReader questReader, IQuestWriter questWriter, string paramName) 
            => Assert.Throws<ArgumentNullException>(paramName, () => new Quester(questCollection, questReader, questWriter));

        public static IEnumerable<object[]> QuesterNullThrowsExceptionData()
        {
            yield return new object[] { null, null, null, nameof(Quester.QuestCollection) };
            yield return new object[] { Mock<IQuestCollection>(), null, null, nameof(Quester.QuestReader) };
            yield return new object[] { Mock<IQuestCollection>(), Mock<IQuestReader>(), null, nameof(Quester.QuestWriter) };
        }
    }
}
