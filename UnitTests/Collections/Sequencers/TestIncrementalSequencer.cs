using System.Collections.Generic;
using Quester.Collections.Sequencers;
using Quester.Identities;
using Xunit;
using static UnitTests.MockHelpers;

namespace UnitTests.Collections.Sequencers
{
    public class TestIncrementalSequencer
    {
        [Fact]
        public void IncrementalSequencerConstruct()
        {
            var sequencer = new IncrementalSequencer();
            Assert.Equal(1, sequencer.Increment);
        }

        [Theory]
        [MemberData(nameof(IncrementalSequencerNextData))]
        public void IncrementalSequencerNext(IEnumerable<IIdentifier> items, IIdentifier expected)
        {
            var sequencer = new IncrementalSequencer();
            var next = sequencer.Next(items);
            Assert.Equal(expected, next, new IdentifierTestEqualityComparer());
        }

        public static IEnumerable<object[]> IncrementalSequencerNextData()
        {
            yield return new object[] { new IIdentifier[0], Id(0) };
            yield return new object[] { new IIdentifier[] { Id(0) }, Id(1) };
            yield return new object[] { new IIdentifier[] { Id(0), Id(10) }, Id(11) };
        }
    }
}