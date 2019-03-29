using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace snake
{
    public class Snake : GameObject
    {
        enum Direction
        {
            NONE,
            RIGHT,
            LEFT,
            UP,
            DOWN
        }
        Direction direction = Direction.NONE;
        public bool ok = true; 
        public Snake(int x, int y, char sign, ConsoleColor color) : base(x, y, sign, color)
        {

        }

        public void Move()
        {
            if (direction == Direction.NONE)
                return;

            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            if (direction == Direction.UP)
                body[0].y--;
            if (direction == Direction.DOWN)
                body[0].y++;
            if (direction == Direction.LEFT)
                body[0].x--;
            if (direction == Direction.RIGHT)
                body[0].x++;
        }

        public void ChangeDirection(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.UpArrow)
                direction = Direction.UP;
            if (keyInfo.Key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
            if (keyInfo.Key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            if (keyInfo.Key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
        }

        public void CanYouMove(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.UpArrow && direction == Direction.DOWN)
            {
                ok = false;
                return;
            }
            if (keyInfo.Key == ConsoleKey.DownArrow && direction == Direction.UP)
            {
                ok = false;
                return;
            }
            if (keyInfo.Key == ConsoleKey.RightArrow && direction == Direction.LEFT)
            {
                ok = false;
                return;
            }
            if (keyInfo.Key == ConsoleKey.LeftArrow && direction == Direction.RIGHT)
            {
                ok = false;
                return;
            }
        }

    }
}