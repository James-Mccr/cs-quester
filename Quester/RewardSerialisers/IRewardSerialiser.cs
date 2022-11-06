using System.Collections.Generic;
using Quester.Models;

namespace Quester.RewardSerialisers
{
    public interface IRewardSerialiser
    {
        string Serialise(IEnumerable<Reward> rewards);
        IEnumerable<Reward> Deserialise(string s);
    }
}