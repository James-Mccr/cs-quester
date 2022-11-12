using System.Collections.Generic;
using System.Linq;

namespace Quester.Utilities
{
    public static class EnumerableExtensions
    {
        public static bool IsEmpty<T>(this IEnumerable<T> values) => values.Count() == 0;
    }
}
