using Quester.Io.TextReaderProviders;

namespace Quester.Io.Inputs
{
    public class StringInput : IInput<string>
    {
        public ITextReaderProvider TextReaderProvider { get; }

        public StringInput(ITextReaderProvider textReaderProvider)
        {
            TextReaderProvider = textReaderProvider;
        }

        public string Get()
        {
            using (var reader = TextReaderProvider.Provide())
            {
                return reader.ReadToEnd();
            }
        }
    }
}