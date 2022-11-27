namespace Common.Journals
{
    /// <summary>
    /// Tracks metadata of a user
    /// </summary>
    public class Journal 
    {
        public int Merits { get; set; }

        public Journal() {}

        public Journal(int merits)
        {
            Merits = merits;
        }
    }
}