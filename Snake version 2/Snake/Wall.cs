using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Snake
{
    [Serializable]
    public class Walls
    {
        public List<Point> body;

        public void StartLevel(int level)
        {
            StreamReader sr = new StreamReader(@"C:\Users\Nurdaulet\Documents\GitHub\Csharp\Snake version 2\Snake\bin\level.txt"); 
            int n = int.Parse(sr.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string s = sr.ReadLine();
                for (int j = 0; j < s.Length; j++)
                {
                    if (s[j] == '-')
                        body.Add(new Point(j, i, '#', ConsoleColor.DarkYellow));
                }
            }
            sr.Close();
        }
        public Walls(int level)
        {
            body = new List<Point>();

            StartLevel(level);
        }
        public Walls() 
{
        }
        
        public void Draw()
        {
            foreach (Point p in body)
            {

                Console.SetCursorPosition(p.x, p.y);
                Console.ForegroundColor = p.color;
                Console.Write(p.sym);
            }
        }

    }
}
