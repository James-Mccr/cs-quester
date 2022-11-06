using System.Collections.Generic;

namespace Quester.Models
{
    public class Journal 
    {
        public ISet<Quest> Quests { get; set; }
        public ISet<Reward> Rewards { get; set; }
        public Level Level { get; set; }

        public Journal(ISet<Quest> quests, ISet<Reward> rewards, Level level)
        {
            Quests = quests;
            Rewards = rewards;
            Level = level;
        }
    }
}