using LionLibrary.SQL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Golmodoth.Shared
{
    [Table("characters")]
    public class Character : IEntity<Character, uint>, ICharacter
    {
        [Key]
        public uint Id { get; set; }

        public uint UserId { get; set; }
        public User User { get; set; }

        [Column(TypeName = "nvarchar(32")]
        public string Name { get; set; }

        public BigInteger TotalXp { get; set; }

        public ulong Silver { get; set; }
        public ulong Gold { get; set; }
    }
}
