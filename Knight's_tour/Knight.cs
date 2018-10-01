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

            //MoveTo
            moveStack.Push(startingPosition);
            Board.PlaceOn(startingPosition, moveStack.Count);
        }

        public Point CurrentPosition { get => moveStack.Peek(); }
        public Board Board { get; }
        public List<string> MoveLog { get; } = new List<string>();

        private string NewLogMargin(int amount) => new string('-', moveStack.Count);

        public void MoveTo(Point newPosition, int manueverIndex, StringBuilder stringBuilder)
        {
            string appendix = "Laisva. LENTA" + newPosition + ":=" + moveStack.Count;
            MoveLog.Add(CreateLog(newPosition, manueverIndex, appendix));
            //Console.WriteLine(MoveLog.Last());
            stringBuilder.AppendLine(MoveLog.Last());

            moveStack.Push(newPosition);
            Board.PlaceOn(newPosition, moveStack.Count);
        }

        public void Backtrack(StringBuilder stringBuilder)
        {
            //MoveLog.Add(MoveLog.Count.ToString().PadRight(7) + NewLogMargin(moveStack.Count) +
            //    "L= " + (moveStack.Count) + " nebeturi tolesniu zingsniu. Backtrack.");
            //Console.WriteLine("".PadRight(7) + NewLogMargin(moveStack.Count) +
            //    "L= " + (moveStack.Count) + " nebeturi tolesniu zingsniu. Backtrack.");
            stringBuilder.AppendLine("".PadRight(7) + NewLogMargin(moveStack.Count) +
                "L= " + (moveStack.Count) + " nebeturi tolesniu zingsniu. Backtrack.");

            var falsePosition = moveStack.Pop();
            Board.Empty(falsePosition);
        }

        private string CreateLog(Point newPosition, int manueverIndex, string appendix)
        {
            return MoveLog.Count.ToString().PadRight(7)
                + NewLogMargin(moveStack.Count) + "R" + (manueverIndex+1) + ". "
                + newPosition + ". L= " + moveStack.Count  + ". "
                + appendix;
        }

        public Dictionary<int, Point> GoodDestinations(StringBuilder stringBuilder)
        {
            Dictionary<int, Point> goodDestinations = new Dictionary<int, Point>();

            for (int manueverIndex = 0; manueverIndex < manuevers.Length; manueverIndex++)
            {
                var potentialPos = CurrentPosition + manuevers[manueverIndex];
                if (Board.FitsOnBoard(potentialPos.X, potentialPos.Y))
                {
                    if (Board.Cells[potentialPos.Y, potentialPos.X] == 0)
                    {
                        //int priority = WarnsdorfsRuleMoves(potentialPos);
                        //goodDestinations.Add(potentialPos, priority);
                        goodDestinations.Add(manueverIndex, potentialPos);
                    }
                    else
                    {
                        FakeMove(potentialPos, manueverIndex, "Siulas.", stringBuilder);
                    }
                }
                else
                {
                    FakeMove(potentialPos, manueverIndex, "Uz krasto.", stringBuilder);
                }
            }

            return goodDestinations;
        }

        private void FakeMove(Point newPosition, int manueverIndex, string logAppendix, StringBuilder stringBuilder)
        {
            MoveLog.Add(
                MoveLog.Count.ToString().PadRight(7)
                + NewLogMargin(moveStack.Count) + "R" + (manueverIndex + 1) + ". "
                + newPosition.ToString() + ". L= " + moveStack.Count + ". "
                + logAppendix
            );
            //Console.WriteLine(MoveLog.Last());
            stringBuilder.AppendLine(MoveLog.Last());
        }
    }
}
