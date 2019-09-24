using Golmodoth.Shared;
using System.Numerics;

namespace Golmodoth.Client
{
    public class SocketCharacter : ICharacter
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        
        public string TotalXp { get; set; }

        public LevelProgress LevelProgress => LevelProgressCalculator.CharacterLevelProgressConverter(TotalXp);

        public ulong Silver { get; set; }
        public ulong Gold { get; set; }

        public SocketCharacter()
        {

        }
    }
}
