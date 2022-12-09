using System.Collections.Generic;
using Common.Identities.Identifiers;
using Common.Identities.Sequencers;
using Xunit;
using static Common.Identities.UnitTests.IdentityHelpers;

namespace Common.Identities.UnitTests.Sequencers
{
    public class TestIdentifierSequencer
    {
        [Fact]
        public void IdentifierSequencerConstruct()
        {
            var sequencer = new IdentifierSequencer();
            Assert.Equal(1, sequencer.Increment);
        }

        [Theory]
        [MemberData(nameof(IdentifierSequencerNextData))]
        public void IdentifierSequencerNext(IEnumerable<IIdentifier> items, IIdentifier expected)
        {
            var sequencer = new IdentifierSequencer();
            var next = sequencer.Next(items);
            Assert.Equal(expected, next, new IdentifierTestEqualityComparer());
        }

        public static IEnumerable<object[]> IdentifierSequencerNextData()
        {
            yield return new object[] { new IIdentifier[0], Id(0) };
            yield return new object[] { new IIdentifier[] { Id(0) }, Id(1) };
            yield return new object[] { new IIdentifier[] { Id(0), Id(10) }, Id(11) };
        }
    }
}