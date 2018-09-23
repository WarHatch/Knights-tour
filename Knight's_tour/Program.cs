using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Knights_tour
{
    class Program
    {
        private static readonly Random getrandom = new Random();

        static void Solve(Knight knight, Stopwatch watch)
        {
            //if (watch.IsRunning && knight.MoveLog.Count > 1000)
            //{
            //    watch.Stop();
            //    Console.WriteLine("1000 moves took: " + (watch.ElapsedMilliseconds).ToString());
            //    Console.ReadKey();
            //}

            string boardView = knight.Board.Print();
            Console.WriteLine(boardView);

            var goodDestinations = knight.GoodDestinations();
            while (goodDestinations.Count > 0)
            {
                int guessIndex = getrandom.Next(0, goodDestinations.Count);
                var randomCorrectDestination = goodDestinations[guessIndex];
                knight.MoveTo(randomCorrectDestination);
                goodDestinations.RemoveAt(guessIndex);

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
                knight.MoveLog.Add("End of solving: No more moves available");
            }
            return;
        }

        static void Main(string[] args)
        {
            var board = new Board(5, 5);
            var knight = new Knight(board, new Point(0, 0));

            Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();

            Solve(knight, watch);
        }
    }
}
