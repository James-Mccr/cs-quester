using System.IO;

namespace Quester.StreamProviders
{
    public interface IStreamProvider
    {
        Stream Provide();
    }
}