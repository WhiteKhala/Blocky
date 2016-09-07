using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// You've gotta make cellcount work properly, as it stands if you throw rand it won't add anything up, ONLY IF YOU CLICK THEM DOES IT WORK.
namespace GameOfLife
{
    public partial class Form1 : Form
    {
        bool[,] mSpace = new bool[25, 25];
        bool[,] nextSpace = new bool[25, 25];
        Timer timer = new Timer();
        int mGenerations = 0;
        int mCellCount = 0;
        int mSeed = 0;

        public Form1()
        {
            InitializeComponent();

            timer.Enabled = false;
            timer.Interval = 250;
            timer.Tick += Timer_Tick;
            CellCountCheck();
            toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
                   "      Seed: " + mSeed + "       Boundary: " /*+ mBoundary + */;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            mGenerations++;
            CellLogic();
            CellCountCheck();
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
                    //mSpace[x, y] = true;
                    mSpace[x, y] = !mSpace[x, y];
                    CellCountCheck();
                    graphicsPanel1.Invalidate();
                    toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
                    "      Seed: " + mSeed + "       Boundary: " /*+ mBoundary + */;

                }

                else if (mSpace[x, y] == true)
                {
                    //mSpace[x, y] = false;
                    mSpace[x, y] = !mSpace[x, y];
                    CellCountCheck();
                    graphicsPanel1.Invalidate();
                    toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
                    "      Seed: " + mSeed + "       Boundary: " /*+ mBoundary + */;
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
            timer.Enabled = true;
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
            Array.Clear(mSpace, 0, mSpace.Length);
            Array.Clear(nextSpace, 0, nextSpace.Length);

            Timer fromTime = new Timer();
            Random rand = new Random();
            for (int i = 0; i < mSpace.GetLength(0); i++)
            {
                for (int j = 0; j < mSpace.GetLength(1); j++)
                {
                    int x = rand.Next(0, 2);
                    if (x == 0)
                    {
                        mSpace[i, j] = true;
                    }
                    
                    else if (x == 1)
                    {
                        mSpace[i, j] = false;
                    }

                    else if (x == 2)
                    {
                        mSpace[i, j] = false;
                    }
                }
            }
            CellCountCheck();
            graphicsPanel1.Invalidate();
        }

        private int NeighborCellCheck(int x, int y)
        {
            int ArrayWidth = mSpace.GetLength(0);
            int ArrayHeight = mSpace.GetLength(1);

            int Count = 0;

            if (x != ArrayWidth - 1)
            {
                if (mSpace[x+1, y] == true)
                Count++;
            }

            if (x != ArrayWidth - 1 && y != ArrayHeight - 1)
            {
                if (mSpace[x+1, y+1] == true)
                {
                    Count++;
                }
            }

            if (y != ArrayHeight - 1)
            {
                if (mSpace[x, y+1] == true)
                {
                    Count++;
                }
            }

            if (x != 0 && y != ArrayHeight - 1)
            {
                if (mSpace[x-1,y+1] == true)
                {
                    Count++;
                }
            }

            if (x != 0)
            {
                if (mSpace[x-1,y] == true)
                {
                    Count++;
                }
            }

            if (x != 0 && y != 0)
            {
                if (mSpace[x -1, y -1] == true)
                {
                    Count++;
                }
            }

            if (y != 0)
            {
                if (mSpace[x, y-1] == true)
                {
                    Count++;
                }
            }

            if (x != ArrayWidth - 1 && y != 0)
            {
                if (mSpace[x+1,y-1] == true)
                {
                    Count++;
                }
            }

            return Count;

        }

        private void CellLogic()
        {
            int width = graphicsPanel1.ClientSize.Width / mSpace.GetLength(0);
            int height = graphicsPanel1.ClientSize.Height / mSpace.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    bool IsAlive = mSpace[i, j];
                    int Count = NeighborCellCheck(i, j);
                    bool results = false;

                    if (IsAlive && Count < 2)
                    {
                        results = false;
                        
                    }
                    else if (IsAlive && Count > 3)
                    {
                        results = false;
                        

                    }
                    else if (IsAlive && Count == 2 || Count == 3)
                    {
                        results = true;
                        

                    }
                    else if (!IsAlive && Count == 3)
                    {
                        results = true;
                        
                    }
                    nextSpace[i, j] = results;
                }
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    mSpace[x, y] = nextSpace[x, y];
                }
            }

        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CellCountCheck();
            mGenerations = 0;
            Array.Clear(mSpace, 0, mSpace.Length);
            Array.Clear(nextSpace, 0, nextSpace.Length);
            graphicsPanel1.Invalidate();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            CellCountCheck();
            mGenerations = 0;
            Array.Clear(mSpace, 0, mSpace.Length);
            Array.Clear(nextSpace, 0, nextSpace.Length);
            graphicsPanel1.Invalidate();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            mGenerations++;
            CellLogic();
            CellCountCheck();
            graphicsPanel1.Invalidate();

            toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
                   "      Seed: " + mSeed + "       Boundary: " /*+ mBoundary + */;

        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mGenerations++;
            CellLogic();
            CellCountCheck();
            graphicsPanel1.Invalidate();

            toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
                   "      Seed: " + mSeed + "       Boundary: " /*+ mBoundary + */;

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        public void CellCountCheck()
        {
            mCellCount = 0;
            for (int i = 0; i < mSpace.GetLength(0); i++)
            {
                for (int j = 0; j < mSpace.GetLength(1); j++)
                {
                    if (mSpace[i, j] == true)
                    {
                        mCellCount++;
                    }

                }
            }
        }
    }


}
