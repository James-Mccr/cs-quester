using Quester.Commandline.Options;
using Common.Collections.Deleters;
using Common.Collections.Readers;
using Common.Identities.Identifiers;
using Common.Identities.Selectors;
using Quester.Quests;

namespace Quester.Commandline.Commands
{
    public class DeleteQuestCommand
    {        
        public IDeleter<Quest> QuestDeleter { get; }
        public IReader<Quest> QuestReader { get; }
        public ISelector<Quest> QuestSelector { get; }

        public DeleteQuestCommand(IDeleter<Quest> questDeleter, IReader<Quest> questReader, ISelector<Quest> questSelector)
        {
            QuestDeleter = questDeleter;
            QuestReader = questReader;
            QuestSelector = questSelector;
        }

        public void Run(DeleteQuestOptions options)
        {
            var quests = QuestReader.Read();
            var quest = QuestSelector.Select(quests, new Identifier(options.Id));
            QuestDeleter.Delete(quest);
        }
    }
}