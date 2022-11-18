using System;
using System.Collections.Generic;
using Quester.Quests;

namespace Quester.Comparisons.Comparers
{
    public class QuestComparer : IComparer<Quest>
    {
        public int Compare(Quest x, Quest y)
        {
            if (ReferenceEquals(x, null))
                throw new ArgumentNullException(nameof(x));
            if (ReferenceEquals(y, null))
                throw new ArgumentNullException(nameof(y));
            if (ReferenceEquals(x, y))
                return 0;
            return x.Id - y.Id;
        }
    }
}