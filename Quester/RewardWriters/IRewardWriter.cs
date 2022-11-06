using System.Collections.Generic;
using Quester.Models;

namespace Quester.RewardWriters
{
    public interface IRewardWriter
    {
        void Write(IEnumerable<Reward> rewards);
    }
}