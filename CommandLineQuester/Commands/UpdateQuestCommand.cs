using CommandLineQuester.CommandLineOptions;
using Quester.Collections.Readers;
using Quester.Collections.Selectors;
using Quester.Collections.Updaters;
using Quester.Identities;
using Quester.Quests;

namespace CommandLineQuester.Commands
{
    public class UpdateQuestCommand
    {        
        public IUpdater<Quest> QuestUpdater { get; }
        public ISelector<Quest> QuestSelector { get; }
        public IReader<Quest> QuestReader { get; }

        public UpdateQuestCommand(IUpdater<Quest> questUpdater, IReader<Quest> questReader, ISelector<Quest> questSelector)
        {
            QuestUpdater = questUpdater;
            QuestSelector = questSelector;
            QuestReader = questReader;
        }

        public void Run(UpdateQuestOptions options)
        {
            var quests = QuestReader.Read();
            var quest = QuestSelector.Select(quests, new Identifier(options.Id));
            quest.Complete = options.Complete;
            quest.Goal = options.Goal;
            quest.Reward = options.Reward;
            QuestUpdater.Update(quest);
        }
    }
}