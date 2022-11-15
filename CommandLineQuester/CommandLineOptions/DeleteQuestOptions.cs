using CommandLine;

namespace CommandLineQuester.CommandLineOptions
{
    [Verb("delete-quest", HelpText="Remove a quest")]
    public class DeleteQuestOptions
    {
        [Option('i', "id", Required = true, HelpText = "Id of quest to remove")]
        public int Id { get; set; }
    }
}