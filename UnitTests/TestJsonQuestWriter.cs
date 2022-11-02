using Moq;
using Xunit;
using Quester.Models;
using Quester.QuestWriters;
using Quester.QuestSerialisers;
using System.Collections.Generic;
using System.IO;
using System;

namespace Quester.UnitTests
{
    public class TestJsonQuestWriter
    {
        [Fact]
        public void JsonQuestWriterCreate()
        {
            var mockQuestSerialiser = new Mock<IQuestSerialiser>();
            var mockTextWriter = new Mock<TextWriter>();
            var writer = new JsonQuestWriter(mockQuestSerialiser.Object, mockTextWriter.Object);
            Assert.Equal(mockQuestSerialiser.Object, writer.Serialiser);
            Assert.Equal(mockTextWriter.Object, writer.TextWriter);
        }

        [Fact]
        public void JsonQuestWriterWrite()
        {
            var mockQuestSerialiser = new Mock<IQuestSerialiser>();
            mockQuestSerialiser.Setup(m => m.Serialise(It.IsAny<IEnumerable<Quest>>())).Returns(It.IsAny<string>());
            var mockTextWriter = new Mock<TextWriter>();

            var writer = new JsonQuestWriter(mockQuestSerialiser.Object, mockTextWriter.Object);
            writer.Write(It.IsAny<IEnumerable<Quest>>());

            mockQuestSerialiser.Verify(m => m.Serialise(It.IsAny<IEnumerable<Quest>>()), Times.Once);
            mockTextWriter.Verify(m => m.Write(It.IsAny<string>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(JsonQuestWriterNullConstructorData))]
        public void JsonQuestWriterNullThrowsException(IQuestSerialiser serialiser, TextWriter writer, string paramName)
        {
            Assert.Throws<ArgumentNullException>(paramName, () => new JsonQuestWriter(serialiser, writer));
        }

        public static IEnumerable<object[]> JsonQuestWriterNullConstructorData()
        {
            yield return new object[] { null, new Mock<TextWriter>().Object, nameof(JsonQuestWriter.Serialiser) };
            yield return new object[] { new Mock<IQuestSerialiser>().Object, null, nameof(JsonQuestWriter.TextWriter) };
        }
}
}