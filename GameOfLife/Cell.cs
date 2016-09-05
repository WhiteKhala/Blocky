using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GameOfLife
{
    public struct Cell
    {
        private int x;
        private int y;
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }
        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }
        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Cell[] Family()
        {
            return new Cell[8]
            {
                new Cell(x - 1, y - 1),
                new Cell(x - 1, y),
                new Cell(x - 1, y + 1),
                new Cell(x, y - 1),
                new Cell(x, y + 1),
                new Cell(x + 1, y - 1),
                new Cell(x + 1, y),
                new Cell(x + 1, y + 1)
            };
        }
        public Cell[] Fam(Bounds boundary)
        {
            Cell[] nArray = new Cell[8];
            int x1;
            if (x > 0)
            {
                x1 = x - 1;
            }
            else
            {
                x1 = boundary.Right;
            }
            int y1;
            if (y > 0)
            {
                y1 = y - 1;
            }
            else
            {
                y1 = boundary.Bottom;
            }
            nArray[0] = new Cell(x1, y1);
            int x2 = x;
            nArray[1] = new Cell(x2, y1);
            int x3;
            if (x < boundary.Right)
            {
                x3 = x + 1;
            }
            else
            {
                x3 = 0;
            }
            nArray[2] = new Cell(x3, y1);
            int x4;
            if (x > 0)
            {
                x4 = x - 1;
            }
            else
            {
                x4 = boundary.Right;
            }
            int y2 = y;
            nArray[3] = new Cell(x4, y2);
            int x5;
            if (x < boundary.Right)
            {
                x5 = x + 1;
            }
            else
            {
                x5 = 0;
            }
            nArray[4] = new Cell(x5, y2);
            int x6;
            if (x > 0)
            {
                x6 = x - 1;
            }
            else
            {
                x6 = boundary.Right;
            }
            int y3;
            if (y < boundary.Bottom)
            {
                y3 = y + 1;
            }
            else
            {
                y3 = 0;
            }
            nArray[5] = new Cell(x6, y3);
            int x7 = x;
            nArray[6] = new Cell(x7, y3);
            int x8;
            if (x < boundary.Right)
            {
                x8 = x + 1;
            }
            else
            {
                x8 = 0;
            }
            nArray[7] = new Cell(x8, y3);
            return nArray;
        }
        public override int GetHashCode()
        {
            return x * 37 + y;
        }
    }
}
