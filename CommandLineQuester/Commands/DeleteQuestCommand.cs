using CommandLineQuester.CommandLineOptions;
using Quester.Collections.Deleters;
using Quester.Collections.Selectors;
using Quester.Quests;

namespace CommandLineQuester.Commands
{
    public class DeleteQuestCommand
    {        
        public IDeleter<Quest> Deleter { get; }
        public ISelector<Quest> Selector { get; }

        public DeleteQuestCommand(IDeleter<Quest> deleter, ISelector<Quest> selector)
        {
            Deleter = deleter;
            Selector = selector;
        }

        public void Run(DeleteQuestOptions options)
        {
            var quest = Selector.Select(options.Id);
            Deleter.Delete(quest);
        }
    }
}