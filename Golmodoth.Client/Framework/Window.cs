using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Golmodoth.Client
{
    public abstract class Window : IEngineObject
    { 
        public Window Parent { get; set; }
        public Window[] ChildWindows { get; set; }

        public Frame VisibleFrame { get; set; }

        //default
        public Window() { }

        public Window(Window parentWindow)
        {
            Parent = parentWindow;
        }

        public Window(Window[] childWindows)
        {
            ChildWindows = childWindows;
        }

        public Window(Window parent, Window[] childWindows)
        {
            Parent = parent;
            ChildWindows = childWindows;
        }

        public abstract void OnUpdate(CoreConsole console);
        public void Update(CoreConsole console)
        {
            if (console.KeyPressed(ConsoleKey.Escape) && Parent != null)
            {
                console.ActiveWindow = Parent;
                return;
            }
            OnUpdate(console);
        }

        public abstract void OnRender(ConsoleEngine engine);
        public void Render(ConsoleEngine engine)
        {
            VisibleFrame.Draw(engine);
            OnRender(engine);
        }
    }
}
