using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Timers;
using LangtonsAnt;

namespace LangtonsAntConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var game = new AntGame(10, 10, new ConsoleRender());
                var timer = new Timer(100);
                timer.Elapsed += (s, e) =>
                {
                    try
                    {
                        game.Cycle();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                };
                timer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }

    public class ConsoleRender : IRender
    {
        public void Render(IEnumerable<ChangeEvent> events)
        {
            foreach (ChangeEvent @event in events)
            {
                Debug.WriteLine($"{@event.Point} = {@event.Color}");
                Console.SetCursorPosition(@event.Point.X, @event.Point.Y);
                Console.BackgroundColor = ConvertColor(@event.Color);
                Console.Write(' ');
            }
        }

        private static ConsoleColor ConvertColor(Color color)
        {
            if (color == Color.Red) return ConsoleColor.Red;
            if (color == Color.Green) return ConsoleColor.Green;
            if (color == Color.White) return ConsoleColor.White;
            if (color == Color.Black) return ConsoleColor.Black;

            return ConsoleColor.Yellow;
        }
    }
}