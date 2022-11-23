using System.IO;

namespace Common.Io.StreamProviders
{
    public interface IStreamProvider
    {
        Stream Provide();
    }
}