using Quester.Models;

namespace Quester.JournalWriters
{
    public interface IJournalWriter
    {
        void Write(Journal journal);
    }
}