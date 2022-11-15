using System;
using System.Collections.Generic;
using CommandLineQuester.CommandLineOptions;
using Quester.Models;
using Quester.Readers;

namespace CommandLineQuester.Commands
{
    public class ReadQuestCommand
    {        
        public IReader<IDictionary<int, Quest>> Reader { get; }

        public ReadQuestCommand(IReader<IDictionary<int, Quest>> reader)
        {
            Reader = reader;
        }

        public void Run(ReadQuestOptions options)
        {
            var quests = Reader.Read();
            Console.WriteLine($"Id, Reward, Goal, Complete"); 

            if (options.Id < 0)
            {   
                foreach (var quest in quests)
                {
                    Console.WriteLine($"{quest.Key}, {quest.Value.Reward}, {quest.Value.Goal}, {quest.Value.Complete}");
                }
            }
            else 
            {
                var quest = quests[options.Id];
                Console.WriteLine($"{options.Id}, {quest.Reward}, {quest.Goal}, {quest.Complete}");
            }
        }
    }
}