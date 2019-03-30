using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace traffic 
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Draw);
            t1.Start();
        }
        static void Draw()
        {
            int i = 1;
            int y = 0;
            while (i < 10)
            {
                if (i % 3 == 1)
                {
                    y = 10;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Thread.Sleep(2000);
                }
                else if (i % 3 == 2)
                {
                    y++;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Thread.Sleep(1500);
                }
                else
                {
                    y++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Thread.Sleep(3000);
                }
                i++;
                Console.Clear();
                Console.CursorVisible = false;
                Console.SetCursorPosition(20, y);
                Console.Write('0');

            }
        }
    }
}
