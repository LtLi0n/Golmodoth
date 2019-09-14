using ConsoleGameEngine;

namespace Golmodoth.Client
{
    public interface IEngineObject
    {
        void Update(CoreConsole engine);
        void Render(ConsoleEngine console);
    }
}
