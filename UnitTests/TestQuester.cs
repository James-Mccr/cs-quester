using System;
using System.Collections.Generic;
using Quester.JournalWriters;
using Quester.Models;
using Xunit;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestQuester
    {
        [Theory]
        [MemberData(nameof(QuesterNullThrowsExceptionData))]
        public void QuesterNullThrowsException(Journal journal, IJournalWriter journalWriter, string paramName) 
            => Assert.Throws<ArgumentNullException>(paramName, () => new Quester(journal, journalWriter));

        public static IEnumerable<object[]> QuesterNullThrowsExceptionData()
        {
            yield return new object[] { null, null, nameof(Quester.Journal) };
            yield return new object[] { MockJournal(), null, nameof(Quester.JournalWriter) };
        }
    }
}
