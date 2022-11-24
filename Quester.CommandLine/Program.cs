using System;
using System.Collections.Generic;
using System.IO;
using CommandLine;
using Common.Collections.Creators;
using Common.Collections.Deleters;
using Common.Collections.Readers;
using Common.Collections.Updaters;
using Common.Identities.Selectors;
using Common.Identities.Sequencers;
using Common.Io.Converters;
using Common.Io.Factories;
using Common.Io.Inputs;
using Common.Io.Outputs;
using Common.Io.Serialisers;
using Common.Io.StreamProviders;
using Common.Io.TextReaderProviders;
using Common.Io.TextWriterProviders;
using Newtonsoft.Json;
using Quester.Commandline.Commands;
using Quester.Commandline.Options;
using Quester.Quests;

namespace Quester.CommandLine
{
    public class Program
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

            Directory.CreateDirectory(Common.App.Paths.DefaultFolder);
            var questFilePath = Path.Combine(Common.App.Paths.DefaultFolder, Quester.Settings.QuestFile);
            var questConverter = new NullCollectionConverter<Quest>(new CollectionFactory<Quest>());
            var questInput = MakeJsonInput<ICollection<Quest>>(serialiserSettings, questFilePath, readOptions, questConverter);
            var questOutput = MakeJsonOutput<IEnumerable<Quest>>(serialiserSettings, questFilePath, writeOptions, null);
            var questReader = new CollectionReader<Quest>(questInput);
            var questCreator = new CollectionCreator<Quest>(questInput, questOutput);
            var questUpdater = new CollectionUpdater<Quest>(questInput, questOutput);
            var questDeleter = new CollectionDeleter<Quest>(questInput, questOutput);

            var readQuestCommand = new ReadQuestCommand(questReader);
            var createQuestCommand = new CreateQuestCommand(questCreator, questReader, new IncrementalSequencer());
            var deleteQuestCommand = new DeleteQuestCommand(questDeleter, questReader, new CollectionSelector<Quest>());
            var updateQuestCommand = new UpdateQuestCommand(questUpdater, questReader, new CollectionSelector<Quest>());
            var completeQuestCommand = new CompleteQuestCommand(questUpdater, questReader, new CollectionSelector<Quest>());

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

            IInput<T> MakeJsonInput<T>(
                JsonSerializerSettings serialiserSettings,
                string file,
                FileStreamOptions fileStreamOptions,
                IConverter<T> defaultValueConverter)
            {
                var questSerialiser = new JsonSerialiser<T>(serialiserSettings, defaultValueConverter);
                var questsReadOnlyFileStreamProvider = new FileStreamProvider(file, readOptions);
                var questsTextReaderProvider = new StreamReaderProvider(questsReadOnlyFileStreamProvider);
                var questsStringReader = new StringInput(questsTextReaderProvider);
                return new JsonInput<T>(questsStringReader, questSerialiser);
            }

            IOutput<T> MakeJsonOutput<T>(
                JsonSerializerSettings serialiserSettings,
                string file,
                FileStreamOptions fileStreamOptions,
                IConverter<T> defaultValueConverter)
            {
                var questSerialiser = new JsonSerialiser<T>(serialiserSettings, defaultValueConverter);
                var questsWriteOnlyFileStreamProvider = new FileStreamProvider(file, writeOptions);
                var questsTextWriterProvider = new StreamWriterProvider(questsWriteOnlyFileStreamProvider);
                var questsStringWriter = new StringOutput(questsTextWriterProvider);
                return new JsonOutput<T>(questsStringWriter, questSerialiser);
            }

        }
    }
}