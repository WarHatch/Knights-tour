using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knights_tour
{
    public struct Board
    {
        public readonly int xSize;
        public readonly int ySize;
        private int[,] cells;

        public int[,] Cells { get => cells; }

        public Board(int xSize, int ySize)
        {
            this.xSize = xSize;
            this.ySize = ySize;
            this.cells = new int[ySize, xSize];
        }

        public void PlaceOn(Point newPosition, int value)
        {
            cells[newPosition.Y, newPosition.X] = value;
        }

        public void Empty(Point newPosition)
        {
            cells[newPosition.Y, newPosition.X] = 0;
        }

        public bool FitsOnBoard(int x, int y) => (x > -1 && x < xSize && y > -1 && y < ySize);

        public bool AllSpacesTaken()
        {
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    if (cells[y, x] == 0)
                        return false;
                }
            }
            return true;
        }

        public string Print()
        {
            StringBuilder board = new StringBuilder();

            for (int y = ySize; y > 0; y--)
            {
                board.AppendFormat("{0}|", y);
                for (int x = xSize; x > 0; x--)
                {
                    board.AppendFormat(cells[y-1, xSize-x].ToString().PadLeft(3));
                }
                board.AppendLine();
            }

            board.Append("Y|");
            for (int x = 0; x < xSize; x++)
            {
                board.Append("---");
            }
            board.AppendLine();

            board.Append(" X");
            for (int x = 1; x <= xSize; x++)
            {
                board.AppendFormat("  {0}", x);
            }
            return board.ToString();
        }
    }
}
