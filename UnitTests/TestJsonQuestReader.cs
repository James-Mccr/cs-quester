using System.Collections.Generic;
using System.IO;
using Moq;
using Quester.Models;
using Quester.QuestReaders;
using Quester.QuestSerialisers;
using Xunit;

namespace Quester.UnitTests
{
    public class TestJsonQuestReader
    {
        [Fact]
        public void CreateJsonQuestReader()
        {
            var mockSerialiser = new Mock<IQuestSerialiser>();
            var mockTextReader = new Mock<TextReader>();
            var reader = new JsonQuestReader(mockSerialiser.Object, mockTextReader.Object);
            Assert.Equal(mockSerialiser.Object, reader.Serialiser);
            Assert.Equal(mockTextReader.Object, reader.TextReader);
        }

        [Fact]
        public void ReadJsonQuestReader()
        {
            var mockSerialiser = new Mock<IQuestSerialiser>();
            mockSerialiser.Setup(m => m.Deserialise(It.IsAny<string>())).Returns(It.IsAny<IEnumerable<Quest>>());
            var mockTextReader = new Mock<TextReader>();
            mockTextReader.Setup(m => m.ReadToEnd()).Returns(It.IsAny<string>());
            
            var reader = new JsonQuestReader(mockSerialiser.Object, mockTextReader.Object);
            reader.Read();

            mockSerialiser.Verify(m => m.Deserialise(It.IsAny<string>()), Times.Once);
            mockTextReader.Verify(m => m.ReadToEnd(), Times.Once);
        }
    }
}