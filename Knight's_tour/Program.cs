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

        static void Solve(Knight knight, Stopwatch watch)
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

            Dictionary<int, Point> goodDestinations = knight.GoodDestinations();
            while (goodDestinations.Count > 0)
            {
                // Manual Pop() of nextDestination
                var nextDestination = goodDestinations.First();
                goodDestinations.Remove(nextDestination.Key);

                // Random nextDestination
                //var chosenPath = rnd.Next(0, goodDestinations.Count);
                //var nextDestination = goodDestinations.ElementAt<Point>(chosenPath);
                //goodDestinations.RemoveAt(chosenPath);

                knight.MoveTo(nextDestination.Value, nextDestination.Key);

                if (knight.Board.AllSpacesTaken())
                    return;

                Solve(knight, watch);

                if (knight.Board.AllSpacesTaken())
                    return;
            }
            try
            {
                knight.Backtrack();
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
            var board = new Board(5, 5);
            var knight = new Knight(board, new Point(0, 0));

            Stopwatch watch = Stopwatch.StartNew();
            Solve(knight, watch);
            if (!knight.Board.AllSpacesTaken()) Console.WriteLine("[X] Unable to find a solution.");
            else Console.WriteLine(knight.Board.Print());
            Console.ReadKey();
        }
    }
}
