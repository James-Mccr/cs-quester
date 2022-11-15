namespace Quester.Models
{
    public class Quest
    {
        public int Reward { get; set; }
        public string Goal { get; set; }
        public bool Complete { get; set; }

        public Quest(int reward, string goal, bool complete)
        {
            Reward = reward;
            Goal = goal;
            Complete = complete;
        }
    }
}