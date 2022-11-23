using System.Collections.Generic;
using Common.Identities.Identifiers;
using Common.Identities.Selectors;
using Xunit;
using static Common.Identities.UnitTests.Helpers;

namespace Common.Identities.UnitTests.Selectors
{
    public class TestCollectionSelector
    {
        [Theory]
        [MemberData(nameof(CollectionSelectorSelectData))]
        public void CollectionSelectorSelect(IEnumerable<IIdentifier> items, IIdentifier item, IIdentifier expected)
        {
            var selector = new CollectionSelector<IIdentifier>();
            var selection = selector.Select(items, item);
            Assert.Equal(expected, selection, new IdentifierTestEqualityComparer());
        }

        public static IEnumerable<object[]> CollectionSelectorSelectData()
        {
            yield return new object[] { new Identifier[0], Id(0), null };
            yield return new object[] { new Identifier[] { Id(0) }, Id(1), null };
            yield return new object[] { new Identifier[] { Id(0) }, Id(0), Id(0) };
            yield return new object[] { new Identifier[] { Id(0), Id(1), Id(2) }, Id(1), Id(1) };
        }
    }
}