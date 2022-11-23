using System.IO;

namespace Common.Io.TextReaderProviders
{
    public interface ITextReaderProvider
    {
        TextReader Provide();
    }
}