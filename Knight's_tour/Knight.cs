using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knights_tour
{
    class Knight
    {
        private Stack<Point> moveStack;
        private readonly Point[] manuevers = {new Point(1, 2), new Point(2, 1), new Point(2, -1), new Point(1, -2),
            new Point(-1, -2), new Point(-2, -1), new Point(-2, 1), new Point(-1, 2) };

        public Knight(Board board, Point startingPosition)
        {
            Board = board;
            moveStack = new Stack<Point>(board.xSize * board.ySize);
            MoveTo(startingPosition);
        }

        public Point CurrentPosition { get => moveStack.Peek(); }
        public Board Board { get; }
        public List<string> MoveLog { get; } = new List<string>();

        public void MoveTo(Point newPosition)
        {
            moveStack.Push(newPosition);
            Board.PlaceOn(newPosition, moveStack.Count);
            MoveLog.Add("Move #" + moveStack.Count + " to " + newPosition);
        }

        public void Backtrack(){
            var falsePosition = moveStack.Pop();
            Board.Empty(falsePosition);
            MoveLog.Add("Backtracking to move #" + moveStack.Count + " on " + moveStack.Peek());
        }

        public List<Point> GoodDestinations()
        {
            List<Point> goodDestinations = new List<Point>();
            for (int i = 0; i < manuevers.Length; i++)
            {
                var potentialPos = CurrentPosition + manuevers[i];
                if (Board.FitsOnBoard(potentialPos.X, potentialPos.Y))
                    if (Board.Cells[potentialPos.X, potentialPos.Y] == 0)
                        goodDestinations.Add(potentialPos);
                 
            }
            return goodDestinations;
        }
    }
}
