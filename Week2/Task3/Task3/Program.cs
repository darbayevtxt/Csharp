using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_3
{
    class Program
    {
        static void MyDirectoryTree(DirectoryInfo root, int lvl)
        {
            FileInfo[] files = root.GetFiles();
            DirectoryInfo[] directories = root.GetDirectories();

            foreach (DirectoryInfo d in directories)
            {
                for (int i = 0; i < lvl; ++i)
                    Console.Write(" ");
                Console.WriteLine(d.Name);
                MyDirectoryTree(d, lvl + 3);
            }
            foreach (FileInfo file in files)
            {
                for (int i = 0; i < lvl; ++i)
                    Console.Write(" ");
                Console.WriteLine(file.Name);
            }

        }
        static void Main(string[] args)
        {
            DirectoryInfo lol = new DirectoryInfo("C:/Users/Nurdaulet/Desktop/PP2");
            MyDirectoryTree(lol, 0);
            Console.ReadKey();
        }
    }
}