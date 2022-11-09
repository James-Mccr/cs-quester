using System.IO;

namespace Quester.TextReaderProviders
{
    public interface ITextReaderProvider
    {
        TextReader Provide();
    }
}