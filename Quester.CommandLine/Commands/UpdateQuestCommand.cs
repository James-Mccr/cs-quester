using Quester.Commandline.Options;
using Common.Collections.Readers;
using Common.Identities.Identifiers;
using Common.Identities.Selectors;
using Common.Io.Outputs;
using System.Collections.Generic;

namespace Quester.Commandline.Commands
{
    public class UpdateQuestCommand
    {        
        public IReader<Quest> QuestReader { get; }
        public IOutput<IEnumerable<Quest>> QuestWriter { get; }
        public ISelector<Quest, IIdentifier> QuestIdSelector { get; }

        public UpdateQuestCommand(
            IReader<Quest> questReader,
            IOutput<IEnumerable<Quest>> questWriter,
            ISelector<Quest, IIdentifier> questIdSelector)
        {
            QuestIdSelector = questIdSelector;
            QuestReader = questReader;
            QuestWriter = questWriter;
        }

        public void Run(UpdateQuestOptions options)
        {
            var quests = QuestReader.Read();
            var quest = QuestIdSelector.Select(quests, new Identifier(options.Id));
            quest.Goal = options.Goal;
            QuestWriter.Set(quests);
        }
    }
}