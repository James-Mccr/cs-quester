using System;
using CommandLineQuester.CommandLineOptions;
using Quester.Collections.Readers;
using Quester.Collections.Utilities;
using Quester.Quests;

namespace CommandLineQuester.Commands
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
            if (quests.IsEmpty())
            {
                Console.WriteLine("No quests found!");
                return;
            }

            Console.WriteLine($"Id, Reward, Goal, Complete"); 

            foreach (var quest in quests)
            {
                Console.WriteLine($"{quest.Id}, {quest.Reward}, {quest.Goal}, {quest.Complete}");
            }

        }
    }
}