using System;
using System.Collections.Generic;
using CommandLine;
using CommandLineQuester.CommandLineOptions;
using CommandLineQuester.Commands;
using Newtonsoft.Json;
using Quester.Comparers;
using Quester.EqualityComparers;
using Quester.Models;
using Quester.Readers;
using Quester.Serialisers;
using Quester.SetConverters;
using Quester.SetIdentifiers;
using Quester.SetSelectors;
using Quester.StreamProviders;
using Quester.TextReaderProviders;
using Quester.TextWriterProviders;
using Quester.Writers;

namespace CommandLineQuester
{
    public class CommandLineQuester
    {
        public static void Main(string[] args)
        {
            var serialiserSettings = new JsonSerializerSettings() { Formatting = Formatting.Indented };
            var questSerialiser = new JsonSerialiser<IEnumerable<Quest>>(serialiserSettings);
            var readOptions = new System.IO.FileStreamOptions 
            { 
                Access = System.IO.FileAccess.Read,
                Mode = System.IO.FileMode.OpenOrCreate    
            };
            var writeOptions = new System.IO.FileStreamOptions 
            { 
                Access = System.IO.FileAccess.Write,
                Mode = System.IO.FileMode.Create    
            };
            var readOnlyFileStreamProvider = new FileStreamProvider("quests.json", readOptions);
            var writeOnlyFileStreamProvider = new FileStreamProvider("quests.json", writeOptions);
            var textReaderProvider = new StreamReaderProvider(readOnlyFileStreamProvider);
            var textWriterProvider = new StreamWriterProvider(writeOnlyFileStreamProvider);
            var stringReader = new StringReader(textReaderProvider);
            var stringWriter = new StringWriter(textWriterProvider);
            var questReader = new JsonReader<IEnumerable<Quest>>(stringReader, questSerialiser);
            var questWriter = new JsonWriter<IEnumerable<Quest>>(stringWriter, questSerialiser);
            var questSetConverter = new HashSetConverter<Quest>(new QuestEqualityComparer());
            var questSetIdentifier = new QuestSetIdentifier(new QuestComparer());
            var questSetSelector = new QuestSetSelector();

            var addQuest = new AddQuest(questReader, questWriter, questSetConverter, questSetIdentifier);
            var removeQuest = new RemoveQuest(questReader, questWriter, questSetConverter, questSetSelector);
            var editQuest = new EditQuest(questReader, questWriter, questSetConverter, questSetSelector);

            Parser.Default.ParseArguments<AddQuestOptions, RemoveQuestOptions, EditQuestOptions>(args)
                .WithParsed<AddQuestOptions>(options => addQuest.Run(options))
                .WithParsed<RemoveQuestOptions>(options => removeQuest.Run(options))
                .WithParsed<EditQuestOptions>(options => editQuest.Run(options))
                .WithNotParsed(errors => 
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error.ToString());
                    }
                });

        }
    }
}