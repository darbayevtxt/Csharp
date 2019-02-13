using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            String[] s = sr.ReadToEnd().Split();
            int n = s.Count();
            int[] a = new int[n];
            List<int> ans = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int pr = 0;
                a[i] = int.Parse(s[i]);
                for (int j = 2; j <= (int)Math.Sqrt(a[i]); j++)
                {
                    if (a[i] % j == 0)
                    {
                        pr = 1;
                        break;
                    }

                }
                if (pr == 0 && a[i] != 1)
                {
                    ans.Add(a[i]);
                }
            }
            StreamWriter sw = new StreamWriter("output.txt");
            for (int i = 0; i < ans.Count(); i++)
            {
                sw.Write(ans[i] + " ");
            }
            sr.Close();
            sw.Close();
            Console.ReadKey();
        }
    }
}
