using CommandLine;

namespace CommandLineQuester.CommandLineOptions
{
    [Verb("list-quests", HelpText="Diplay quests")]
    public class ReadQuestOptions 
    {
        [Option('i', "id", Required = false, HelpText = "Id of a quest")]
        public int Id { get; set; } = -1;
    }
}