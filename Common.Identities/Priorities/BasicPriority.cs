namespace Common.Identities.Priorities
{
    public class BasicPriority : IPriority
    {
        public int Priority { get; set; }

        public BasicPriority(int priority)
        {
            Priority = priority;
        }
    }
}