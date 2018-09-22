using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knight_s_tour
{
    class Program
    {
        private static readonly Random getrandom = new Random();

        static void Solve(Knight knight)
        {

            var goodDestinations = knight.GoodDestinations();
            while (goodDestinations.Count > 0)
            {
                int guessIndex = getrandom.Next(0, goodDestinations.Count);
                var randomCorrectDestination = goodDestinations[guessIndex];
                knight.MoveTo(randomCorrectDestination);
                goodDestinations.RemoveAt(guessIndex);

                Solve(knight);
            }
            return;
        }

        static void Main(string[] args)
        {
            var board = new Board(4, 4);
            var knight = new Knight(board, new Point(0, 0));

            Solve(knight);
        }
    }
}
