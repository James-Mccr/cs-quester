using CommandLine;

namespace Quester.Commandline.Options
{
    [Verb("delete-quest", HelpText="Remove a quest")]
    public class DeleteQuestOptions
    {
        [Option('i', "id", Required = true, HelpText = "Id of a quest")]
        public int Id { get; set; }
    }
}