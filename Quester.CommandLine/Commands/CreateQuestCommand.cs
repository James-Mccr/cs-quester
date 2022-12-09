using Quester.Commandline.Options;
using Common.Collections.Creators;
using Common.Collections.Readers;
using Common.Identities.Identifiers;
using Common.Identities.Sequencers;
using Common.Identities.Priorities;
using Common.Io.Outputs;
using System.Collections.Generic;

namespace Quester.Commandline.Commands
{
    public class CreateQuestCommand
    {        
        public ICreator<Quest> Creator { get; }
        public IReader<Quest> Reader { get; }
        public IOutput<IEnumerable<Quest>> QuestWriter { get; }
        public ISequencer<IIdentifier> IdSequencer { get; }
        public ISequencer<IPriority> PrioritySequencer { get; }

        public CreateQuestCommand(
            ICreator<Quest> creator,
            IReader<Quest> reader,
            IOutput<IEnumerable<Quest>> writer,
            ISequencer<IIdentifier> idSequencer,
            ISequencer<IPriority> prioritySequencer)
        {
            Creator = creator;
            Reader = reader;
            QuestWriter = writer;
            IdSequencer = idSequencer;
            PrioritySequencer = prioritySequencer;
        }

        public void Run(CreateQuestOptions options)
        {
            var quests = Reader.Read();
            var nextId = IdSequencer.Next(quests);
            var nextPriority = PrioritySequencer.Next(quests);
            var quest = new Quest(nextId.Id, nextPriority.Priority, options.Goal);
            Creator.Create(quests, new[] { quest });
            QuestWriter.Set(quests);
        }
    }
}