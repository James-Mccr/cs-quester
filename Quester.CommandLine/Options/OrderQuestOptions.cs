using CommandLine;

namespace Quester.Commandline.Options
{
    [Verb("order", HelpText = "Reorder quests")]
    public class OrderQuestOptions
    {
        [Option('i', "id", Required = true, HelpText = "Id of a quest")]
        public int Id { get; set; }
        [Option('o', "order", Required = true, HelpText = "Desired order")]
        public int Priority { get; set; }
    }
}