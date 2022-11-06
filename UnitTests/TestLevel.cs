using Quester.Models;
using Xunit;

namespace Quester.UnitTests
{
    public class TestLevel
    {
        [Fact]
        public void LevelConstruct()
        {
            var level = new Level(0);
            Assert.Equal(0, level.Experience);
        }

        [Fact]
        public void LevelUpdate()
        {
            var level = new Level(0);
            level.Experience = 1;
            Assert.Equal(1, level.Experience);
        }
    }
}