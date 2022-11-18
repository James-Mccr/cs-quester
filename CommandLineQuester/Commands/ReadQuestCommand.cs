using System;
using CommandLineQuester.CommandLineOptions;
using Quester.Collections.Readers;
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
            Console.WriteLine($"Id, Reward, Goal, Complete"); 

            var id = 0;
            foreach (var quest in quests)
            {
                Console.WriteLine($"{id++}, {quest.Reward}, {quest.Goal}, {quest.Complete}");
            }

        }
    }
}