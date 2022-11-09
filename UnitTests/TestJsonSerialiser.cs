using Moq;
using Newtonsoft.Json;
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
            var serialiser = new JsonSerialiser<It.IsAnyType>(settings);
            Assert.Equal(settings, serialiser.Settings);
        }
    }
}