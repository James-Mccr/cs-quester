using System.Collections.Generic;
using Quester.Readers;
using Quester.Sequencers;
using Quester.Writers;

namespace Quester.Creators
{
    public class KeyValueCreator<T1, T2> : ICreator<T2, KeyValuePair<T1, T2>>
    {
        public IReader<IDictionary<T1, T2>> Reader { get; }
        public IWriter<IDictionary<T1, T2>> Writer { get; }
        public ISequencer<T1> Sequencer { get; }

        public KeyValueCreator(
            IReader<IDictionary<T1, T2>> reader,
            IWriter<IDictionary<T1, T2>> writer,
            ISequencer<T1> sequencer
        )
        {
            Reader = reader;
            Writer = writer;
            Sequencer = sequencer;
        }

        public KeyValuePair<T1, T2> Create(T2 item)
        {
            var items = Reader.Read();
            var nextKey = Sequencer.Next(items.Keys);
            items.Add(nextKey, item);
            Writer.Write(items);
            return new KeyValuePair<T1, T2>(nextKey, item);
        }
    }
}