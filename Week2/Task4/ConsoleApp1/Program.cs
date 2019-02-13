using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathString = @"C:\Users\Nurdaulet\Desktop\papka\path";
            string fileName = "Nurda.txt";
            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathString))//сделать через стрим врайтер и копи делет через файл 
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
                return;
            }
            string destFile = "C:/Users/Nurdaulet/Desktop/papka/path/Nurda.txt";
            string sourceFile = "C:/Users/Nurdaulet/Desktop/papka/path1/Nurda.txt";
            System.IO.File.Copy(sourceFile, destFile, true);
            if (System.IO.File.Exists("C:/Users/Nurdaulet/Desktop/papka/path/Nurda.txt"))
            {

                try
                {
                    System.IO.File.Delete("C:/Users/Nurdaulet/Desktop/papka/path/Nurda.txt");
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

        }
    }
}
