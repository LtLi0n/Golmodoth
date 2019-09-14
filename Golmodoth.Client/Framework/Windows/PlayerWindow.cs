using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGameEngine;

using static ConsoleGameEngine.ColorPalettes.PaletteColorContainer_DefaultWindowsScheme;

namespace Golmodoth.Client
{
    public class PlayerWindow : Window
    {
        public PlayerWindow(Window parent, ISizeable size) : base()
        {
            Parent = parent;

            FrameBuilder fb = new FrameBuilder(size)
            {
                Color = FG_GREEN,
                Offset = new Point(4, 2)
            };

            fb.WriteLine("Hello Player");
            fb.WriteLine("2) Character stuff");
            VisibleFrame = fb.Build();

            ChildWindows = new[]
            {
                new CharacterWindow(this, size)
            };
        }

        public override void OnRender(ConsoleEngine engine) { }

        public override void OnUpdate(CoreConsole console)
        {
            if(console.KeyPressed(ConsoleKey.D2))
            {
                console.ActiveWindow = ChildWindows[0];
            }
        }
    }
}
