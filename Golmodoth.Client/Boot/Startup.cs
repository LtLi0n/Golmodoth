using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Golmodoth.Client
{
    public class Startup
    {
        public ReadOnlyCollection<string> Args { get; }

        public CoreConsole GameConsole { get; }

        public Startup(string[] args)
        {
            Args = new ReadOnlyCollection<string>(args);
            GameConsole = new CoreConsole(); 
        }

        public async Task StartAsync()
        {
            GameConsole.Construct(125, 50, 15, 20, ConsoleGameEngine.FramerateMode.Unlimited);
            await Task.Delay(-1);
        }
    }
}
