using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace snake
{
    public class Game
    {
        public List<GameObject> g_objects;
        public bool isAlive;
        public Snake snake;
        public Food food;
        public Wall wall;
        public Game()
        {
            g_objects = new List<GameObject>();
            snake = new Snake(10, 10, '*', ConsoleColor.Blue);
            food = new Food(2, 6, 'o', ConsoleColor.DarkCyan);
            //food.Generate();
            wall = new Wall('#', ConsoleColor.DarkGreen);
            wall.LoadLevel();

            while (food.IsCollissionWithObject(snake) || food.IsCollissionWithObject(wall))
            {
                food.Generate();
            }

            g_objects.Add(snake);
            g_objects.Add(food);
            g_objects.Add(wall);


            isAlive = true;
        }

        public void Start()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            Thread t = new Thread(MoveSnake);
            t.Start();

            while ( isAlive == true && keyInfo.Key != ConsoleKey.Escape)
            {
                keyInfo = Console.ReadKey();
                snake.Move();
                snake.CheckDirection(keyInfo);
                snake.CanYouMove(keyInfo);

            }
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("GAME OVER!!!");
            Console.ReadKey();
        }

        public void MoveSnake()
        {
            while (isAlive)
            {
                snake.Move();
                if (snake.IsCollissionWithObject(food))
                {
                    snake.body.Add(new Point(0, 0));
                    while(food.IsCollissionWithObject(snake) || food.IsCollissionWithObject(wall))
                    {
                        food.Generate();
                    }
                    if(snake.body.Count % 3 == 0)
                    {
                        wall.NextLevel();
                    }

                }
                if (snake.IsCollissionWithObject(wall))
                {
                    isAlive = false;
                }
                Draw();
                Thread.Sleep(100);
            }
        }

        public void Draw()
        {
            Console.Clear();
            foreach(GameObject g in g_objects)
            {
                g.Draw();
            }
        }
    }
}