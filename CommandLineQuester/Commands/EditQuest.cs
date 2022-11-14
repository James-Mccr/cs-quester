using System.Collections.Generic;
using CommandLineQuester.CommandLineOptions;
using Quester.Models;
using Quester.Readers;
using Quester.SetConverters;
using Quester.SetSelectors;
using Quester.Writers;

namespace CommandLineQuester.Commands
{
    public class EditQuest
    {
        public IReader<IEnumerable<Quest>> QuestsReader { get; }
        public IWriter<IEnumerable<Quest>> QuestsWriter { get; }
        public ISetConverter<Quest> QuestSetConverter { get; }
        public ISetSelector<Quest> QuestSetSelector { get; }

        public EditQuest(            
            IReader<IEnumerable<Quest>> questsReader, 
            IWriter<IEnumerable<Quest>> questsWriter, 
            ISetConverter<Quest> questSetConverter, 
            ISetSelector<Quest> questSetSelector)
        {
            QuestsReader = questsReader;
            QuestsWriter = questsWriter;
            QuestSetConverter = questSetConverter;
            QuestSetSelector = questSetSelector;
        }

        public int Run(EditQuestOptions options)
        {
            var quests = QuestsReader.Read();
            var questSet = QuestSetConverter.Convert(quests);
            var quest = QuestSetSelector.Select(questSet, options.Id);
            quest.Reward = options.Reward;
            quest.Goal = options.Goal;
            QuestsWriter.Write(questSet);
            return 0;
        }
    }
}