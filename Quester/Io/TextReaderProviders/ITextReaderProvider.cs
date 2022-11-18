using System.IO;

namespace Quester.Io.TextReaderProviders
{
    public interface ITextReaderProvider
    {
        TextReader Provide();
    }
}