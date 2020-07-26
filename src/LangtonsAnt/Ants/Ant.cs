using System;
using System.Drawing;

namespace LangtonsAnt
{
    public abstract class Ant
    {
        private readonly int _width;
        private readonly int _height;

        protected Ant(int width, int height, Point start)
        {
            _width = width;
            _height = height;
            Pos = start;
        }

        public Point Pos { get; protected set; }

        protected Direction Direction { get; private set; }

        public abstract byte Move(byte oldState);

        private void MoveUp()
        {
            Pos = new Point((Pos.X + _height - 1) % _height, Pos.Y);
        }

        private void MoveDown()
        {
            Pos = new Point((Pos.X + 1) % _height, Pos.Y);
        }

        private void MoveLeft()
        {
            Pos = new Point(Pos.X, (Pos.Y + _width - 1) % _width);
        }

        private void MoveRight()
        {
            Pos = new Point(Pos.X, (Pos.Y + 1) % _width);
        }

        protected void MoveForward()
        {
            switch (Direction)
            {
                case Direction.Up: MoveUp();
                    break;
                case Direction.Down: MoveDown();
                    break;
                case Direction.Left: MoveLeft();
                    break;
                case Direction.Right: MoveRight();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected void TurnRight()
        {
            Direction = Direction switch
            {
                Direction.Up => Direction.Right,
                Direction.Right => Direction.Down,
                Direction.Down => Direction.Left,
                Direction.Left => Direction.Up,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        protected void TurnLeft()
        {
            Direction = Direction switch
            {
                Direction.Up => Direction.Left,
                Direction.Right => Direction.Up,
                Direction.Down => Direction.Right,
                Direction.Left => Direction.Down,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}