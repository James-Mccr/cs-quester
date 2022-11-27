using Xunit;

namespace Common.Journals.UnitTests
{
    public class TestJournal
    {
        [Fact]
        public void JournalConstruct()
        {
            var journal = new Journal(1);
            Assert.Equal(1, journal.Merits);
        }

        [Fact]
        public void JournalSet()
        {
            var journal = new Journal(1);
            journal.Merits = 2;
            Assert.Equal(2, journal.Merits);
        }
    }
}