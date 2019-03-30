using System;
using System.Threading;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
           int a = int.Parse(Console.ReadLine());
            Number n = new Number(a);
            n.Start(n.N);
        }
    }
}
    public class Number
    {
        public int N;
        public Number(int N)
        {
            this.N = N;
        }
        public void Start(int N)
        {

            Thread th = new Thread(Wark);
            Thread th2 = new Thread(Work);
            th.Start();
            th2.Start();


        }

        public void Wark()
        {
            while (true)
            {
                Factorial();
                Thread.Sleep(700);
            }
        }
        public void Work()
        {
            while (true)
            {

                Sum();
                Thread.Sleep(700);

            }

        }
        public void Sum()
        {
            int ann = 0;
            for (int i = 1; i <= N; i++)
            {
                ann += i;
            }
            Console.WriteLine("Sum of " + N + " is :" + ann);


        }

        public void Factorial()
        {

            int ans = 1;
            for (int i = 2; i <= N; i++)
                ans *= i;
            Console.WriteLine("Factorial of " + N + " is :" + ans);
        }
    }


