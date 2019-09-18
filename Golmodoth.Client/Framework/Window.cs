using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Golmodoth.Client
{
    public abstract class Window : IEngineObject, ISizeable
    { 
        public int Width { get; }
        public int Height { get; }

        public Window Parent { get; set; }
        public Window[] ChildWindows { get; set; }

        public Frame VisibleFrame { get; set; }

        //default
        public Window(ISizeable size) 
        {
            Width = size.Width;
            Height = size.Height;
        }

        public Window(ISizeable size, Window parentWindow)
        {
            Width = size.Width;
            Height = size.Height; 
            Parent = parentWindow;
        }

        public Window(ISizeable size, Window[] childWindows)
        {
            Width = size.Width;
            Height = size.Height;
            ChildWindows = childWindows;
        }

        public Window(ISizeable size, Window parent, Window[] childWindows)
        {
            Width = size.Width;
            Height = size.Height;
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
            VisibleFrame.Render(engine);
            OnRender(engine);
        }
    }
}
