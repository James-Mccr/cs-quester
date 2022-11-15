using Quester.Models;
using Xunit;

namespace Quester.UnitTests
{
    public class TestJournal
    {
        [Fact]
        public void JournalConstruct()
        {
            var level = new Journal(0);
            Assert.Equal(0, level.Experience);
        }

        [Fact]
        public void JournalUpdate()
        {
            var level = new Journal(0);
            level.Experience = 1;
            Assert.Equal(1, level.Experience);
        }
    }
}