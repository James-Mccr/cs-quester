using Quester.Models;

namespace Quester.LevelSerialisers
{
    public interface ILevelSerialiser
    {
        string Serialise(Level level);
        Level Deserialise(string s);
    }
}