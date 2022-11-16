using CommandLine;

namespace CommandLineQuester.CommandLineOptions
{
    [Verb("delete-quest", HelpText="Remove a quest")]
    public class DeleteQuestOptions
    {
        [Option('i', "id", Required = true, HelpText = "Id of a quest")]
        public int Id { get; set; }
    }
}