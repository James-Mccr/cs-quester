using System;
using System.Linq;
using Quester.Commandline.Options;
using Common.Collections.Readers;

namespace Quester.Commandline.Commands
{
    public class ReadQuestCommand
    {        
        public IReader<Quest> Reader { get; }

        public ReadQuestCommand(IReader<Quest> reader)
        {
            Reader = reader;
        }

        public void Run(ReadQuestOptions options)
        {
            var quests = Reader.Read();
            if (quests.Count() == 0)
            {
                Console.WriteLine("No quests found!");
                return;
            }

            IOrderedEnumerable<Quest> sortedQuests = quests.OrderBy(q => q.Priority);

            Console.WriteLine($"Id\tOrder\tGoal"); 

            foreach (var quest in sortedQuests)
            {
                Console.WriteLine($"{quest.Id}\t{quest.Priority}\t{quest.Goal}");
            }

        }
    }
}