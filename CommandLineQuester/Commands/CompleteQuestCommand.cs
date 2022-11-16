using System;
using CommandLineQuester.CommandLineOptions;
using Quester.Completers;

namespace CommandLineQuester.Commands
{
    public class CompleteQuestCommand
    {
        public ICompleter Completer { get; }
        
        public CompleteQuestCommand(ICompleter completer)
        {
            Completer = completer;
        }

        public void Run(CompleteQuestOptions options)
        {
            var completed = Completer.Complete(options.Id);
            if (completed)
            {
                Console.WriteLine($"Completed quest {options.Id}!");
            }
            else
            {
                Console.WriteLine("FAILED!");
            }
        }
    }
}