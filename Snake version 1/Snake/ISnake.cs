using System;

namespace Snake
{
    public interface ISnake
    {
        bool Equals(object obj);
        int GetHashCode();
        bool IsCollisionWithFood(Food food);
        bool IsCollisionWithSnake();
        bool IsCollistionWithWall(Wall wall);
        void Move(ConsoleKeyInfo keyInfo);
        string ToString();
    }
}