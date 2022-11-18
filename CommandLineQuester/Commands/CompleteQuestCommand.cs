using CommandLineQuester.CommandLineOptions;
using Quester.Collections.Selectors;
using Quester.Collections.Updaters;
using Quester.Quests;

namespace CommandLineQuester.Commands
{
    public class CompleteQuestCommand
    {
        public IUpdater<Quest> QuestUpdater { get; }
        public ISelector<Quest> QuestSelector { get; }

        public CompleteQuestCommand(IUpdater<Quest> questUpdater, ISelector<Quest> questSelector)
        {
            QuestUpdater = questUpdater;
            QuestSelector = questSelector;
        }

        public void Run(CompleteQuestOptions options)
        {
            var quest = QuestSelector.Select(options.Id);
            if (quest.Complete)
                return;
            quest.Complete = true;
            QuestUpdater.Update(quest);
        }
    }
}