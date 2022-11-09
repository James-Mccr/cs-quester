using System.IO;
using Quester.StreamProviders;

namespace Quester.TextReaderProviders
{
    public class StreamReaderProvider : ITextReaderProvider
    {
        public IStreamProvider StreamProvider { get; }

        public StreamReaderProvider(IStreamProvider streamProvider) // todo could use a custom 'StreamReaderSettings' class
        {
            StreamProvider = streamProvider;
        }

        public TextReader Provide() 
        {
            var stream = StreamProvider.Provide();
            return new StreamReader(stream);
        } 
    }
}