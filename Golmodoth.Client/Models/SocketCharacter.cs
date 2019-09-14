using Golmodoth.Shared;
using System.Numerics;

namespace Golmodoth.Client
{
    public class SocketCharacter : ICharacter
    {
        public uint Id { get; set; }
        public uint UserId { get; set; }
        public string Name { get; set; }
        
        public BigInteger TotalXp { get; set; }

        public LevelProgress LevelProgress => LevelProgressCalculator.CharacterLevelProgressConverter(TotalXp);

        public ulong Silver { get; set; }
        public ulong Gold { get; set; }

        public SocketCharacter()
        {

        }
    }
}
