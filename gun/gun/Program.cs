using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Gun
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(70, 20);
            Console.SetBufferSize(70, 20);
            Console.WriteLine("#########");
            Console.WriteLine("##@");
            Console.WriteLine("##");

            ConsoleKeyInfo consoleKeyInfo;

            while (true)
            {
                consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.Spacebar)
                {
                    Thread thread = new Thread(Draw);

                    thread.Start();
                }
            }

        }

        static void Draw()
        {
            int x = 10, xlast = 10;
            while (x < 70)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write(" *");
                x++;
                Thread.Sleep(100);
            }
        }
    }
}