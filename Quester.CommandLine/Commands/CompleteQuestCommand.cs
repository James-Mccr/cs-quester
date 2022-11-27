using Quester.Commandline.Options;
using Common.Collections.Readers;
using Common.Collections.Updaters;
using Common.Identities.Identifiers;
using Common.Identities.Selectors;
using Common.Io.Inputs;
using Common.Io.Outputs;
using Common.Journals;

namespace Quester.Commandline.Commands
{
    public class CompleteQuestCommand
    {
        public IUpdater<Quest> QuestUpdater { get; }
        public IReader<Quest> QuestReader { get; }
        public ISelector<Quest> QuestSelector { get; }
        public IInput<Journal> JournalInput { get; }
        public IOutput<Journal> JournalOutput { get; }

        public CompleteQuestCommand(IUpdater<Quest> questUpdater,
                                    IReader<Quest> questReader,
                                    ISelector<Quest> questSelector,
                                    IInput<Journal> journalInput,
                                    IOutput<Journal> journalOutput)
        {
            QuestUpdater = questUpdater;
            QuestReader = questReader;
            QuestSelector = questSelector;
            JournalInput = journalInput;
            JournalOutput = journalOutput;
        }

        public void Run(CompleteQuestOptions options)
        {
            var quests = QuestReader.Read();
            var quest = QuestSelector.Select(quests, new Identifier(options.Id));
            if (quest.Complete)
                return;
            quest.Complete = true;
            QuestUpdater.Update(quest);

            var journal = JournalInput.Get();   // todo refactor into a journal updater
            journal.Merits += quest.Reward;
            JournalOutput.Set(journal);
        }
    }
}