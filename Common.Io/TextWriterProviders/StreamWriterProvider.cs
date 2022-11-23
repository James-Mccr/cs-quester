using System.IO;
using Common.Io.StreamProviders;

namespace Common.Io.TextWriterProviders
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