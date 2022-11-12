using System.Collections.Generic;
using System.Linq;
using Quester.Models;

namespace Quester.SetSelectors
{
    public class QuestSetSelector : ISetSelector<Quest>
    {
        public Quest Select(ISet<Quest> items, int id) => items.FirstOrDefault(q => q.Id == id);
    }
}