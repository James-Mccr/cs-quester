using Moq;
using Newtonsoft.Json;
using Quester.Collections.Converters;
using Quester.Io.Serialisers;
using Xunit;

namespace Quester.UnitTests
{
    public class TestJsonSerialiser
    {
        [Fact]
        public void JsonSerialiserConstruct()
        {
            var settings = new JsonSerializerSettings();
            var mockDefaultValueConverter = new Mock<IConverter<It.IsAnyType>>();
            var serialiser = new JsonSerialiser<It.IsAnyType>(settings, mockDefaultValueConverter.Object);
            Assert.Equal(settings, serialiser.Settings);
        }
    }
}