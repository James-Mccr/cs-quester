using System.Collections.Generic;
using Common.Identities.Priorities;
using Common.Identities.Sequencers;
using Xunit;
using static Common.Identities.UnitTests.IdentityHelpers;

namespace Common.Identities.UnitTests.Sequencers
{
    public class TestPrioritySequencer
    {
        [Fact]
        public void PrioritySequencerConstruct()
        {
            var sequencer = new PrioritySequencer();
            Assert.Equal(1, sequencer.Increment);
        }

        [Theory]
        [MemberData(nameof(PrioritySequencerNextData))]
        public void PrioritySequencerNext(IEnumerable<IPriority> items, IPriority expected)
        {
            var sequencer = new PrioritySequencer();
            var actual = sequencer.Next(items);
            Assert.Equal(expected, actual, new PriorityTestEqualityComparer());
        }

        public static IEnumerable<object[]> PrioritySequencerNextData()
        {
            yield return new object[] { new IPriority[0], Priority(1) };
            yield return new object[] { new IPriority[] { Priority(2) }, Priority(3) };
            yield return new object[] { new IPriority[] { Priority(1), Priority(20) }, Priority(21) };
        }
    }
}