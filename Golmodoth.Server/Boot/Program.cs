using System.Threading.Tasks;

namespace Golmodoth.Server
{
    class Program
    {
        static async Task Main(string[] args) => await new Startup(args).StartAsync();
    }
}
