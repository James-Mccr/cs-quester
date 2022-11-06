using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Quester.LevelSerialisers;
using Quester.Models;
using Xunit;

namespace Quester.UnitTests
{
    public class TestJsonLevelSerialiser
    {
        [Fact]
        public void JsonLevelSerialiserConstruct()
        {
            var settings = new JsonSerializerSettings();
            var serialiser = new JsonLevelSerialiser(settings);
            Assert.Equal(settings, serialiser.Setings);
        }

        [Theory]
        [MemberData(nameof(JsonLevelSerialiserData))]
        public void JsonLevelSerialiserSerialise(Level level, string expectedJson)
        {
            var settings = new JsonSerializerSettings();
            var serialiser = new JsonLevelSerialiser(settings);
            var json = serialiser.Serialise(level);
            Assert.Equal(expectedJson, json);
        }

        [Theory]
        [MemberData(nameof(JsonLevelSerialiserData))]
        public void JsonLevelSerialiserDeserialise(Level expectedLevel, string json)
        {
            var settings = new JsonSerializerSettings();
            var serialiser = new JsonLevelSerialiser(settings);
            var level = serialiser.Deserialise(json);
            Assert.Equal(expectedLevel, level, new LevelTestEqualityComparer());
        }

        public static IEnumerable<object[]> JsonLevelSerialiserData()
        {
            yield return new object[] { new Level(0), @"{""Experience"":0}" };
        }

        public class LevelTestEqualityComparer : IEqualityComparer<Level>
        {
            public bool Equals(Level x, Level y)
            {
                if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                    return false;
                if (ReferenceEquals(x, y))
                    return true;
                return x.Experience == y.Experience;
            }

            public int GetHashCode([DisallowNull] Level obj)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}