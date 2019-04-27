using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake
{
    [Serializable]
    class Game
    {
        public string name;
        static public Snake snake;
        static public Walls walls;
        static public Food food;
        public static string text;
        public static int level;
        public int score;
        public bool gameover;
        // FileStream fs;

        public Game()
        {
            level = 1;
            score = 0;
            gameover = true;

        }
        public static void CreateObjects()
        {

            snake = new Snake();//
            //Game.snake.AddElements();//
            walls = new Walls(level);//
            food = new Food();//
                              //walls.StartLevel(level);//
                              // food.FoodGenerate();

        }
        public void GetName()
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.WriteLine("Enter your name: ");
            name = Console.ReadLine();
            CreateObjects();///////////////
            Game.snake.AddElements();
        }//
        public void InfoMenu()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.Write("1.New Game");
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 + 1);
            Console.Write("2.Continue Last Game");
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 + 2);
            Console.Write("3.Leader");
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 + 3);
        }//
        public void GameMenu()
        {
            Console.Clear();
            int choise = 0;
            InfoMenu();
            choise = int.Parse(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    GetName();
                    break;
                case 2:
                    GameResume();
                    break;
                case 3:
                    ShowLog();
                    ConsoleKeyInfo btn = Console.ReadKey(); ;
                    GameMenu();
                    break;

            }
        }//
        public void ShowLog()
        {
            StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\log.txt");
            Console.Clear();
            Console.Write(sr.ReadToEnd());
            sr.Close();
        }
        public void GamePause()
        {
            File.WriteAllText(@"C:\Users\User\Desktop\food.xml", string.Empty);
            File.WriteAllText(@"C:\Users\User\Desktop\walls.xml", string.Empty);
            File.WriteAllText(@"C:\Users\User\Desktop\snake.xml", string.Empty);
            File.WriteAllText(@"C:\Users\User\Desktop\snake.xml", string.Empty);
            FileStream snake_stream = new FileStream(@"C:\Users\User\Desktop\snake.xml", FileMode.OpenOrCreate, FileAccess.Write);
            FileStream walls_stream = new FileStream(@"C:\Users\User\Desktop\walls.xml", FileMode.OpenOrCreate, FileAccess.Write);
            FileStream food_stream = new FileStream(@"C:\Users\User\Desktop\food.xml", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sl = new StreamWriter(@"C:\Users\User\Desktop\levelser.txt", true);



            XmlSerializer snake_xml = new XmlSerializer(typeof(Snake));
            XmlSerializer walls_xml = new XmlSerializer(typeof(Walls));
            XmlSerializer food_xml = new XmlSerializer(typeof(Food));

            try
            {
                //xs.Serialize(fs, s);
                snake_xml.Serialize(snake_stream, Game.snake);
                walls_xml.Serialize(walls_stream, Game.walls);
                food_xml.Serialize(food_stream, Game.food);
                sl.WriteLine(level);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                food_stream.Close();
                walls_stream.Close();
                snake_stream.Close();
                sl.Close();
            }
            Environment.Exit(0);

        }
        public void GameResume()
        {

            FileStream snake_stream = new FileStream(@"C:\Users\User\Desktop\snake.xml", FileMode.Open, FileAccess.Read);
            FileStream walls_stream = new FileStream(@"C:\Users\User\Desktop\walls.xml", FileMode.Open, FileAccess.Read);
            FileStream food_stream = new FileStream(@"C:\Users\User\Desktop\food.xml", FileMode.Open, FileAccess.Read);

            StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\levelser.txt");


            XmlSerializer snake_xml = new XmlSerializer(typeof(Snake));
            XmlSerializer walls_xml = new XmlSerializer(typeof(Walls));
            XmlSerializer food_xml = new XmlSerializer(typeof(Food));

            try
            {

                Game.snake = snake_xml.Deserialize(snake_stream) as Snake;
                int n = int.Parse(sr.ReadLine());
                Game.walls = new Walls(n);
                Game.walls = walls_xml.Deserialize(walls_stream) as Walls;
                Game.food = food_xml.Deserialize(food_stream) as Food;


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

                sr.Close();
                snake_stream.Close();
                walls_stream.Close();
                food_stream.Close();
            }

        }

        public void GameInit()
        {
            Console.CursorVisible = false;
            Console.Clear();
            snake.Draw();//
            walls.Draw();//
            food.FoodGenerate();
            food.Draw();
        }//
        public void GameEnd()
        {
            GameLog();
            gameover = false;
        }
        public void GameLog()
        {
            char nl = '\n';
            text = string.Format("\nname: {0}, score: {1}", name, score);
            text += nl;
            StreamWriter sw = new StreamWriter(@"C:\Users\User\Desktop\log.txt", true);
            sw.WriteLine(text);
            sw.Close();
        }
    }
}