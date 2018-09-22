using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knight_s_tour
{
    class Knight
    {
        Stack<Point> moveStack;
        Board board;

        private readonly Point[] manuevers = {new Point(1, 2), new Point(2, 1), new Point(2, -1), new Point(1, -2),
            new Point(-1, -2), new Point(-2, -1), new Point(-2, 1), new Point(-1, 2) };

        public Knight(Board board, Point startingPosition)
        {
            this.board = board;
            moveStack = new Stack<Point>(board.xSize * board.ySize);
            MoveTo(startingPosition);
        }

        public Point CurrentPosition { get => moveStack.Peek(); }

        public void MoveTo(Point newPosition)
        {
            moveStack.Push(newPosition);
            board.PlaceOn(newPosition, moveStack.Count);
        }

        public List<Point> GoodDestinations()
        {
            List<Point> goodDestinations = new List<Point>();
            for (int i = 0; i < manuevers.Length; i++)
            {
                var potentialPos = CurrentPosition + manuevers[i];
                if (potentialPos.X > -1 && potentialPos.X <= board.xSize &&
                    potentialPos.Y > -1 && potentialPos.Y <= board.ySize)
                    if (board.cells[potentialPos.X, potentialPos.Y] != 0)
                        goodDestinations.Add(goodDestinations[i]);
                 
            }
            return goodDestinations;
        }
    }
}
