using Moq;
using Newtonsoft.Json;
using Quester.DefaultValueConverters;
using Quester.Serialisers;
using Xunit;

namespace Quester.UnitTests
{
    public class TestJsonSerialiser
    {
        [Fact]
        public void JsonSerialiserConstruct()
        {
            var settings = new JsonSerializerSettings();
            var mockDefaultValueConverter = new Mock<IDefaultValueConverter<It.IsAnyType>>();
            var serialiser = new JsonSerialiser<It.IsAnyType>(settings, mockDefaultValueConverter.Object);
            Assert.Equal(settings, serialiser.Settings);
        }
    }
}