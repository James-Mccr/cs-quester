using Quester.Commandline.Options;
using Common.Collections.Deleters;
using Common.Collections.Readers;
using Common.Identities.Identifiers;
using Common.Identities.Selectors;
using Common.Io.Outputs;
using System.Collections.Generic;
using Common.Identities.Shifters;
using Common.Identities.Priorities;

namespace Quester.Commandline.Commands
{
    public class DeleteQuestCommand
    {        
        public IDeleter<Quest> QuestDeleter { get; }
        public IReader<Quest> QuestReader { get; }
        public IOutput<IEnumerable<Quest>> QuestWriter { get; }
        public ISelector<Quest, IIdentifier> QuestSelector { get; }
        public IShifter<IPriority> QuestShifter { get; }

        public DeleteQuestCommand(
            IDeleter<Quest> questDeleter,
            IReader<Quest> questReader,
            IOutput<IEnumerable<Quest>> questWriter,
            ISelector<Quest, IIdentifier> questSelector,
            IShifter<IPriority> questShifter)
        {
            QuestDeleter = questDeleter;
            QuestReader = questReader;
            QuestWriter = questWriter;
            QuestSelector = questSelector;
            QuestShifter = questShifter;
        }

        public void Run(DeleteQuestOptions options)
        {
            var quests = QuestReader.Read();
            var quest = QuestSelector.Select(quests, new Identifier(options.Id));
            QuestDeleter.Delete(quests, new[] { quest });
            QuestShifter.Shift(quests, quest, new BasicPriority(int.MaxValue));
            QuestWriter.Set(quests);
        }
    }
}