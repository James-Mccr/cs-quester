using System.Collections.Generic;
using Common.Collections.Readers;
using Common.Identities.Identifiers;
using Common.Identities.Priorities;
using Common.Identities.Selectors;
using Common.Identities.Shifters;
using Common.Io.Outputs;
using Quester.Commandline.Options;

namespace Quester.Commandline.Commands
{
    public class OrderQuestCommand
    {
        public IReader<Quest> QuestReader { get; }
        public IOutput<IEnumerable<Quest>> QuestWriter { get; }
        public ISelector<Quest, IIdentifier> QuestSelector { get; }
        public IShifter<IPriority> LowerPriorityShifter { get; }
        public IShifter<IPriority> HigherPriorityShifter { get; }

        public OrderQuestCommand(
            IReader<Quest> questReader,
            IOutput<IEnumerable<Quest>> questWriter,
            ISelector<Quest, IIdentifier> questSelector,
            IShifter<IPriority> lowerPriorityShifter,
            IShifter<IPriority> higherPriorityShifter
            )
        {
            QuestReader = questReader;
            QuestWriter = questWriter;
            QuestSelector = questSelector;
            LowerPriorityShifter = lowerPriorityShifter;
            HigherPriorityShifter = higherPriorityShifter;
        }



        public void Run(OrderQuestOptions options)
        {
            var quests = QuestReader.Read();
            var quest = QuestSelector.Select(quests, new Identifier(options.Id));
            if (quest.Priority == options.Priority)
                return;

            var targetPriority = new BasicPriority(options.Priority);
            var questPriority = new BasicPriority(quest.Priority);
            
            if (quest.Priority > options.Priority)
                LowerPriorityShifter.Shift(quests, targetPriority, questPriority);
            else
                HigherPriorityShifter.Shift(quests, questPriority, targetPriority);

            quest.Priority = options.Priority;
            QuestWriter.Set(quests);
        }
    }
}