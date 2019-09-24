using Golmodoth.Shared;
using LionLibrary.SQL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Golmodoth.Shared
{
    public class ApiKey : IEntity<ApiKey, int>
    {
        [Key]
        public int Id { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
        
        [Column(TypeName = "char(32)"), Required]
        public string Key { get; set; }

        public bool IsValid { get; set; }
        public DateTime CreatedAt { get; set; }
        public IReadOnlyCollection<string> Roles { get; }

        public static void CreateModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiKey>(x =>
            {
                x.HasIndex(apiKey => apiKey.Key).IsUnique();
            });
        }
    }
}
