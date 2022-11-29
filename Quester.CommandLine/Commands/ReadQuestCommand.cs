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

            if (options.HideComplete)
            {
                quests = quests.Where(q => !q.Complete);
            }

            IOrderedEnumerable<Quest> sortedQuests = quests.OrderBy(q => q.Id);
            if (options.SortByReward)
            {
                sortedQuests = quests.OrderBy(q => q.Reward);
            }
            else if (options.SortByGoal)
            {
                sortedQuests = quests.OrderBy(q => q.Goal);
            }
            else if (options.SortByComplete)
            {
                sortedQuests = quests.OrderBy(q => q.Complete);
            }

            Console.WriteLine($"Id\tDone\tReward\tGoal"); 

            foreach (var quest in sortedQuests)
            {
                Console.WriteLine($"{quest.Id}\t{quest.Complete}\t{quest.Reward}\t{quest.Goal}");
            }

        }
    }
}