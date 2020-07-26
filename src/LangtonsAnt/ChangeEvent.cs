using System.Drawing;

namespace LangtonsAnt
{
    public readonly struct ChangeEvent
    {
        public Point Point { get; }
        public Color Color { get; }

        public ChangeEvent(Point point, Color color)
        {
            Point = point;
            Color = color;
        }
    }
}