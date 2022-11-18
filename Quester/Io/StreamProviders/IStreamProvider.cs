using System.IO;

namespace Quester.Io.StreamProviders
{
    public interface IStreamProvider
    {
        Stream Provide();
    }
}