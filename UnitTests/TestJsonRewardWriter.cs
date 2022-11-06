using System.Collections.Generic;
using System.IO;
using Moq;
using Quester.Models;
using Quester.RewardSerialisers;
using Quester.RewardWriters;
using Xunit;
using static Quester.UnitTests.MockHelpers;

namespace Quester.UnitTests
{
    public class TestJsonRewardWriter
    {
        [Fact]
        public void JsonRewardWriterConstruct()
        {
            var mockSerialiser = Mock<IRewardSerialiser>();
            var mockTextWriter = Mock<TextWriter>();
            var writer = new JsonRewardWriter(mockSerialiser, mockTextWriter);
            Assert.Equal(mockSerialiser, writer.RewardSerialiser);
            Assert.Equal(mockTextWriter, writer.TextWriter);
        }

        [Fact]
        public void JsonRewardWriterWrite()
        {
            var mockSerialiser = new Mock<IRewardSerialiser>();
            var mockTextWriter = new Mock<TextWriter>();
            
            var writer = new JsonRewardWriter(mockSerialiser.Object, mockTextWriter.Object);
            writer.Write(It.IsAny<IEnumerable<Reward>>());

            mockSerialiser.Verify(m => m.Serialise(It.IsAny<IEnumerable<Reward>>()), Times.Once);
            mockTextWriter.Verify(m => m.Write(It.IsAny<string>()), Times.Once);
        }
    }
}