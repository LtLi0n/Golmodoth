using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGameEngine;

using static ConsoleGameEngine.ColorPalettes.PaletteColorContainer_DefaultWindowsScheme;

namespace Golmodoth.Client
{
    public class MenuWindow : Window
    {
        public MenuWindow(ISizeable size)
        {
            FrameBuilder fb = new FrameBuilder(size)
            {
                Color = FG_GREEN,
                Offset = new Point(4, 2)
            };

            fb.WriteLine("1) Play");
            fb.Color = FG_CYAN;
            fb.WriteLine("2) Player");
            fb.Color = FG_BLUE;
            fb.WriteLine("3) Exit");
            VisibleFrame = fb.Build();

            ChildWindows = new[]
            {
                new PlayerWindow(this, size)
            };
        }

        public override void OnRender(ConsoleEngine engine) { }

        public override void OnUpdate(CoreConsole console)
        {
            if(console.KeyPressed(ConsoleKey.Escape) || console.KeyPressed(ConsoleKey.D3))
            {
                Environment.Exit(0);
            }
            else if(console.KeyPressed(ConsoleKey.D2))
            {
                console.ActiveWindow = ChildWindows[0];
            }
        }
    }
}
