using CommandLine;

namespace CommandLineQuester.CommandLineOptions
{
    [Verb("add-quest", HelpText="Add a quest")]
    public class AddQuestOptions
    {
        [Option('r', "reward", Required = true, HelpText = "Reward upon completing quest")]
        public int Reward { get; set; }
        [Option('g', "goal", Required = true, HelpText = "Goal to complete quest")]
        public string Goal { get; set; }
    }
}