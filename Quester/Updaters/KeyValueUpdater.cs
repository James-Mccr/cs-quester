using System.Collections.Generic;
using Quester.Readers;
using Quester.Writers;

namespace Quester.Updaters
{
    public class KeyValueUpdater<T1, T2> : IUpdater<T1, T2>
    {
        public IReader<IDictionary<T1, T2>> Reader { get; }
        public IWriter<IDictionary<T1, T2>> Writer { get; }
        
        public KeyValueUpdater(IReader<IDictionary<T1, T2>> reader, IWriter<IDictionary<T1, T2>> writer)
        {
            Reader = reader;
            Writer = writer;
        }

        public bool Update(T1 key, T2 value)
        {
            var items = Reader.Read();
            if (!items.ContainsKey(key))
                    return false;
            items[key] = value;
            Writer.Write(items);
            return true;
        }
    }
}