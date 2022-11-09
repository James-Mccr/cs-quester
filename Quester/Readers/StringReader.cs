using Quester.TextReaderProviders;

namespace Quester.Readers
{
    public class StringReader : IReader<string>
    {
        public ITextReaderProvider TextReaderProvider { get; }

        public StringReader(ITextReaderProvider textReaderProvider)
        {
            TextReaderProvider = textReaderProvider;
        }

        public string Read()
        {
            using (var reader = TextReaderProvider.Provide())
            {
                return reader.ReadToEnd();
            }
        }
    }
}