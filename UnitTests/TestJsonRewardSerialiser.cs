using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Quester.Models;
using Quester.RewardSerialisers;
using Xunit;

namespace Quester.UnitTests
{
    public class TestJsonRewardSerialiser
    {
        [Fact]
        public void JsonRewardSerialiserConstruct()
        {
            var settings = new JsonSerializerSettings();
            var serialiser = new JsonRewardSerialiser(settings);
            Assert.Equal(settings, serialiser.Settings);
        }

        [Theory]
        [MemberData(nameof(JsonRewardSerialiserData))]
        public void JsonRewardSerialiserSerialise(IEnumerable<Reward> rewards, string expectedJson)
        {
            var settings = new JsonSerializerSettings();
            var serialiser = new JsonRewardSerialiser(settings);
            var json = serialiser.Serialise(rewards);
            Assert.Equal(expectedJson, json);
        }

        [Theory]
        [MemberData(nameof(JsonRewardSerialiserData))]
        public void JsonRewardSerialiserDeserialise(IEnumerable<Reward> expectedRewards, string json)
        {
            var settings = new JsonSerializerSettings();
            var serialiser = new JsonRewardSerialiser(settings);
            var rewards = serialiser.Deserialise(json);
            Assert.Equal(expectedRewards, rewards, new RewardEqualityComparer());
        }

        public static IEnumerable<object[]> JsonRewardSerialiserData()
        {
            yield return new object[] { new Reward[0], "[]" };
            yield return new object[] 
            {
                 new Reward[] { new Reward(0, null, 0) },
                 @"[{""Id"":0,""Prize"":null,""Cost"":0}]" 
            };
            yield return new object[]
            {
                new Reward[]
                {
                    new Reward(0, null, 0),
                    new Reward(1, "prize", 1)
                },
                "["
                + @"{""Id"":0,""Prize"":null,""Cost"":0}," 
                + @"{""Id"":1,""Prize"":""prize"",""Cost"":1}]" 
            };
        }

        private class RewardEqualityComparer : IEqualityComparer<Reward>
        {
            public bool Equals(Reward x, Reward y)
            {
                if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                    return false;
                if (ReferenceEquals(x, y))
                    return true;
                return x.Id == y.Id
                    && x.Prize == y.Prize
                    && x.Cost == y.Cost;
            }

            public int GetHashCode([DisallowNull] Reward obj)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}