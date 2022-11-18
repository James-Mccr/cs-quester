using System.IO;
using Quester.Io.StreamProviders;

namespace Quester.Io.TextWriterProviders
{
    public class StreamWriterProvider : ITextWriterProvider
    {
        public IStreamProvider StreamProvider { get; }

        public StreamWriterProvider(IStreamProvider streamProvider)
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