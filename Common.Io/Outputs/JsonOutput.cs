using System;
using Common.Io.Serialisers;

namespace Common.Io.Outputs
{
    public class JsonOutput<T> : IOutput<T>
    {
        public IOutput<string> StringOutput { get; }
        public ISerialiser<T> Serialiser { get; }

        public JsonOutput(IOutput<string> stringOutput, ISerialiser<T> serialiser)
        {
            StringOutput = stringOutput ?? throw new ArgumentNullException(nameof(StringOutput));
            Serialiser = serialiser ?? throw new ArgumentNullException(nameof(Serialiser));
        }

        public void Set(T value)
        {
            var json = Serialiser.Serialise(value);    // assumes input is small (10s to 1000s quests)
            StringOutput.Set(json);
        }
    }
}