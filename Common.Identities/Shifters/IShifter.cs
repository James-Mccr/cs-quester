using System.Collections.Generic;

namespace Common.Identities.Shifters
{
    public interface IShifter<T>
    {
        void Shift(IEnumerable<T> items, T lower, T upper);
    }
}
