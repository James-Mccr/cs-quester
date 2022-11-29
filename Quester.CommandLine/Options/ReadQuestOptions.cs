using CommandLine;

namespace Quester.Commandline.Options
{
    [Verb("list-quests", HelpText="Display quests")]
    public class ReadQuestOptions 
    {
        [Option("sort-reward", Required = false, SetName = "sort", HelpText = "Sort quests by reward")]
        public bool SortByReward { get; set; }
        [Option("sort-goal", Required = false, SetName = "sort", HelpText = "Sort quests by goal")]
        public bool SortByGoal { get; set; }
        [Option("sort-complete", Required = false, SetName = "sort", HelpText = "Sort quests by complete")]
        public bool SortByComplete { get; set; }
        [Option('h', "hide-complete", Required = false, HelpText = "Flag to hide completed quests")]
        public bool HideComplete { get; set; }
    }
}