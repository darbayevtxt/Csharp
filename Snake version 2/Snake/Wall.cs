/*using System;
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
            StreamReader sr = new StreamReader(@"C:\Users\Nurdaulet\Desktop\Programming\Snake\Snake\bin\level.txt");
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
*/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Snake
{
     public class Wall:GameObject
    {
        enum GameLevel
        {
            First,
            Second,
            Third
        }

        GameLevel gameLevel = GameLevel.First;


        public Wall(char sign, ConsoleColor color) : base(0, 0, sign, color)
        {
            body = new List<Point>();
        }

        public void Level(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            string s = "";
            int y = 0;
            while ((s = sr.ReadLine()) != null)
            {
                for (int x = 0; x < s.Length; x++)
                    if (s[x] == '*')
                        body.Add(new Point(x, y));
                y++;
            }
            sr.Close();
        }
        public void LoadLevel()
        {
            body = new List<Point>();
            if (gameLevel == GameLevel.First)
            {
                Level("level1.txt");
            }
            if (gameLevel == GameLevel.Second)
            {
                Level("level2.txt");
            }
            if (gameLevel == GameLevel.Third)
            {
                Level("level3.txt");
            }
        }
        public void NextLevel()
        {
            if (gameLevel == GameLevel.First)
                gameLevel = GameLevel.Second;
            else if (gameLevel == GameLevel.Second)
                gameLevel = GameLevel.Third;
            LoadLevel();
        }
    }
}
