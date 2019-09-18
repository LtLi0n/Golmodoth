namespace Golmodoth.Client
{
    public struct Size : ISizeable
    {
        public int Width { get; }
        public int Height { get; }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Size(ISizeable size)
        {
            Width = size.Width;
            Height = size.Height;
        }
    }
}
