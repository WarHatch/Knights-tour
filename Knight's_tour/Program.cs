using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Knights_tour
{
    class Program
    {
        static Random rnd = new Random();

        static void Solve(Knight knight, Stopwatch watch, StringBuilder stringBuilder)
        {
            //// Benchmarking
            //if (watch.IsRunning && knight.MoveLog.Count > 100000)
            //{
            //    watch.Stop();
            //    Console.WriteLine("100000 moves took: " + (watch.ElapsedMilliseconds).ToString());
            //    Console.ReadKey();
            //}

            //// Board printing
            //string boardView = knight.Board.Print();
            //Console.WriteLine(boardView);

            Dictionary<int, Point> goodDestinations = knight.GoodDestinations(stringBuilder);
            while (goodDestinations.Count > 0)
            {
                // Manual Pop() of nextDestination
                var nextDestination = goodDestinations.First();
                goodDestinations.Remove(nextDestination.Key);

                // Random nextDestination
                //var chosenPath = rnd.Next(0, goodDestinations.Count);
                //var nextDestination = goodDestinations.ElementAt<Point>(chosenPath);
                //goodDestinations.RemoveAt(chosenPath);

                knight.MoveTo(nextDestination.Value, nextDestination.Key, stringBuilder);

                if (knight.Board.AllSpacesTaken())
                    return;

                Solve(knight, watch, stringBuilder);

                if (knight.Board.AllSpacesTaken())
                    return;
            }
            try
            {
                knight.Backtrack(stringBuilder);
            }
            catch (InvalidOperationException)
            {
                knight.MoveLog.Add("InvalidOperationException: Possibility that no more moves are available");
                Console.WriteLine(knight.MoveLog.Last());
            }
            return;
        }

        static void Main(string[] args)
        {
            Console.Write("Zirgo pozicija x: ");
            string posx = Console.ReadLine();
            int x = int.Parse(posx);

            Console.Write("Zirgo pozicija y: ");
            string posy = Console.ReadLine();
            int y = int.Parse(posy);

            Console.Write("Lentos dydis");
            string strSize = Console.ReadLine();
            int size = int.Parse(strSize);

            StringBuilder stringBuilder = new StringBuilder();

            var board = new Board(size, size);
            var knight = new Knight(board, new Point(x - 1, y - 1));

            Stopwatch watch = Stopwatch.StartNew();
            Solve(knight, watch, stringBuilder);
            if (!knight.Board.AllSpacesTaken()) Console.WriteLine("[X] Unable to find a solution.");
            else Console.WriteLine(knight.Board.Print());

            Console.WriteLine("Writing log to file... Please wait");
            System.IO.File.WriteAllText(@"C:\Users\Karolis\Desktop\KnightLog.txt", stringBuilder.ToString());
            Console.WriteLine("Completed writing log to file");
            Console.ReadKey();
        }
    }
}
