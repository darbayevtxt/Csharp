using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine()); // записываю  int для размера масива 
            int[] arr = new int[a]; // создал массив 
            string[] s = Console.ReadLine().Split(); // сохронил числа в виде strings
            for (int i = 0; i < arr.Length; i++) // cоздаю цикл 
            {
                arr[i] = int.Parse(s[i]); // придаю стригам значение числа 
                Console.Write(arr[i] + " " + arr[i] + " ");// вывожу на консоль два подряд числа 

            }
            Console.ReadKey(); // финиш
                }

          
    }
}
