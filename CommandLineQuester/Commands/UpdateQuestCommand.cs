using CommandLineQuester.CommandLineOptions;
using Quester.Collections.Selectors;
using Quester.Collections.Updaters;
using Quester.Quests;

namespace CommandLineQuester.Commands
{
    public class UpdateQuestCommand
    {        
        public IUpdater<Quest> Updater { get; }
        public ISelector<Quest> Selector { get; }

        public UpdateQuestCommand(IUpdater<Quest> updater, ISelector<Quest> selector)
        {
            Updater = updater;
            Selector = selector;
        }

        public void Run(UpdateQuestOptions options)
        {
            var quest = Selector.Select(options.Id);
            quest.Complete = options.Complete;
            quest.Goal = options.Goal;
            quest.Reward = options.Reward;
            Updater.Update(quest);
        }
    }
}