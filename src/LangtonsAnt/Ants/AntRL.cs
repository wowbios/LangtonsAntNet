using System;
using System.Drawing;

namespace LangtonsAnt
{
    public class AntRL : Ant
    {
        public AntRL(int width, int height, Point start) : base(width, height, start)
        {
        }

        public override byte Move(byte oldState)
        {
            switch (oldState)
            {
                case 0:
                    TurnRight();
                    MoveForward();
                    return 1;
                case 1:
                    TurnLeft();
                    MoveForward();
                    return 0;
                default: throw new ArgumentException(nameof(oldState));
            }
        }
    }
}