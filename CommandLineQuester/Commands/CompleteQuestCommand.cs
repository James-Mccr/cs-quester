using CommandLineQuester.CommandLineOptions;
using Quester.Collections.Readers;
using Quester.Collections.Selectors;
using Quester.Collections.Updaters;
using Quester.Identities;
using Quester.Quests;

namespace CommandLineQuester.Commands
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