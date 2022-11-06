using System.Collections.Generic;
using Quester.Models;

namespace Quester.RewardReaders
{
    public interface IRewardReader
    {
        IEnumerable<Reward> Read();
    }
}