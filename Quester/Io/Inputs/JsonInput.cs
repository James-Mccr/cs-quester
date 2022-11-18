using System;
using Quester.Io.Serialisers;

namespace Quester.Io.Inputs
{
    public class JsonInput<T> : IInput<T>
    {
        public IInput<string> StringInput { get; }
        public ISerialiser<T> Serialiser { get; }

        public JsonInput(IInput<string> stringInput, ISerialiser<T> serialiser)
        {
            StringInput = stringInput;
            Serialiser = serialiser ?? throw new ArgumentNullException(nameof(Serialiser));
        }

        public T Get()
        {
            string json = StringInput.Get();
            return Serialiser.Deserialise(json);
        }
    }
}