namespace Common.Identities.Identifiers
{
    public class Identifier : IIdentifier
    {
        public int Id { get; set; }

        public Identifier(int id)
        {
            Id = id;
        }
    }
}