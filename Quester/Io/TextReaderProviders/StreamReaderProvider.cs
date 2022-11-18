using System.IO;
using Quester.Io.StreamProviders;

namespace Quester.Io.TextReaderProviders
{
    public class StreamReaderProvider : ITextReaderProvider
    {
        public IStreamProvider StreamProvider { get; }

        public StreamReaderProvider(IStreamProvider streamProvider)
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