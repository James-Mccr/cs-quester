using System;
using System.Collections.Generic;
using System.IO;
using CommandLine;
using CommandLineQuester.CommandLineOptions;
using CommandLineQuester.Commands;
using Newtonsoft.Json;
using Quester.Completers;
using Quester.Creators;
using Quester.DefaultValueConverters;
using Quester.Deleters;
using Quester.Factories;
using Quester.Models;
using Quester.Readers;
using Quester.Sequencers;
using Quester.Serialisers;
using Quester.StreamProviders;
using Quester.TextReaderProviders;
using Quester.TextWriterProviders;
using Quester.Updaters;
using Quester.Writers;

namespace CommandLineQuester
{
    public class CommandLineQuester
    {
        public static void Main(string[] args)
        {
            var readOptions = new FileStreamOptions 
            { 
                Access = FileAccess.Read,
                Mode = FileMode.OpenOrCreate    
            };
            var writeOptions = new FileStreamOptions 
            { 
                Access = FileAccess.Write,
                Mode = FileMode.Create    
            };
            var serialiserSettings = new JsonSerializerSettings() { Formatting = Formatting.Indented };
            var idSequencer = new IncrementalIntSequencer();

            var questKeyValueFactory = new KeyValueFactory<int, Quest>();
            var questDefaultValueConverter = new NullDefaultValueConverter<IDictionary<int, Quest>>(questKeyValueFactory);
            var questReader = MakeReader<IDictionary<int, Quest>>(serialiserSettings, "quests.json", readOptions, questDefaultValueConverter);
            var questWriter = MakeWriter<IDictionary<int, Quest>>(serialiserSettings, "quests.json", writeOptions, questDefaultValueConverter);
            var questCreator = new KeyValueCreator<int, Quest>(questReader, questWriter, idSequencer);
            var questUpdater = new KeyValueUpdater<int, Quest>(questReader, questWriter);
            var questDeleter = new KeyValueDeleter<int, Quest>(questReader, questWriter);
            var questCompleter = new QuestCompleter(questReader, questWriter);
            var createQuestCommand = new CreateQuestCommand(questCreator);
            var readQuestCommand = new ReadQuestCommand(questReader);
            var updateQuestCommand = new UpdateQuestCommand(questUpdater);
            var deleteQuestCommand = new DeleteQuestCommand(questDeleter);
            var completeQuestCommand = new CompleteQuestCommand(questCompleter);

            Parser.Default.ParseArguments<CreateQuestOptions, ReadQuestOptions, UpdateQuestOptions, DeleteQuestOptions, CompleteQuestOptions>(args)
                .WithParsed<CreateQuestOptions>(createQuestCommand.Run)
                .WithParsed<ReadQuestOptions>(readQuestCommand.Run)
                .WithParsed<UpdateQuestOptions>(updateQuestCommand.Run)
                .WithParsed<DeleteQuestOptions>(deleteQuestCommand.Run)
                .WithParsed<CompleteQuestOptions>(completeQuestCommand.Run)
                .WithNotParsed(errors => 
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error.ToString());
                    }
                });

            IReader<T> MakeReader<T>(
                JsonSerializerSettings serialiserSettings,
                string file,
                FileStreamOptions fileStreamOptions,
                IDefaultValueConverter<T> defaultValueConverter)
            {
                var questSerialiser = new JsonSerialiser<T>(serialiserSettings, defaultValueConverter);
                var questsReadOnlyFileStreamProvider = new FileStreamProvider(file, readOptions);
                var questsTextReaderProvider = new StreamReaderProvider(questsReadOnlyFileStreamProvider);
                var questsStringReader = new Quester.Readers.StringReader(questsTextReaderProvider);
                return new JsonReader<T>(questsStringReader, questSerialiser);
            }

            IWriter<T> MakeWriter<T>(
                JsonSerializerSettings serialiserSettings,
                string file,
                FileStreamOptions fileStreamOptions,
                IDefaultValueConverter<T> defaultValueConverter)
            {
                var questSerialiser = new JsonSerialiser<T>(serialiserSettings, defaultValueConverter);
                var questsWriteOnlyFileStreamProvider = new FileStreamProvider(file, writeOptions);
                var questsTextWriterProvider = new StreamWriterProvider(questsWriteOnlyFileStreamProvider);
                var questsStringWriter = new Quester.Writers.StringWriter(questsTextWriterProvider);
                return new JsonWriter<T>(questsStringWriter, questSerialiser);
            }

        }
    }
}