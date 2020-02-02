using System;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static GameOfLifeSession session = new GameOfLifeSession(20, 20);

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Console.ReadKey();

            RandomFillGrid(session);

            while (true)
            {
                Draw(session);
                session.CalculateNextGeneration();
            }
        }

        public static void Draw(GameOfLifeSession session)
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < session.Height; i++)
            {
                for (int j = 0; j < session.Width; j++)
                {
                    if (session[i, j] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("■■ ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("■■ ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                Console.WriteLine();
            }
        }

        static void RandomFillGrid(GameOfLifeSession session)
        {
            Random random = new Random();

            for (int y = 0; y < session.Height; y++)
            {
                for (int x = 0; x < session.Width; x++)
                {
                    if (random.Next(0, 2) == 0)
                    {
                        session[y, x] = false;
                    }
                    else
                    {
                        session[y, x] = true;
                    }
                }
            }
        }
    }
}
