namespace Quester.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public int Reward { get; set; }
        public string Goal { get; set; }
        public bool Complete { get; set; }

        public Quest(int id, int reward, string goal, bool complete)
        {
            Id = id;
            Reward = reward;
            Goal = goal;
            Complete = complete;
        }
    }
}