using System.Collections.Generic;
using CommandLineQuester.CommandLineOptions;
using Quester.Models;
using Quester.Readers;
using Quester.SetConverters;
using Quester.SetSelectors;
using Quester.Writers;

namespace CommandLineQuester.Commands
{
    public class RemoveQuest
    {
        public IReader<IEnumerable<Quest>> QuestsReader { get; }
        public IWriter<IEnumerable<Quest>> QuestsWriter { get; }
        public ISetConverter<Quest> QuestSetConverter { get; }
        public ISetSelector<Quest> QuestSetSelector { get; }

        public RemoveQuest(
            IReader<IEnumerable<Quest>> questsReader, 
            IWriter<IEnumerable<Quest>> questsWriter, 
            ISetConverter<Quest> questSetConverter, 
            ISetSelector<Quest> questSetIdentifier)
        {
            QuestsReader = questsReader;
            QuestsWriter = questsWriter;
            QuestSetConverter = questSetConverter;
            QuestSetSelector = questSetIdentifier;
        }

        public int Run(RemoveQuestOptions options)
        {
            var quests = QuestsReader.Read();
            var questSet = QuestSetConverter.Convert(quests);
            var quest = QuestSetSelector.Select(questSet, options.Id);
            questSet.Remove(quest);
            QuestsWriter.Write(questSet);
            return 0;
        }
    }
}