using ConsoleGameEngine;

namespace Golmodoth.Client
{
    ///<summary>Construct a frame by writing.</summary>
    public class FrameBuilder
    {
        public ISizeable Size { get; }

        private readonly Frame _frame;

        ///<summary>Cursor position</summary>
        public Point Cursor { get; set; }
        ///<summary>Offset the cursor position by fixed about.</summary>
        public Point Offset { get; set; }
        public Point FinalCursor => Cursor + Offset;

        public byte Color { get; set; }

        public FrameBuilder(ISizeable size)
        {
            _frame = new Frame(size);
            Size = size;
        }

        public void WriteLine(object content)
        {
            Write(content);
            NewLine();
        }

        public void Write(object content)
        {
            string contentStr = content.ToString();
            for(int i = 0; i < contentStr.Length; i++)
            {
                if(contentStr[i] == '\n')
                {
                    NewLine();
                }
                else
                {
                    _frame[FinalCursor.X, FinalCursor.Y] = new ConsolePixel(Color, contentStr[i]);
                    Cursor += new Point(1, 0);
                    CheckAgainstHorizontalAxis();
                }
            }
        }

        public void NewLine()
        {
            Cursor = new Point(0, Cursor.Y + 1);
            CheckAgainstVerticalAxis();
        }

        public void CheckAgainstHorizontalAxis()
        {
            if (FinalCursor.X > Size.Width - 1)
            {
                Cursor -= new Point(1, 0);
            }
        }

        public void CheckAgainstVerticalAxis()
        {
            if (FinalCursor.Y > Size.Height - 1)
            {
                Cursor -= new Point(0, 1);
            }
        }

        public Frame Build() => _frame;
    }
}
