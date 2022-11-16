using CommandLine;

namespace CommandLineQuester.CommandLineOptions
{
    [Verb("complete-quest", HelpText="Complete a quest")]
    public class CompleteQuestOptions
    {
        [Option('i', "id", Required = true, HelpText = "Id of a quest ")]
        public int Id { get; set; }
    }
}