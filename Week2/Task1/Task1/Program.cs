using System;
using System.Linq;
using System.IO;

namespace Task_1
{
    class Program
    {

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string s = sr.ReadToEnd();
            char[] ch = s.ToArray();
            Array.Reverse(ch);
            string reverse = String.Empty;
            for (int i = 0; i < ch.Length; i++)
            {
                reverse += ch[i];
            }
            if (s != reverse)
            {
                Console.WriteLine("No");

            }
            else
            {
                Console.WriteLine("Yes");

            }
            Console.ReadKey();
        }
    }
}