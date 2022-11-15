namespace Quester.Models
{
    public class Reward
    {
        public string Prize { get; set; }
        public int Cost { get; set; }

        public Reward(string prize, int cost)
        {
            Prize = prize;
            Cost = cost;
        }
    }
}