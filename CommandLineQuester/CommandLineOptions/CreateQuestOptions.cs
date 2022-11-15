using CommandLine;

namespace CommandLineQuester.CommandLineOptions
{
    [Verb("create-quest", HelpText="Add a quest")]
    public class CreateQuestOptions
    {
        [Option('r', "reward", Required = true, HelpText = "Reward upon completing quest")]
        public int Reward { get; set; }
        [Option('g', "goal", Required = true, HelpText = "Goal to complete quest")]
        public string Goal { get; set; }
    }
}