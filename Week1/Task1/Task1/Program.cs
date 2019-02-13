using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine()); //создаю integer чтобы он стал размером массива
            
            int[] arr = new int[a]; //создаю массив

            List<int> ans = new List<int>(); //создаю динамический массив list для ответов
            string[] s = Console.ReadLine().Split(); //считаю числа и сохраная их как strings

            for (int i = 0; i < arr.Length; i++) //цикл
            {
                arr[i] = int.Parse(s[i]); //сохраняю стринги ввиде чисел
                int prime = 0; 
                for (int j = 2; j <= (int)Math.Sqrt(arr[i]); j++)//второй цикл 
                {
                    if (arr[i] % j == 0)//проверка на делимость чисел 
                    {
                        prime = 1;
                        break;
                    }

                }
                if (prime == 0 && arr[i] != 1)//добавляю числа в массив
                {
                    ans.Add(arr[i]);
                }

            }
            Console.WriteLine(ans.Count);
            for (int i = 0; i < ans.Count; i++)
            {
                Console.Write(ans[i] + " "); //вывожу числа прайм
            }
            Console.ReadKey();
        }
    }
}
