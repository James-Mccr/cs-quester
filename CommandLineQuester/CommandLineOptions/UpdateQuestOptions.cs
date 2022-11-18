using CommandLine;

namespace CommandLineQuester.CommandLineOptions
{
    [Verb("update-quest", HelpText = "Change a quest")]
    public class UpdateQuestOptions
    {
        [Option('i', "id", Required = true, HelpText = "Id of a quest")]
        public int Id { get; set; }
        [Option('g', "goal", Required = true, HelpText = "Goal to complete quest")]
        public string Goal { get; set; }
        [Option('r', "reward", Required = true, HelpText = "Reward upon completing quest")]
        public int Reward { get; set; }
        [Option('c', "complete", HelpText = "Status of quest")]
        public bool Complete { get; set; }
    }
}