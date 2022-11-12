using CommandLineQuester.CommandLineOptions;
using Quester.Models;
using Quester.Readers;
using Quester.SetConverters;
using Quester.SetIdentifiers;
using Quester.Writers;
using System.Collections.Generic;

namespace CommandLineQuester.Commands
{
    public class AddQuest
    {
        public IReader<IEnumerable<Quest>> QuestsReader { get; }
        public IWriter<IEnumerable<Quest>> QuestsWriter { get; }
        public ISetConverter<Quest> QuestSetConverter { get; }
        public ISetIdentifier<Quest> QuestSetIdentifier { get; }

        public AddQuest(
            IReader<IEnumerable<Quest>> questsReader, 
            IWriter<IEnumerable<Quest>> questsWriter, 
            ISetConverter<Quest> questSetConverter, 
            ISetIdentifier<Quest> questSetIdentifier)
        {
            QuestsReader = questsReader;
            QuestsWriter = questsWriter;
            QuestSetConverter = questSetConverter;
            QuestSetIdentifier = questSetIdentifier;
        }

        public int Run(AddQuestOptions options)
        {
            var quests = QuestsReader.Read();
            var questSet = QuestSetConverter.Convert(quests);
            var nextId = QuestSetIdentifier.NextId(questSet);
            var quest = new Quest(nextId, options.Reward, options.Goal, false);
            questSet.Add(quest);
            QuestsWriter.Write(questSet);
            return 0;
        }
    }
}