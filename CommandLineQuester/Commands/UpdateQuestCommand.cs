using System;
using CommandLineQuester.CommandLineOptions;
using Quester.Models;
using Quester.Updaters;

namespace CommandLineQuester.Commands
{
    public class UpdateQuestCommand
    {        
        public IUpdater<int, Quest> Updater { get; }        

        public UpdateQuestCommand(IUpdater<int, Quest> updater)
        {
            Updater = updater;
        }

        public void Run(UpdateQuestOptions options)
        {
            var quest = new Quest(options.Reward, options.Goal, options.Complete);
            var updated = Updater.Update(options.Id, quest);
            if (!updated)
            {
                Console.WriteLine("FAILED!");
            }
            else 
            {
                Console.WriteLine($"Updated quest {options.Id}!");
            }
            
        }
    }
}