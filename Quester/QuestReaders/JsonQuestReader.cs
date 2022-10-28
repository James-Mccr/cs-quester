using System.Collections.Generic;
using System.IO;
using Quester.Models;
using Quester.QuestSerialisers;

namespace Quester.QuestReaders
{
    public class JsonQuestReader : IQuestReader
    {
        public IQuestSerialiser Serialiser { get; }
        public TextReader TextReader { get; }

        public JsonQuestReader(IQuestSerialiser serialiser, TextReader textReader)
        {
            Serialiser = serialiser;
            TextReader = textReader;
        }

        public IEnumerable<Quest> Read()
        {
            var s = TextReader.ReadToEnd(); // assumes input is small
            return Serialiser.Deserialise(s);
        }
    }
}