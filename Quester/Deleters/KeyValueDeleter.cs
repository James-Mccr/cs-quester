using System.Collections.Generic;
using Quester.Readers;
using Quester.Writers;

namespace Quester.Deleters
{
    public class KeyValueDeleter<T1, T2> : IDeleter<T1>
    {
        public IReader<IDictionary<T1, T2>> Reader { get; }
        public IWriter<IDictionary<T1, T2>> Writer { get; }

        public KeyValueDeleter(IReader<IDictionary<T1, T2>> reader, IWriter<IDictionary<T1, T2>> writer)
        {
            Reader = reader;
            Writer = writer;
        }

        public bool Delete(T1 item)
        {
            var items = Reader.Read();
            var removed = items.Remove(item);
            if (removed)
                Writer.Write(items);
            return removed;
        }
    }
}