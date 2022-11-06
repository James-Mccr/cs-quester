using System.IO;
using Quester.LevelSerialisers;
using Quester.Models;

namespace Quester.LevelWriters
{
    public class JsonLevelWriter : ILevelWriter
    {
        public ILevelSerialiser LevelSerialiser { get; }
        public TextWriter TextWriter { get; }

        public JsonLevelWriter(ILevelSerialiser levelSerialiser, TextWriter textWriter)
        {
            LevelSerialiser = levelSerialiser;
            TextWriter = textWriter;
        }

        public void Write(Level level)
        {
            var json = LevelSerialiser.Serialise(level);
            TextWriter.Write(json);
        }
    }
}