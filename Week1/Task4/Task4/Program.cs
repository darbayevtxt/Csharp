using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //преобразую строки в инты
            for (int i = 0; i < n; i++) // цикл 
            {
                for (int j = 0; j <= n; j++) // второй цикл 
                {
                    if (i >= j)
                    {
                        Console.Write("[*]");

                    }
                    if (j == n)
                    {
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
