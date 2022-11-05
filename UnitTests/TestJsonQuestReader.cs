using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using Quester.Models;
using Quester.QuestReaders;
using Quester.QuestSerialisers;
using Xunit;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestJsonQuestReader
    {
        [Fact]
        public void JsonQuestReaderCreate()
        {
            var mockSerialiser = Mock<IQuestSerialiser>();
            var mockTextReader = Mock<TextReader>();
            var reader = new JsonQuestReader(mockSerialiser, mockTextReader);
            Assert.Equal(mockSerialiser, reader.Serialiser);
            Assert.Equal(mockTextReader, reader.TextReader);
        }

        [Fact]
        public void JsonQuestReaderRead()
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

        [Theory]
        [MemberData(nameof(JsonQuestReaderNullConstructorData))]
        public void JsonQuestReaderNullThrowsException(IQuestSerialiser serialiser, TextReader reader, string paramName)
        {
            Assert.Throws<ArgumentNullException>(paramName, () => new JsonQuestReader(serialiser, reader));
        }

        public static IEnumerable<object[]> JsonQuestReaderNullConstructorData()
        {
            yield return new object[] { null, null, nameof(JsonQuestReader.Serialiser) };
            yield return new object[] { Mock<IQuestSerialiser>(), null, nameof(JsonQuestReader.TextReader) };
        }
    }
}