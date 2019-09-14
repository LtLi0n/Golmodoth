using System.Threading.Tasks;

namespace Golmodoth.Client
{
    class Program
    {
        static async Task Main(string[] args) => await new Startup(args).StartAsync();
    }
}
