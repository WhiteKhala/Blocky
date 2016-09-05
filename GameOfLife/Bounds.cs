using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GameOfLife
{
    public class Bounds
    {
        int mLeft;
        int mUp;
        int mRight;
        int mDown;
        public int Left
        {
            get
            {
                return mLeft;
            }
            set
            {
                mLeft = value;
            }
        }
        public int X
        {
            get
            {
                return mLeft;
            }
            set
            {
                mLeft = value;
            }
        }
        public int Up
        {
            get
            {
                return mUp;
            }
            set
            {
                mUp = value;
            }
        }
        public int Y
        {
            get
            {
                return mUp;
            }
            set
            {
                mUp = value;
            }
        }
        public int Right
        {
            get
            {
                return mRight;
            }
            set
            {
                mRight = value;
            }
        }
        public int Width
        {
            get
            {
                return mRight + 1 - Left;
            }
            set
            {
                mRight = value - 1 + Left;
            }
        }
        public int Bottom
        {
            get
            {
                return mDown;
            }
            set
            {
                mDown = value;
            }
        }
        public int Height
        {
            get
            {
                return mDown + 1 - mUp;
            }
            set
            {
                mDown = value - 1 + mUp;
            }
        }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(mLeft, mUp, mRight + 1, mDown + 1);
            }
            set
            {
                mLeft = value.X;
                mUp = value.Y;
                mRight = value.Width - 1 + value.X;
                mDown = value.Height - 1 + value.Y;
            }
        }
        public Bounds()
        {
        }
        public Bounds(int x, int y, int aWidth, int aHeight)
        {
            X = x;
            Y = y;
            Width = aWidth;
            Height = aHeight;
        }
        public static Bounds Lock(int left, int up, int right, int down)
        {
            return new Bounds()
            {
                mLeft = left,
                mUp = up,
                mRight = right,
                mDown = down
            };
        }
        public void Adjust(Cell cell)
        {
            if (cell.X < mLeft)
            {
                mLeft = cell.X;
            }
            if (cell.Y < mUp)
            {
                mUp = cell.Y;
            }
            if (cell.X > mRight)
            {
                mRight = cell.X;
            }
            if (cell.Y > mDown)
            {
                return;
            }
            mDown = cell.Y;
        }
        public void ResetVal()
        {
            mLeft = 0;
            mUp = 0;
            mRight = 0;
            mDown = 0;
        }
        public bool Contains(Cell cell)
        {
            return cell.X >= mLeft && cell.X <= mRight && (cell.Y >= mUp && cell.Y <= mDown);
        }
    }
}
