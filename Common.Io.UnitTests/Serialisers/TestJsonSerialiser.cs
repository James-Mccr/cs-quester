using Moq;
using Newtonsoft.Json;
using Common.Io.Converters;
using Common.Io.Serialisers;
using Xunit;
using static Common.Tests.MockHelpers;

namespace Common.Io.UnitTests.Serialisers
{
    public class TestJsonSerialiser
    {
        [Fact]
        public void JsonSerialiserConstruct()
        {
            var settings = new JsonSerializerSettings();
            var mockDefaultValueConverter = Mock<IConverter<It.IsAnyType>>();
            var serialiser = new JsonSerialiser<It.IsAnyType>(settings, mockDefaultValueConverter);
            Assert.Equal(settings, serialiser.Settings);
            Assert.Equal(mockDefaultValueConverter, serialiser.DefaultValueConverter);
        }

        [Fact]
        public void JsonSerialiserDeserialise()
        {
            var settings = new JsonSerializerSettings();
            var mockDefaultValueConverter = new Mock<IConverter<It.IsAnyType>>();
            var serialiser = new JsonSerialiser<It.IsAnyType>(settings, mockDefaultValueConverter.Object);

            serialiser.Deserialise(string.Empty);

            mockDefaultValueConverter.Verify(m => m.Convert(Any()), Times.Once);
        }
    }
}