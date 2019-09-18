using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGameEngine;

using static ConsoleGameEngine.ColorPalettes.PaletteColorContainer_DefaultWindowsScheme;

namespace Golmodoth.Client
{
    public class LoginWindow : Window
    {
        private string _username;
        private string _password;

        private static string TITLE { get; } = "Welcome to Golmodoth Online 0.01";

        private readonly Animation _titleFireLeft;
        private readonly Animation _titleFireRight;

        public LoginWindow(ISizeable size) : base(size)
        {
            VisibleFrame = CreateFrame();

            _titleFireLeft = CreateTitleFireAnimation(new Point(Width / 2 - TITLE.Length / 2 - 7, 0));
            _titleFireRight = CreateTitleFireAnimation(new Point(Width / 2 + TITLE.Length / 2 + 3, 0));
        }

        private Animation CreateTitleFireAnimation(Point offset)
        {
            Animation titleFire = new Animation { Speed = TimeSpan.FromMilliseconds(200) };

            Size size = new Size(5, 7);
            {
                FrameBuilder fire = new FrameBuilder(size) { Offset = offset };

                fire.Color = FG_CYAN;
                fire.WriteLine("| o |");
                fire.WriteLine("|o o|");
                fire.WriteLine("| o |");
                fire.Write('|'); fire.Write("---", FG_YELLOW); fire.WriteLine('|', FG_CYAN);
                fire.WriteLine("| o |");
                fire.WriteLine("|o o|");
                fire.Color = FG_YELLOW;
                fire.WriteLine("--+--");

                titleFire.Frames.Add(fire.Build());
            }
            {
                FrameBuilder fire = new FrameBuilder(size) { Offset = offset };

                fire.Color = FG_CYAN;
                fire.WriteLine("|o o|");
                fire.WriteLine("| o |");
                fire.Write('|'); fire.Write("---", FG_YELLOW); fire.WriteLine('|', FG_CYAN);
                fire.WriteLine("| o |");
                fire.WriteLine("|o o|");
                fire.WriteLine("| o |");
                fire.Color = FG_YELLOW;
                fire.WriteLine("--+--");

                titleFire.Frames.Add(fire.Build());
            }
            {
                FrameBuilder fire = new FrameBuilder(size) { Offset = offset };
                fire.Color = FG_CYAN;
                fire.WriteLine("| o |");
                fire.Write('|'); fire.Write("---", FG_YELLOW); fire.WriteLine('|', FG_CYAN);
                fire.WriteLine("| o |");
                fire.WriteLine("|o o|");
                fire.WriteLine("| o |");
                fire.WriteLine("|o o|");
                fire.Color = FG_YELLOW;
                fire.WriteLine("--+--");

                titleFire.Frames.Add(fire.Build());
            }
            {
                FrameBuilder fire = new FrameBuilder(size) { Offset = offset };
                fire.Color = FG_CYAN;
                fire.Write('|'); fire.Write(" - ", FG_YELLOW); fire.WriteLine('|', FG_CYAN);
                fire.WriteLine("| o |");
                fire.WriteLine("|o o|");
                fire.WriteLine("| o |");
                fire.WriteLine("|o o|");
                fire.WriteLine("| o |");
                fire.Color = FG_YELLOW;
                fire.WriteLine("--+--");

                titleFire.Frames.Add(fire.Build());
            }
            {
                FrameBuilder fire = new FrameBuilder(size) { Offset = offset };
                fire.Color = FG_CYAN;
                fire.WriteLine("| o |");
                fire.WriteLine("|o o|");
                fire.WriteLine("| o |");
                fire.WriteLine("|o o|");
                fire.WriteLine("| o |");
                fire.Write('|'); fire.Write(" - ", FG_YELLOW); fire.WriteLine('|', FG_CYAN);
                fire.Color = FG_YELLOW;
                fire.WriteLine("--+--");

                titleFire.Frames.Add(fire.Build());
            }
            {
                FrameBuilder fire = new FrameBuilder(size) { Offset = offset };
                fire.Color = FG_CYAN;
                fire.WriteLine("|o o|");
                fire.WriteLine("| o |");
                fire.WriteLine("|o o|");
                fire.WriteLine("| o |");
                fire.Write('|'); fire.Write("---", FG_YELLOW); fire.WriteLine('|', FG_CYAN);
                fire.WriteLine("| o |");
                fire.Color = FG_YELLOW;
                fire.WriteLine("--+--");

                titleFire.Frames.Add(fire.Build());
            }


            return titleFire;
        }

        public Frame CreateFrame()
        {
            FrameBuilder fb = new FrameBuilder(this);

            //Title
            {
                fb.Cursor = new Point(0, 4);
                int empty_left = Width / 2 - TITLE.Length / 2;
                fb.Write(new string(' ', empty_left));
                
                fb.Write(TITLE, FG_GREEN);
                fb.Write(new string(' ', Width - empty_left - TITLE.Length), FG_BLACK);
            }

            return fb.Build();
        }

        public override void OnRender(ConsoleEngine engine)
        {
            _titleFireLeft.Render(engine);
            _titleFireRight.Render(engine);
        }

        public override void OnUpdate(CoreConsole console)
        {
            _titleFireLeft.Update(console);
            _titleFireRight.Update(console);
            VisibleFrame = CreateFrame();
        }
    }
}
