using System.IO;
using Common.Io.StreamProviders;
using Xunit;
using static Common.Tests.MockHelpers;

namespace Common.Io.UnitTests.StreamProviders
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