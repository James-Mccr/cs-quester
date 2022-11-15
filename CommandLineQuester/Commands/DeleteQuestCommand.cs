using System;
using CommandLineQuester.CommandLineOptions;
using Quester.Deleters;

namespace CommandLineQuester.Commands
{
    public class DeleteQuestCommand
    {        
        public IDeleter<int> Deleter { get; }

        public DeleteQuestCommand(IDeleter<int> deleter)
        {
            Deleter = deleter;
        }

        public void Run(DeleteQuestOptions options)
        {
            var deleted = Deleter.Delete(options.Id);
            if (!deleted)
            {
                Console.WriteLine("FAILED!");
            }
            else 
            {
                Console.WriteLine($"Deleted quest {options.Id}!");
            }
        }
    }
}