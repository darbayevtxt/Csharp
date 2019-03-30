﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    [Serializable]
    public class Snake
    {
        public List<Point> body;
        public Point head;
        public Point tail;
        public Direction direction;
        public Snake()
        {
            body = new List<Point>();
        }
        public void AddElements()
        {
            for (int i = 0; i < 3; i++)
            {
                body.Add(new Point(Console.WindowWidth / 2 + i, Console.WindowHeight / 2, '*', ConsoleColor.Red));
            }
            head = body.Last();
            tail = body.First();
            head.color = ConsoleColor.Green;
        }//
        int a = 2;
        public void HandleDirection(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.RightArrow:
                    if (a != 1)
                    {
                        direction = Direction.RIGHT;
                        a = 2;
                        break;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (a != 2)
                    {
                        direction = Direction.LEFT;
                        a = 1;
                        break;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (a != 3)
                    {
                        direction = Direction.UP;
                        a = 4;
                        break;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (a != 4)
                    {
                        direction = Direction.DOWN;
                        a = 3;
                        break;
                    }
                    break;
            }
        }

        public void Draw()
        {
            head = body.Last();
            tail = body.First();
            head.color = ConsoleColor.Green;
            foreach (Point p in body)
            {
                if (p == head)
                    p.color = ConsoleColor.Green;
                else
                    p.color = ConsoleColor.Red;

                Console.ForegroundColor = p.color;
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(p.sym);
            }
        }

        public void Grow()//
        {
            Point newTail = new Point(tail);
            switch (direction)
            {
                case Direction.RIGHT:
                    newTail.x = newTail.x - 1;
                    break;
                case Direction.LEFT:
                    newTail.x = newTail.x + 1;
                    break;
                case Direction.UP:
                    newTail.y = newTail.y + 1;
                    break;
                case Direction.DOWN:
                    newTail.y = newTail.y - 1;
                    break;
            }
            tail = newTail;
            body.Insert(0, newTail);
        }

        public bool EatFood()
        {
            if (Game.food.food.x == head.x && Game.food.food.y == head.y)
                return true;
            return false;
        }

        public void Move()
        {
            tail.Clear();
            for (int i = 0; i < body.Count - 1; i++)
            {

                body[i].x = body[i + 1].x;
                body[i].y = body[i + 1].y;
                body[i].color = ConsoleColor.Red;
            }
            if (head.x < 1)
                head.x = Console.WindowWidth - 1;
            if (head.x > Console.WindowWidth - 1)
                head.x = 1;

            if (head.y < 1)
                head.y = Console.WindowHeight - 1;
            if (head.y > Console.WindowHeight - 1)
                head.y = 1;

            switch (direction)
            {
                case Direction.RIGHT:
                    head.x = head.x + 1;
                    break;
                case Direction.LEFT:
                    head.x = head.x - 1;
                    break;
                case Direction.UP:
                    head.y = head.y - 1;
                    break;
                case Direction.DOWN:
                    head.y = head.y + 1;
                    break;
            }

        }

        public bool EatBody()
        {
            for (int i = 0; i < body.Count - 1; i++)
            {
                if (head.x == body[i].x && head.y == body[i].y)
                    return true;
            }
            return false;
        }

        public bool EatWalls()
        {
            for (int i = 0; i < Game.walls.body.Count; i++)
            {
                if (head.x == Game.walls.body[i].x && head.y == Game.walls.body[i].y)
                    return true;
            }
            return false;
        }
    }
}