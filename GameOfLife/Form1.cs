using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        bool[,] mSpace = new bool[25, 25];
        bool[,] nextSpace = new bool[25, 25];
        Timer mCount = new Timer();
        int mGenerations = 0;
        int mCellCount = 0;
        int mSeed = 0;
        int mNeighborCount = 0;
        public Form1()
        {
            InitializeComponent();
            mCount.Enabled = true;
            mCount.Interval = 30;
            mCount.Tick += Timer_Tick;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //mGenerations++;
            toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
                                           "      Seed: " + mSeed + "       Boundary: " /*+ mBoundary + */;


            graphicsPanel1.Invalidate();

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            Pen mEpipen = new Pen(Color.Black, 1);
            Brush mLiveCellBrush = new SolidBrush(Color.Green);

            int mWidth = graphicsPanel1.ClientSize.Width / mSpace.GetLength(0);
            int mHeight = graphicsPanel1.ClientSize.Height / mSpace.GetLength(1);

            
            for (int x = 0; x < mSpace.GetLength(0); x++)
            {
                for (int y = 0; y < mSpace.GetLength(1); y++)
                {
                    Rectangle mRectangle = Rectangle.Empty;
                    mRectangle.X = x * mWidth;
                    mRectangle.Y =  y * mHeight;
                    mRectangle.Width = mWidth;
                    mRectangle.Height = mHeight;

                    if (mSpace[x,y] == true)
                    {
                        e.Graphics.FillRectangle(mLiveCellBrush, mRectangle.X, mRectangle.Y, mRectangle.Width, mRectangle.Height);
                        
                    }

                    e.Graphics.DrawRectangle(mEpipen, mRectangle.X, mRectangle.Y, mRectangle.Width, mRectangle.Height);
                }
            }

            mEpipen.Dispose();
            mLiveCellBrush.Dispose();

            graphicsPanel1.Invalidate();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int width = graphicsPanel1.ClientSize.Width / mSpace.GetLength(0);
                int height = graphicsPanel1.ClientSize.Height / mSpace.GetLength(1);

                int x = e.X / width;
                int y = e.Y / height;
                if (mSpace[x, y] == false)
                {
                    mSpace[x, y] = true;
                    //mSpace[x, y] = !mSpace[x, y];
                    graphicsPanel1.Invalidate();
                    mCellCount++;
                }

                else if (mSpace[x, y] == true)
                {
                    mSpace[x, y] = false;
                    //mSpace[x, y] = !mSpace[x, y];
                    graphicsPanel1.Invalidate();
                    mCellCount--;
                }

            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 blg = new AboutBox1();
            blg.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripStatusLabelGen_Click(object sender, EventArgs e)
        {

        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            mGenerations++;
            CellLogic();
            graphicsPanel1.Invalidate();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 blg = new AboutBox1();
            blg.ShowDialog();
        }

        private void gridVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridVisibleToolStripMenuItem.Checked == true)
            {
                gridVisibleToolStripMenuItem.Checked = false;
            }

            else if (gridVisibleToolStripMenuItem.Checked == false)
            {
                gridVisibleToolStripMenuItem.Checked = true;
            }
        }

        private void headsUpVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (headsUpVisibleToolStripMenuItem.Checked == true)
            {
                headsUpVisibleToolStripMenuItem.Checked = false;
            }

            else if (headsUpVisibleToolStripMenuItem.Checked == false)
            {
                headsUpVisibleToolStripMenuItem.Checked = true;
            }
        }

        private void neighborCountVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (neighborCountVisibleToolStripMenuItem.Checked == true)
            {
                neighborCountVisibleToolStripMenuItem.Checked = false;
            }

            else if (neighborCountVisibleToolStripMenuItem.Checked == false)
            {
                neighborCountVisibleToolStripMenuItem.Checked = true;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void randomizeToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void fromTimeToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private int NeighborCellCheck()
        {
            int ArrayWidth = mSpace.GetLength(0);
            int ArrayHeight = mSpace.GetLength(1);

            int Count = 0;

            for (int row = 0; row < ArrayWidth; row++)
            {
                for (int column = 0; column < ArrayHeight; column++)
                {
                    int mFamily = 0;


                    if (//check all cells around)
                    {
                        Count++;
                    }

                    mNeighborCount = mFamily;
                }
            }
            return Count;

        }

        private void CellLogic()
        {
            int width = graphicsPanel1.ClientSize.Width / mSpace.GetLength(0);
            int height = graphicsPanel1.ClientSize.Height / mSpace.GetLength(1);

            bool IsAlive = false;
            int Count = NeighborCellCheck();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {

                    if (IsAlive && mNeighborCount < 2)
                    {
                        nextSpace[i, j] = false;
                    }
                    else if (IsAlive && mNeighborCount > 3)
                    {
                        nextSpace[i, j] = false;

                    }
                    else if (IsAlive && mNeighborCount == 2 || mNeighborCount == 3)
                    {
                        nextSpace[i, j] = true;

                    }
                    else if (!IsAlive && mNeighborCount == 3)
                    {
                        nextSpace[i, j] = true;
                    }
                }
            }

            mSpace = nextSpace;
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Array.Clear(mSpace, 0, mSpace.Length);
            Array.Clear(nextSpace, 0, nextSpace.Length);
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            Array.Clear(mSpace, 0, mSpace.Length);
            Array.Clear(nextSpace, 0, nextSpace.Length);
        }
    }
}
//Alive/Dead check
/*
 *                     for (int i = 0; i < width; i++)
                    {
                        if (i < 0 || i >= width)
                        {
                            continue;
                        }
                        for (int j = 0; j < height; j++)
                        {

                            if (mFamily < 2)
                            {
                                nextSpace[i, j] = false;
                            }
                            else if (mFamily > 3)
                            {
                                nextSpace[i, j] = false;

                            }
                            else if (mFamily == 2 || mFamily == 3)
                            {
                                nextSpace[i, j] = true;

                            }
                            else if (mFamily == 3)
                            {
                                nextSpace[i, j] = true;
                            }
                        }
                    }
//Past code to check/make alive dead
/*
 *             for (int i = width - 1; i < width + 2 ; i++)
            {
                for (int ii = height - 1; ii < height + 2; ii++)
                {
                    if (i < 0 || i >= width)
                    {
                        continue;
                    }

                    else if (ii < 0 || ii >= height)
                    {
                        continue;
                    }

                    else
                    {
                        if (mSpace[i, ii] == true)
                        {
                            if (i - 1 > -1 && ii - 1 > -1 && mSpace[i - 1, ii - 1] == true)
                            {
                                mFamily++;
                                continue;
                            }

                            else if (ii - 1 > -1 && mSpace[i, ii - 1] == true)
                            {
                                mFamily++;
                                continue;
                            }

                            else if (i + 1 <= width && ii - 1 > -1 && mSpace[i + 1, ii - 1] == true)
                            {
                                mFamily++;
                                continue;
                            }

                            else if (i - 1 > -1 && mSpace[i - 1, ii] == true)
                            {
                                mFamily++;
                                continue;
                            }

                            else if (i + 1 <= width && mSpace[i + 1, ii] == true)
                            {
                                mFamily++;
                                continue;
                            }

                            else if (i - 1 > -1 && ii + 1 <= height && mSpace[i - 1, ii + 1] == true)
                            {
                                mFamily++;
                                continue;
                            }

                            else if (ii + 1 <= height && mSpace[i, ii + 1] == true)
                            {
                                mFamily++;
                                continue;
                            }

                            else if (i + 1 <= width && ii + 1 <= height && mSpace[i + 1, ii + 1] == true)
                            {
                                mFamily++;
                                continue;
                            }

                            //Rules to live by
                            if (mFamily < 2)
                            {
                                nextSpace[i, ii] = false;
                                break;
                            }
                            else if (mFamily > 3)
                            {
                                nextSpace[i, ii] = false;
                                break;
                            }
                            else if (mFamily == 2 || mFamily == 3)
                            {
                                nextSpace[i, ii] = true;
                                break;
                            }
                        }

                        else if (mSpace[i, ii] == false)
                        {
                            if (i - 1 > -1 && ii - 1 > -1 && mSpace[i - 1, ii - 1] == true)
                            {
                                mFamily++;
                                continue;
                            }

                            else if (ii - 1 > -1 && mSpace[i, ii - 1] == true)
                            {
                                mFamily++;
                                continue;
                            }

                            else if (i + 1 <= width && ii - 1 > -1 && mSpace[i + 1, ii - 1] == true)
                            {
                                mFamily++;
                                continue;
                            }

                            else if (i - 1 > -1 && mSpace[i - 1, ii] == true)
                            {
                                mFamily++;
                                continue;
                            }

                            else if (i + 1 <= height && mSpace[i + 1, ii] == true)
                            {
                                mFamily++;
                                continue;
                            }

                            else if (i - 1 > -1 && ii + 1 <= height && mSpace[i - 1, ii + 1] == true)
                            {
                                mFamily++;
                                continue;
                            }

                            else if (ii + 1 <= height && mSpace[i, ii + 1] == true)
                            {
                                mFamily++;
                                continue;
                            }

                            if (i + 1 <= width && ii + 1 <= height && mSpace[i + 1, ii + 1] == true)
                            {
                                mFamily++;
                                continue;
                            }

                            //This is supposed to make the NEXT generation live
                            if (mFamily == 3)
                            {
                                nextSpace[i, ii] = true;
                                break;
                            }

                            else
                            {
                                break;
                            }

                        }
                    }

                    mFamily = 0;
                }
            }
*/
