using System.Collections.Generic;

namespace Quester.Collections.Sequencers
{
    public interface ISequencer<T>
    {
        T Next(IEnumerable<T> items);
    }
}