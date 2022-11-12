using System;
using System.Collections.Generic;
using Quester.Models;

namespace Quester.Comparers
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
            if (x.Id > y.Id)
                return 1;
            if (x.Id < y.Id)
                return -1;
            return 0;
            
        }
    }
}