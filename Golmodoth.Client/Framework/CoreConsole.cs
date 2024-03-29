﻿using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Text;

using static ConsoleGameEngine.ColorPalettes.PaletteColorContainer_DefaultWindowsScheme;

namespace Golmodoth.Client
{
    public class CoreConsole : ConsoleGame, ISizeable
    {
        public Window ActiveWindow { get; set; }

        public int Width => Engine.Width;
        public int Height => Engine.Height;

        private MenuWindow _menu;
        private LoginWindow _login;

        public CoreConsole() : base() { }

        public override void Create()
        {
            Console.Title = "Golmodoth";
            Engine.SetPalette(PaletteColor.Containers.Default);

            _login = new LoginWindow(this);
            ActiveWindow = _login;
        }

        public override void Render()
        {
            Engine.ClearBuffer();
            ActiveWindow.Render(Engine);
            Engine.DisplayBuffer();
        }

        public override void Update()
        {
            ActiveWindow.Update(this);
        }
    }
}
