using System;
using System.Collections.Generic;
using Common.Identities.Identifiers;
using Common.Identities.Selectors;
using Xunit;
using static Common.Identities.UnitTests.IdentityHelpers;

namespace Common.Identities.UnitTests.Selectors
{
    public class TestIdentifierSelector
    {
        [Fact]
        public void IdentifierSelectorItemNotFound()
        {
            Assert.Throws<InvalidOperationException>(
                () => new IdentifierSelector<IIdentifier>().Select(new IIdentifier[0], new Identifier(0)));
        }

        [Theory]
        [MemberData(nameof(IdentifierSelectorSelectData))]
        public void IdentifierSelectorSelect(IEnumerable<IIdentifier> items, IIdentifier item, IIdentifier expected)
        {
            var selector = new IdentifierSelector<IIdentifier>();
            var selection = selector.Select(items, item);
            Assert.Equal(expected, selection, new IdentifierTestEqualityComparer());
        }

        public static IEnumerable<object[]> IdentifierSelectorSelectData()
        {
            yield return new object[] { new Identifier[] { Id(0) }, Id(0), Id(0) };
            yield return new object[] { new Identifier[] { Id(0), Id(1), Id(2) }, Id(1), Id(1) };
        }
    }
}