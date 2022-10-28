using System.Collections.Generic;
using Newtonsoft.Json;
using Xunit;
using Quester.QuestSerialisers;
using Quester.Models;
using System;

namespace Quester.UnitTests
{
    public class TestJsonQuestSerialiser
    {
        [Theory]
        [InlineData(Formatting.None)]
        [InlineData(Formatting.Indented)]
        public void CreateJsonQuestSerialiser(Formatting format)
        {
            var serialiser = new JsonQuestSerialiser(format);
            Assert.Equal(format, serialiser.Format);
        }

        [Theory]
        [MemberData(nameof(SerialiseQuestData))]
        public void SerialiseJsonQuestSerialiser(IEnumerable<Quest> quests, string expectedJson)
        {
            var serialiser = new JsonQuestSerialiser();
            var actualJson = serialiser.Serialise(quests);
            Assert.Equal(expectedJson, actualJson);
        }

        public static IEnumerable<object[]> SerialiseQuestData()
        {
            yield return new object[] { new Quest[0], "[]" };
            yield return new object[] 
            { 
                new Quest[] { new Quest(0, 0, string.Empty, null, null) }, 
                @"[{""Id"":0,""Reward"":0,""Goal"":"""",""DateCreated"":null,""DateCompleted"":null}]" 
            };
            yield return new object[]
            {
                new Quest[]
                {
                    new Quest(0, 0, string.Empty, null, null),
                    new Quest(1, 1, "goal", DateTime.MinValue, DateTime.MinValue)
                },
                @"[{""Id"":0,""Reward"":0,""Goal"":"""",""DateCreated"":null,""DateCompleted"":null},{""Id"":1,""Reward"":1,""Goal"":""goal"",""DateCreated"":""0001-01-01T00:00:00"",""DateCompleted"":""0001-01-01T00:00:00""}]"
            };
        }
    }
}