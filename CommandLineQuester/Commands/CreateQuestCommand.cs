using CommandLineQuester.CommandLineOptions;
using Quester.Collections.Creators;
using Quester.Collections.Readers;
using Quester.Collections.Sequencers;
using Quester.Quests;

namespace CommandLineQuester.Commands
{
    public class CreateQuestCommand
    {        
        public ICreator<Quest> Creator { get; }
        public IReader<Quest> Reader { get; }
        public ISequencer<Quest> Sequencer { get; }

        public CreateQuestCommand(ICreator<Quest> creator, IReader<Quest> reader, ISequencer<Quest> sequencer)
        {
            Creator = creator;
            Reader = reader;
            Sequencer = sequencer;
        }

        public void Run(CreateQuestOptions options)
        {
            var quests = Reader.Read();
            var quest = Sequencer.Next(quests);
            quest.Complete = false;
            quest.Goal = options.Goal;
            quest.Reward = options.Reward;
            Creator.Create(quest);
        }
    }
}