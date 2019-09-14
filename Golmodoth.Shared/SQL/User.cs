using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using LionLibrary.SQL;
using Microsoft.EntityFrameworkCore;

namespace Golmodoth.Shared
{
    [Table("users")]
    public class User : IEntity<User, uint>
    {
        [Key]
        public uint Id { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Username { get; set; }

        ///<summary>Don't forget to regex check the email format</summary>
        [Column(TypeName = "nvarchar(64)")]
        public string Email { get; set; }

        //Securely store passwords
        //Not even I can figure them out
        public byte[] Password_Hash { get; set; }
        public byte[] Passsword_Salt { get; set; }

        [JsonIgnore, IgnoreDataMember]
        public ICollection<Character> Characters { get; set; }

        public static void CreateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(x =>
            {
                x.HasMany(user => user.Characters)
                .WithOne(character => character.User)
                .HasForeignKey(character => character.UserId);
            });
        }
    }
}
