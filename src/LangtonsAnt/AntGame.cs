using System;
using System.Collections.Generic;
using System.Drawing;

namespace LangtonsAnt
{
    public class AntGame
    {
        private readonly byte[,] _field;
        private readonly Ant[] _ants;
        private readonly IRender _render;

        public AntGame(int width, int height, IRender render)
        {
            _render = render ?? throw new ArgumentNullException(nameof(render));
            _field = new byte[width, height];
            _ants = new Ant[]
            {
                new AntRL(width, height, new Point(width / 2, height / 2))
            };
        }

        public void Cycle()
        {
            var events = new List<ChangeEvent>(_ants.Length * 2);
            foreach (Ant ant in _ants)
            {
                Point prevPos = ant.Pos;
                byte prevState = _field[prevPos.X, prevPos.Y];
                byte newState = ant.Move(prevState);
                _field[prevPos.X, prevPos.Y] = newState;

                events.Add(new ChangeEvent(prevPos, GetColor(newState)));

                events.Add(new ChangeEvent(ant.Pos, Color.Red));
            }

            _render.Render(events);
        }

        private static Color GetColor(byte state)
            => state switch
            {
                0 => Color.Black,
                1 => Color.White,
                _ => Color.Green
            };
    }
}