using CommandLine;

namespace Quester.Commandline.Options
{
    [Verb("remove", aliases:new[] { "complete" }, HelpText="Remove a quest")]
    public class DeleteQuestOptions
    {
        [Option('i', "id", Required = true, HelpText = "Id of a quest")]
        public int Id { get; set; }
    }
}