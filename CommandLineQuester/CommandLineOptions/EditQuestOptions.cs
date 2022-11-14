using CommandLine;

namespace CommandLineQuester.CommandLineOptions
{
    [Verb("edit-quest", HelpText = "Make changes to a quest")]
    public class EditQuestOptions
    {
        [Option('i', "id", Required = true, HelpText = "Id of a quest")]
        public int Id { get; set; }
        [Option('r', "reward", Required = false, HelpText = "Reward upon completing quest")]
        public int Reward { get; set; }
        [Option('g', "goal", Required = false, HelpText = "Goal to complete quest")]
        public string Goal { get; set; }
    }
}