using System.Collections.Generic;

namespace Common.Identities.Sequencers
{
    public interface ISequencer<T>
    {
        T Next(IEnumerable<T> items);
    }
}