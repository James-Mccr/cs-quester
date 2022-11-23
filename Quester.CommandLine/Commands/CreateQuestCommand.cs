using Quester.Commandline.Options;
using Common.Collections.Creators;
using Common.Collections.Readers;
using Common.Identities.Identifiers;
using Common.Identities.Sequencers;
using Quester.Quests;

namespace Quester.Commandline.Commands
{
    public class CreateQuestCommand
    {        
        public ICreator<Quest> Creator { get; }
        public IReader<Quest> Reader { get; }
        public ISequencer<IIdentifier> Sequencer { get; }

        public CreateQuestCommand(ICreator<Quest> creator, IReader<Quest> reader, ISequencer<IIdentifier> sequencer)
        {
            Creator = creator;
            Reader = reader;
            Sequencer = sequencer;
        }

        public void Run(CreateQuestOptions options)
        {
            var quests = Reader.Read();
            var nextIdentifier = Sequencer.Next(quests);
            var quest = new Quest(nextIdentifier.Id, options.Reward, options.Goal, false);
            Creator.Create(quest);
        }
    }
}