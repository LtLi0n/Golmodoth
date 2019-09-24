using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Golmodoth.Server
{
    public class Startup
    {
        public IReadOnlyCollection<string> Args { get; }

        public Startup(string[] args)
        {
            Args = new ReadOnlyCollection<string>(args);
        }

        public async Task StartAsync()
        {
            await Task.Delay(-1);
        }
    }
}
