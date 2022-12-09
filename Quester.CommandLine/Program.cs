using System;
using System.Collections.Generic;
using System.IO;
using CommandLine;
using Common.Collections.Creators;
using Common.Collections.Deleters;
using Common.Collections.Readers;
using Common.Identities.Selectors;
using Common.Identities.Sequencers;
using Common.Identities.Shifters;
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

            Common.App.Paths.CreateDefaultFolder();
            var questFilePath = Path.Combine(Common.App.Paths.DefaultFolder, Quester.QuesterSettings.QuestFile);
            var questConverter = new NullConverter<ICollection<Quest>>(new CollectionFactory<Quest>());
            var questInput = MakeJsonInput<ICollection<Quest>>(serialiserSettings, questFilePath, readOptions, questConverter);
            var questOutput = MakeJsonOutput<IEnumerable<Quest>>(serialiserSettings, questFilePath, writeOptions, null);
            var questReader = new CollectionReader<Quest>(questInput.Get());
            var questCreator = new CollectionCreator<Quest>();
            var questDeleter = new CollectionDeleter<Quest>();

            var questSelector = new IdentifierSelector<Quest>();
            var lowerPriorityShifter = new PriorityShifter(1);
            var higherPriorityShifter = new PriorityShifter(-1);

            var readQuestCommand = new ReadQuestCommand(questReader);
            var createQuestCommand = new CreateQuestCommand(questCreator, questReader, questOutput, new IdentifierSequencer(), new PrioritySequencer());
            var deleteQuestCommand = new DeleteQuestCommand(questDeleter, questReader, questOutput, questSelector, higherPriorityShifter);
            var updateQuestCommand = new UpdateQuestCommand(questReader, questOutput, questSelector);
            var orderQuestCommand = new OrderQuestCommand(questReader, questOutput, questSelector, lowerPriorityShifter, higherPriorityShifter);

            Parser.Default.ParseArguments<CreateQuestOptions, ReadQuestOptions, UpdateQuestOptions, DeleteQuestOptions, OrderQuestOptions>(args)
                .WithParsed<ReadQuestOptions>(readQuestCommand.Run)
                .WithParsed<CreateQuestOptions>(createQuestCommand.Run)
                .WithParsed<UpdateQuestOptions>(updateQuestCommand.Run)
                .WithParsed<DeleteQuestOptions>(deleteQuestCommand.Run)
                .WithParsed<OrderQuestOptions>(orderQuestCommand.Run)
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