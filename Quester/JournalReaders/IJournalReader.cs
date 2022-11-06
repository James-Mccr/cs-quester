using Quester.Models;

namespace Quester.JournalReaders
{
    public interface IJournalReader
    {
        Journal Read();
    }
}