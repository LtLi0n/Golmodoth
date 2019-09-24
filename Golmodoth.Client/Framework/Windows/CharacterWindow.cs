using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGameEngine;

using static ConsoleGameEngine.ColorPalettes.PaletteColorContainer_DefaultWindowsScheme;

namespace Golmodoth.Client
{
    public class CharacterWindow : Window
    {
        private const byte BORDER_COLOR = FG_DARK_GREY;
        private const byte CONJUNCTION_COLOR = FG_GREY;
        private const byte TITLE_COLOR = FG_WHITE;
        private const string TITLE = "Character";
        private const char BORDER_GLYPGH = '=';

        private readonly SocketCharacter _character;

        public CharacterWindow(ISizeable size, Window parent) : base(size)
        {
            Parent = parent;

            _character = new SocketCharacter()
            {
                Name = "LtLi0n",
                TotalXp = "0",
                Gold = 0
            };

            VisibleFrame = CreateFrame(size);
        }

        private Frame CreateFrame(ISizeable size)
        {
            FrameBuilder fb = new FrameBuilder(size)
            {
                Color = FG_WHITE,
                Offset = new Point(4, 2)
            };

            string levelProgress = _character.LevelProgress.ToString();

            int width = _character.Name.Length;
            int reserved_width = 2 + TITLE.Length;

            if (levelProgress.Length > width)
            {
                width = levelProgress.Length + 1;
            }

            if (width < 24)
            {
                width = 24;
            }

            //top border
            int top_border_remaining = width - reserved_width;
            {
                int border_n = top_border_remaining / 2;

                fb.Color = CONJUNCTION_COLOR;
                fb.Write('+');
                fb.Color = BORDER_COLOR;
                fb.Write(new string(BORDER_GLYPGH, border_n));
                
                fb.Color = TITLE_COLOR;
                fb.Write("[Character]");

                fb.Color = BORDER_COLOR;
                fb.Write(new string(BORDER_GLYPGH, top_border_remaining - border_n));
                fb.Color = CONJUNCTION_COLOR;
                fb.WriteLine('+');
            }

            fb.NewLine();
            fb.WriteLine($"  Name: {_character.Name}");
            fb.WriteLine($"  {levelProgress}");
            return fb.Build();
        }

        public override void OnRender(ConsoleEngine engine) { }

        public override void OnUpdate(CoreConsole console)
        {
            if (console.KeyPressed(ConsoleKey.D2))
            {

            }
            else if(console.KeyPressed(ConsoleKey.Spacebar))
            {
                _character.TotalXp += _character.LevelProgress.Level * 10;
                VisibleFrame = CreateFrame(this);
            }
        }
    }
}
