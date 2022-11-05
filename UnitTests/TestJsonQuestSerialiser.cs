using System.Collections.Generic;
using Newtonsoft.Json;
using Xunit;
using Quester.QuestSerialisers;
using Quester.Models;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Quester.UnitTests
{
    public class TestJsonQuestSerialiser
    {
        [Theory]
        [MemberData(nameof(JsonQuestSerialiserCreateData))]
        public void JsonQuestSerialiserCreate(JsonSerializerSettings settings)
        {
            
            var serialiser = new JsonQuestSerialiser(settings);
            Assert.Equal(settings, serialiser.Settings);
        }

        public static IEnumerable<object[]> JsonQuestSerialiserCreateData()
        {
            yield return new object[] { null };
            yield return new object[] { new JsonSerializerSettings() };
            yield return new object[] { new JsonSerializerSettings { Formatting = Formatting.Indented } };
        }

        [Theory]
        [MemberData(nameof(JsonQuestSerialiserTestData))]
        public void JsonQuestSerialiserSerialise(IEnumerable<Quest> quests, string expectedJson)
        {
            var settings = new JsonSerializerSettings();
            var serialiser = new JsonQuestSerialiser(settings);
            var actualJson = serialiser.Serialise(quests);
            Assert.Equal(expectedJson, actualJson);
        }

        [Theory]
        [MemberData(nameof(JsonQuestSerialiserTestData))]
        public void JsonQuestSerialiserDeserialise(IEnumerable<Quest> expectedQuests, string json)
        {
            var settings = new JsonSerializerSettings();
            var serialiser = new JsonQuestSerialiser(settings);
            var actualQuests = serialiser.Deserialise(json);
            Assert.Equal(expectedQuests, actualQuests, new QuestEqualityComparer());
        }

        public static IEnumerable<object[]> JsonQuestSerialiserTestData()
        {
            yield return new object[] { new Quest[0], "[]" };
            yield return new object[] 
            { 
                new Quest[] { new Quest(0, 0, string.Empty, false) }, 
                @"[{""Id"":0,""Reward"":0,""Goal"":"""",""Complete"":false}]" 
            };
            yield return new object[]
            {
                new Quest[]
                {
                    new Quest(0, 0, string.Empty, false),
                    new Quest(1, 1, "goal", true)
                },
                "["
                + @"{""Id"":0,""Reward"":0,""Goal"":"""",""Complete"":false},"
                + @"{""Id"":1,""Reward"":1,""Goal"":""goal"",""Complete"":true}]"
            };
        }

        private class QuestEqualityComparer : IEqualityComparer<Quest>
        {
            public bool Equals(Quest x, Quest y)
            {
                if (x == null || y == null)
                    return false;
                if (ReferenceEquals(x, y))
                    return true;
                return x.Id == y.Id
                    && x.Reward == y.Reward
                    && x.Goal == y.Goal
                    && x.Complete == y.Complete;
            }

            public int GetHashCode([DisallowNull] Quest obj)
            {
                throw new NotImplementedException();
            }
        }
    }
}