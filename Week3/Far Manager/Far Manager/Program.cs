using System;
using System.IO;

namespace Far_Manager
{
    class FarManager
    {
        public bool ok = true;
        public int cursor;
        int sz = 0;
        public FarManager()
        {
            cursor = 0;
        }
        public void Color(FileSystemInfo fs, int index)
        {
            if (index == cursor)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (fs.GetType() == typeof(DirectoryInfo))
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }
        public void Up()
        {
            cursor--;
            if (cursor < 0)
            {
                cursor = sz - 1;

            }
        }
        public void Down()
        {
            cursor++;
            if (cursor == sz)
            {
                cursor = 0;

            }
        }

        public void Show(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] FileSystemInfos = directory.GetFileSystemInfos();
            int index = 0;
            sz = FileSystemInfos.Length;
            foreach (FileSystemInfo fs in FileSystemInfos)
            {

                if (ok && fs.Name.StartsWith("."))
                {
                    sz--;
                    continue;
                }
                this.Color(fs, index);
                Console.WriteLine(fs.Name);
                index++;
            }
        }
        public void Start(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] FileSystemInfos = directory.GetFileSystemInfos();
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            FileSystemInfo fs = null;
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Show(path);
                consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.Escape)
                {
                    cursor = 0;
                    directory = directory.Parent;
                    path = directory.FullName;
                }
                if (consoleKey.Key == ConsoleKey.UpArrow)
                    Up();
                if (consoleKey.Key == ConsoleKey.DownArrow)
                    Down();
                if (consoleKey.Key == ConsoleKey.RightArrow)
                    ok = false;
                if (consoleKey.Key == ConsoleKey.LeftArrow)
                    ok = true;
                if (consoleKey.Key == ConsoleKey.R)
                {
                    int k = 0;
                    for (int i = 0; i < directory.GetFileSystemInfos().Length; i++)
                    {
                        if (ok && directory.GetFileSystemInfos()[i].Name.StartsWith("."))
                            continue;
                        if (cursor == k)
                        {
                            fs = directory.GetFileSystemInfos()[i];
                            break;
                        }
                        k++;
                    }
                    Console.Clear();

                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    string s = Console.ReadLine();
                    if (fs.GetType() == typeof(DirectoryInfo))
                    {
                        string full = fs.FullName;
                        full = full.Remove(full.Length - fs.Name.Length);
                        new DirectoryInfo(fs.FullName).MoveTo(full + s);


                    }
                    else if (fs.GetType() == typeof(FileInfo))
                    {
                        new FileInfo(fs.FullName).MoveTo(fs.FullName + s);
                    }
                }
                if (consoleKey.Key == ConsoleKey.Enter)
                {
                    int k = 0;
                    for (int i = 0; i < directory.GetFileSystemInfos().Length; i++)
                    {
                        if (ok && directory.GetFileSystemInfos()[i].Name.StartsWith("."))
                            continue;
                        if (cursor == k)
                        {
                            fs = directory.GetFileSystemInfos()[i];
                            break;
                        }
                        k++;
                    }
                    if (fs.GetType() == typeof(DirectoryInfo))
                    {
                        cursor = 0;
                        directory = new DirectoryInfo(fs.FullName);
                        path = fs.FullName;
                    }
                    else if (fs.GetType() == typeof(FileInfo))
                    {
                        StreamReader sr = new StreamReader(fs.FullName);
                        string s = sr.ReadToEnd();
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(s);
                        Console.ReadKey();

                    }

                }
                if (consoleKey.Key == ConsoleKey.Delete)
                {
                    int k = 0;
                    for (int i = 0; i < directory.GetFileSystemInfos().Length; i++)
                    {
                        if (ok && directory.GetFileSystemInfos()[i].Name.StartsWith("."))
                            continue;
                        if (cursor == k)
                        {
                            fs = directory.GetFileSystemInfos()[i];
                            break;
                        }
                        k++;
                    }
                    if (fs.GetType() == typeof(DirectoryInfo))
                    {
                        (fs as DirectoryInfo).Delete(true);
                    }
                    else if (fs.GetType() == typeof(FileInfo))
                    {
                        (fs as FileInfo).Delete();
                    }
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                FarManager far = new FarManager();
                far.Start(@"C:\Users\Nurdaulet\Documents");

            }
        }
    }
}