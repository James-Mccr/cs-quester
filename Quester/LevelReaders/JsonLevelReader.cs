using System.IO;
using Quester.LevelSerialisers;
using Quester.Models;

namespace Quester.LevelReaders
{
    public class JsonLevelReader : ILevelReader
    {
        public ILevelSerialiser LevelSerialiser { get; }
        public TextReader TextReader { get; }

        public JsonLevelReader(ILevelSerialiser levelSerialiser, TextReader textReader)
        {
            LevelSerialiser = levelSerialiser;
            TextReader = textReader;
        }

        public Level Read()
        {
            var json = TextReader.ReadToEnd();
            return LevelSerialiser.Deserialise(json);
        }
    }
}