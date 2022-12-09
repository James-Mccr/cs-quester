using CommandLine;

namespace Quester.Commandline.Options
{
    [Verb("update", HelpText = "Edit a quest")]
    public class UpdateQuestOptions
    {
        [Option('i', "id", Required = true, HelpText = "Id of a quest")]
        public int Id { get; set; }
        [Option('g', "goal", Required = true, HelpText = "Goal to complete quest")]
        public string Goal { get; set; }
    }
}