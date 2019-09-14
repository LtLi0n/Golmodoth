using ConsoleGameEngine;

namespace Golmodoth.Client
{
    public class Frame
    {
        public ConsolePixel[,] Pixels { get; set; }
        public ISizeable Size { get; }

        public ConsolePixel this[int x, int y]
        {
            get => Pixels[x, y];
            set => Pixels[x, y] = value;
        }

        public Frame(ISizeable size)
        {
            Size = size;
            Pixels = new ConsolePixel[Size.Width, Size.Height];
        }

        //todo
        public void PopulatePixelBuffer()
        {

        }

        public void Draw(ConsoleEngine engine)
        {
            for (int y = 0; y < Size.Height; y++)
            {
                for (int x = 0; x < Size.Width; x++)
                {
                    ConsolePixel pixel = Pixels[x, y];
                    engine.SetPixel(x, y, pixel.Color, pixel.Glyph);
                }
            }
        }
    }
}
