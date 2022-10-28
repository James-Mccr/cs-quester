using System;
using System.Collections.Generic;
using System.IO;
using Quester.QuestSerialisers;
using Quester.Models;

namespace Quester.QuestWriters
{
    public class JsonQuestWriter : IQuestWriter
    {
        public IQuestSerialiser Serialiser { get; }
        public TextWriter TextWriter { get; }

        public JsonQuestWriter(IQuestSerialiser serialiser, TextWriter writer)
        {
            Serialiser = serialiser ?? throw new ArgumentNullException(nameof(serialiser));
            TextWriter = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        public void Write(IEnumerable<Quest> quests)
        {
            var json = Serialiser.Serialise(quests);    // assumes input is small (10s to 1000s quests)
            TextWriter.Write(json);
        }
    }
}