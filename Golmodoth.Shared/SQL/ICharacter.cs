using System.Numerics;

namespace Golmodoth.Shared
{
    public interface ICharacter
    {
        uint Id { get; set; }
        uint UserId { get; set; }
        string Name { get; set; }
        BigInteger TotalXp { get; set; }
        ulong Silver { get; set; }
        ulong Gold { get; set; }
    }
}