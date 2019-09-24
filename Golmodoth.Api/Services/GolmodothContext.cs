using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Golmodoth.Shared;
using LionLibrary.Framework;

namespace Golmodoth.Api
{
    public class GolmodothContext : DbContext
    {
        public DbSet<ApiKey> ApiKeys { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }

        private readonly ILogService _logger;
        private readonly AppConfig _config;

        public GolmodothContext(DbContextOptions<GolmodothContext> options, AppConfig config, ILogService logger = null) : base(options)
        {
            _config = config;
            _logger = logger;
            Init();
        }

        public GolmodothContext(AppConfig config, ILogService logger) : base()
        {
            _config = config;
            _logger = logger;
            SyncMysqlOptions(new DbContextOptionsBuilder(), config);
            Init();
        }

        private void Init()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            if (!optionsBuilder.IsConfigured)
            {
                if (_config != null) SyncMysqlOptions(optionsBuilder, _config);
                else throw new ArgumentNullException("Configuration failed.");
            }
        }

        public static void SyncMysqlOptions(DbContextOptionsBuilder optionsBuilder, AppConfig config)
        {
            optionsBuilder.UseMySql(
                $"server={config.Server};" +
                $"database={config.Database};" +
                $"user={config.User};" +
                $"password={config.Password}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApiKey.CreateModel(modelBuilder);

            User.CreateModel(modelBuilder);
            Character.CreateModel(modelBuilder);
        }
    }
}
