using System.IO;

namespace Quester.Io.StreamProviders
{
    public class FileStreamProvider : IStreamProvider
    {
        public string FilePath { get; }
        public FileStreamOptions FileStreamOptions { get; }

        public FileStreamProvider(string filePath, FileStreamOptions fileStreamOptions)
        {
            FilePath = filePath;
            FileStreamOptions = fileStreamOptions;
        }

        public Stream Provide() => File.Open(FilePath, FileStreamOptions);
    }
}