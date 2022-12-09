using System;
using System.Collections.Generic;
using Common.Identities.Priorities;
using Common.Identities.Selectors;
using Xunit;
using static Common.Identities.UnitTests.IdentityHelpers;

namespace Common.Identities.UnitTests.Selectors
{
    public class TestPrioritySelector
    {
        [Fact]
        public void PrioritySelectorItemNotFound()
        {
            Assert.Throws<InvalidOperationException>(
                () => new PrioritySelector<IPriority>().Select(new BasicPriority[0], Priority(1)));
        }

        [Theory]
        [MemberData(nameof(PrioritySelectorSelectData))]
        public void PrioritySelectorSelect(IEnumerable<IPriority> items, IPriority item, IPriority expected)
        {
            var selector = new PrioritySelector<IPriority>();
            var selection = selector.Select(items, item);
            Assert.Equal(expected, selection, new PriorityTestEqualityComparer());
        }

        public static IEnumerable<object[]> PrioritySelectorSelectData()
        {
            yield return new object[] { new BasicPriority[] { Priority(0) }, Priority(0), Priority(0)  };
            yield return new object[] { new BasicPriority[] { Priority(1), Priority(2), Priority(3) }, Priority(2), Priority(2)  };
        }
    }
}