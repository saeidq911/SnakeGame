using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    };
    public class Setting
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static Direction Direction { get; set; }

        public Setting()
        {
            GameOver = false;
            Width = 18;
            Height = 18;

            Speed = 10;
            Score = 0;
            Points = 100;
            Direction = Direction.Right;

        }


    }
}
