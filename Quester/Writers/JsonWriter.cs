using System;
using Quester.Serialiser;

namespace Quester.Writers
{
    public class JsonWriter<T> : IWriter<T>
    {
        public IWriter<string> StringWriter { get; }
        public ISerialiser<T> Serialiser { get; }

        public JsonWriter(IWriter<string> stringWriter, ISerialiser<T> serialiser)
        {
            StringWriter = stringWriter ?? throw new ArgumentNullException(nameof(StringWriter));
            Serialiser = serialiser ?? throw new ArgumentNullException(nameof(Serialiser));
        }

        public void Write(T value)
        {
            var json = Serialiser.Serialise(value);    // assumes input is small (10s to 1000s quests)
            StringWriter.Write(json);  
        }
    }
}