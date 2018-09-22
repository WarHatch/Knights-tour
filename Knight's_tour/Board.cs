using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knight_s_tour
{
    public struct Board
    {
        public readonly int xSize;
        public readonly int ySize;
        public int[,] cells;

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

        public bool AllSpacesTaken()
        {
            for (int x = 0; x < cells.Length; x++)
            {
                for (int y = 0; y < cells.Length; y++)
                {
                    if (cells[x, y] == 0)
                        return false;
                }
            }
            return true;
        }

        public bool fitsOnBoard(int x, int y) => (x > -1 && x <= xSize && y > -1 && y <= ySize);
    }
}
