using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake : GameObject, ISnake
    {
        public bool up = true;
        public bool down = true;
        public bool right = true;
        public bool left = true;
        public bool change = true;
        
        public Snake(int x, int y, char sign, ConsoleColor color) : base(x, y, sign, color)
        {
        }

        

        public void Move(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (down)
                {
                    body[0].y++;
                    up = false;
                    right = true;
                    left = true;
                    change = true;
                }
                else
                    change = false;
                if (body[0].y == 30)
                {
                    body[0].y = 0;
                }
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (up)
                {
                    body[0].y--;
                    down = false;
                    right = true;
                    left = true;
                    change = true;
                }
                else
                    change = false;
                if (body[0].y == 0)
                {
                    body[0].y = 30;
                }
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (left)
                {
                    body[0].x--;
                    right = false;
                    down = true;
                    up = true;
                    change = true;
                }
                else
                    change = false;
                if (body[0].x == 0)
                {
                    body[0].x = 119;
                }
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                if (right)
                {
                    body[0].x++;
                    left = false;
                    down = true;
                    up = true;
                    change = true;
                }
                else
                    change = false;
                if (body[0].x == 119)
                {
                    body[0].x = 0;
                }
            }
            for (int i = body.Count - 1; i > 0 && change; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
        }

        public bool IsCollisionWithFood(Food food)
        {
            if (body[0].x == food.body[0].x && body[0].y == food.body[0].y)
                return true;
            return false;
        }

        public bool IsCollistionWithWall(Wall wall)
        {
            foreach (Point p in wall.body)
            {
                if (p.x == body[0].x && p.y == body[0].y)
                    return true;
            }
            return false;
        }

        public bool IsCollisionWithSnake()
        {
            for (int i = 1; i < body.Count; i++)
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
