using System;
using Quester.JournalWriters;
using Quester.Models;

namespace Quester
{
    public class Quester
    {
        public Journal Journal { get; }
        public IJournalWriter JournalWriter { get; }

        public Quester(Journal journal, IJournalWriter journalWriter)
        {
            Journal = journal ?? throw new ArgumentNullException(nameof(Journal));
            JournalWriter = journalWriter ?? throw new ArgumentNullException(nameof(JournalWriter));
        }
    }
}