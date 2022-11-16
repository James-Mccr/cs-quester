using System.Collections.Generic;
using Quester.Models;
using Quester.Readers;
using Quester.Writers;

namespace Quester.Completers
{
    public class QuestCompleter : ICompleter
    {
        public IReader<IDictionary<int, Quest>> Reader { get; }
        public IWriter<IDictionary<int, Quest>> Writers { get; }

        public QuestCompleter(IReader<IDictionary<int, Quest>> reader, IWriter<IDictionary<int, Quest>> writers)
        {
            Reader = reader;
            Writers = writers;
        }

        public bool Complete(int id)
        {
            var quests = Reader.Read();
            if (!quests.ContainsKey(id) || quests[id].Complete)
                return false;
            quests[id].Complete = true;
            Writers.Write(quests);
            return true;
        }
    }
}