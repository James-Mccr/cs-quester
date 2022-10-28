using System;

namespace Quester.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public int Reward { get; set; }
        public string Goal { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateCompleted { get; set; }

        public Quest(int id, int reward, string goal, DateTime? dateCreated, DateTime? dateCompleted)
        {
            Id = id;
            Reward = reward;
            Goal = goal;
            DateCreated = dateCreated;
            DateCompleted = dateCompleted;
        }

        public bool IsComplete() => DateCompleted != null;
    }
}