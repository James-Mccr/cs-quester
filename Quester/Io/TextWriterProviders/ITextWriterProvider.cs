using System.IO;

namespace Quester.Io.TextWriterProviders
{
    public interface ITextWriterProvider
    {
        TextWriter Provide();
    }
}