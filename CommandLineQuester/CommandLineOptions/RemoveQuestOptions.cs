using CommandLine;

namespace CommandLineQuester.CommandLineOptions
{
    [Verb("remove-quest", HelpText="Add a quest")]
    public class RemoveQuestOptions
    {
        [Option('i', "id", Required = true, HelpText = "Id of quest to remove")]
        public int Id { get; set; }
    }
}