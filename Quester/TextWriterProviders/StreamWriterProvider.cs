using System.IO;
using Quester.StreamProviders;

namespace Quester.TextWriterProviders
{
    public class StreamWriterProvider : ITextWriterProvider
    {
        public IStreamProvider StreamProvider { get; }

        public StreamWriterProvider(IStreamProvider streamProvider) // todo could use a custom 'StreamWriterSettings' class
        {
            StreamProvider = streamProvider;
        }

        public TextWriter Provide()
        {
            var stream = StreamProvider.Provide();
            return new StreamWriter(stream);
        }
    }
}