using System.Collections.Generic;
using Common.Identities.Priorities;
using Common.Identities.Shifters;
using Xunit;
using static Common.Identities.UnitTests.IdentityHelpers;

namespace Common.Identities.UnitTests.Shifters
{
    public class TestPriorityShifter
    {
        [Fact]
        public void PriorityShifterConstruct()
        {
            var shifter = new PriorityShifter(1);
            Assert.Equal(1, shifter.Increment);
        }

        [Theory]
        [MemberData(nameof(PriorityShifterShiftData))]
        public void PriorityShifterShift(
            int increment,
            IEnumerable<IPriority> items,
            IPriority lower,
            IPriority upper,
            IEnumerable<IPriority> expected)
        {
            var shifter = new PriorityShifter(increment);
            shifter.Shift(items, lower, upper);
            Assert.Equal(expected, items, new PriorityTestEqualityComparer());
        }

        public static IEnumerable<object[]> PriorityShifterShiftData()
        {
            yield return new object[] 
            {
                1,
                new IPriority[] { Priority(1), Priority(2) },
                Priority(1),
                Priority(2),
                new IPriority[] { Priority(2), Priority(3) }  
            };
            yield return new object[] 
            {
                -1,
                new IPriority[] { Priority(1), Priority(2) },
                Priority(1),
                Priority(2),
                new IPriority[] { Priority(0), Priority(1) }  
            };
            yield return new object[] 
            {
                1,
                new IPriority[] { Priority(1), Priority(2), Priority(3), Priority(4) },
                Priority(2),
                Priority(3),
                new IPriority[] { Priority(1), Priority(3), Priority(4), Priority(4) } 
            };
        }
    }
}