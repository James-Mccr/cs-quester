using System.IO;

namespace Common.Io.TextWriterProviders
{
    public interface ITextWriterProvider
    {
        TextWriter Provide();
    }
}