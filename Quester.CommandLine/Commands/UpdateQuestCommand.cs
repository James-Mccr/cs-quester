using Quester.Commandline.Options;
using Common.Collections.Readers;
using Common.Collections.Updaters;
using Common.Identities.Identifiers;
using Common.Identities.Selectors;

namespace Quester.Commandline.Commands
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