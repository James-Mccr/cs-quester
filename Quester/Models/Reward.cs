namespace Quester.Models
{
    public class Reward
    {
        public int Id { get; set; }
        public string Prize { get; set; }
        public int Cost { get; set; }

        public Reward(int id, string prize, int cost)
        {
            Id = id;
            Prize = prize;
            Cost = cost;
        }
    }
}