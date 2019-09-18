using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGameEngine;

namespace Golmodoth.Client
{
    public class Animation : IEngineObject
    {
        private int _animationIndex;
        private DateTime _lastCheck;

        public TimeSpan Speed { get; set; } = TimeSpan.FromSeconds(1);
        public List<Frame> Frames { get; } = new List<Frame>();

        public Animation() { }

        public void Update(CoreConsole engine)
        {
            if(_lastCheck == default)
            {
                _lastCheck = DateTime.Now;
            }

            if (DateTime.Now - _lastCheck > Speed)
            {
                _lastCheck = _lastCheck.Add(Speed);

                if (_animationIndex + 1 >= Frames.Count)
                {
                    _animationIndex = 0;
                }
                else
                {
                    _animationIndex++;
                }
            }
        }

        public void Render(ConsoleEngine console)
        {
            Frames[_animationIndex].Render(console);
        }
    }
}
