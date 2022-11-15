using System;
using System.Collections.Generic;
using CommandLineQuester.CommandLineOptions;
using Quester.Creators;
using Quester.Models;

namespace CommandLineQuester.Commands
{
    public class CreateQuestCommand
    {        
        public ICreator<Quest, KeyValuePair<int, Quest>> Creator { get; }

        public CreateQuestCommand(ICreator<Quest, KeyValuePair<int, Quest>> creator)
        {
            Creator = creator;
        }

        public void Run(CreateQuestOptions options)
        {
            var quest = new Quest(options.Reward, options.Goal, false);
            var pair = Creator.Create(quest);
            Console.WriteLine($"Created quest {pair.Key}!");
        }
    }
}