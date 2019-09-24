using LionLibrary.SQL;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Runtime.Serialization;

namespace Golmodoth.Shared
{
    [Table("characters")]
    public class Character : IEntity<Character, int>, ICharacter
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [JsonIgnore, IgnoreDataMember]
        public User User { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }

        public string TotalXp { get; set; }

        public ulong Silver { get; set; }
        public ulong Gold { get; set; }

        public static void CreateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>(x =>
            {
                x.HasIndex(character => character.Name).IsUnique();
            });
        }
    }
}
