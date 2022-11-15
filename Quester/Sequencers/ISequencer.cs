using System.Collections.Generic;

namespace Quester.Sequencers
{
    public interface ISequencer<T>
    {
        T Next(IEnumerable<T> items);
    }
}