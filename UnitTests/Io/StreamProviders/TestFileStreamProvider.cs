using System.IO;
using Quester.Io.StreamProviders;
using Xunit;
using static UnitTests.MockHelpers;

namespace UnitTests.Io.StreamProviders
{
    public class TestFileStreamProvider
    {
        [Fact]
        public void FileStreamProviderConstruct()
        {
            var file = "test";
            var fileStreamOptions = new FileStreamOptions();
            var streamProvider = new FileStreamProvider(file, fileStreamOptions);
            Assert.Equal(file, streamProvider.FilePath);
            Assert.Equal(fileStreamOptions, streamProvider.FileStreamOptions);
        }
    }
}