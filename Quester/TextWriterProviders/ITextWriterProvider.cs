using System.IO;

namespace Quester.TextWriterProviders
{
    public interface ITextWriterProvider
    {
        TextWriter Provide();
    }
}