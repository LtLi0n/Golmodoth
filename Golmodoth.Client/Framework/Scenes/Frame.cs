using ConsoleGameEngine;

namespace Golmodoth.Client
{
    public class Frame : ISizeable
    {
        public int Width { get; }
        public int Height { get; }

        public ConsolePixel[,] Pixels { get; set; }
        public Point Offset { get; set; } = new Point(0, 0);

        public ConsolePixel this[int x, int y]
        {
            get => Pixels[x, y];
            set => Pixels[x, y] = value;
        }

        public Frame(ISizeable size)
        {
            Width = size.Width;
            Height = size.Height;
            Pixels = new ConsolePixel[Width, Height];
        }

        //todo
        public void PopulatePixelBuffer()
        {

        }

        public void Render(ConsoleEngine engine)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    ConsolePixel pixel = Pixels[x, y];
                    engine.SetPixel(x + Offset.X, y + Offset.Y, pixel.Color, pixel.Glyph);
                }
            }
        }
    }
}
