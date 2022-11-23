using Quester.Commandline.Options;
using Common.Collections.Readers;
using Common.Collections.Updaters;
using Common.Identities.Identifiers;
using Common.Identities.Selectors;
using Quester.Quests;

namespace Quester.Commandline.Commands
{
    public class CompleteQuestCommand
    {
        public IUpdater<Quest> QuestUpdater { get; }
        public IReader<Quest> QuestReader { get; }
        public ISelector<Quest> QuestSelector { get; }

        public CompleteQuestCommand(IUpdater<Quest> questUpdater, IReader<Quest> questReader, ISelector<Quest> questSelector)
        {
            QuestUpdater = questUpdater;
            QuestReader = questReader;
            QuestSelector = questSelector;
        }

        public void Run(CompleteQuestOptions options)
        {
            var quests = QuestReader.Read();
            var quest = QuestSelector.Select(quests, new Identifier(options.Id));
            if (quest.Complete)
                return;
            quest.Complete = true;
            QuestUpdater.Update(quest);
        }
    }
}