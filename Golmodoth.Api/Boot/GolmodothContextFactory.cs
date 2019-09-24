using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Golmodoth.Api.Boot
{
    public class GolmodothContextFactory : IDesignTimeDbContextFactory<GolmodothContext>
    {
        public GolmodothContext CreateDbContext(string[] args) => new GolmodothContext(new AppConfig(), null);
    }
}
