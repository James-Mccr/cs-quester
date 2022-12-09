using CommandLine;

namespace Quester.Commandline.Options
{
    [Verb("create", HelpText="Add a quest")]
    public class CreateQuestOptions
    {
        [Option('g', "goal", Required = true, HelpText = "Goal to complete quest")]
        public string Goal { get; set; }
    }
}