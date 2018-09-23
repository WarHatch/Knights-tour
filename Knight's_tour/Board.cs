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
            this.cells = new int[xSize, ySize];
        }

        public void PlaceOn(Point newPosition, int value)
        {
            cells[newPosition.X, newPosition.Y] = value;
        }

        public void Empty(Point newPosition)
        {
            cells[newPosition.X, newPosition.Y] = 0;
        }

        public bool FitsOnBoard(int x, int y) => (x > -1 && x < xSize && y > -1 && y < ySize);

        public bool AllSpacesTaken()
        {
            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    if (cells[x, y] == 0)
                        return false;
                }
            }
            return true;
        }

        public string Print()
        {
            StringBuilder board = new StringBuilder(" Y");

            for (int y = 0; y < ySize; y++)
            {
                board.AppendFormat("  {0}", y);
            }
            board.Append("\nX|");
            for (int y = 0; y < ySize; y++)
            {
                board.Append("---");
            }
            board.AppendLine();

            for (int x = 0; x < xSize; x++)
            {
                board.AppendFormat("{0}|", x);
                for (int y = 0; y < ySize; y++)
                {
                    board.AppendFormat(cells[x, y].ToString().PadLeft(3));
                }
                board.AppendLine();
            }
            return board.ToString();
        }
    }
}
