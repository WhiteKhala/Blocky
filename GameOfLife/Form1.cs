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
        int gWidth = 30, gHeight = 30;
        //Shove mwidth, height into both spaces
        bool[,] mSpace = new bool[30, 30];
        bool[,] nextSpace = new bool[30, 30];
        Timer timer = new Timer();
        //Timer runTo = new Timer();  Might use this
        int mGenerations = 0;
        int mCellCount = 0;
        int mSeed = 0;
        int mRunToGen = 0; //This will be for runtodialogbox
        int timerSpeed; //This will set the timer to runto's specifications
        bool HUD = true;
        bool mGrid = true;
       

        public Form1()
        {
            InitializeComponent();
            timer.Enabled = false;
            timer.Interval = 20;
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

            if (mCellCount == 0)
            {
                timer.Enabled = false;
            }

            //if (mGenerations == mRunToGen)
            //{
            //    timer.Enabled = false;
            //}
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {

            Pen mEpipen = new Pen(Color.Gray, 1);
            Brush mLiveCellBrush = new SolidBrush(Color.DarkGray);

            if (mGrid == false)
            {
                mEpipen.Color = Color.Empty;
            }

            //Gotta fix the float math
            float mWidth = graphicsPanel1.ClientSize.Width / mSpace.GetLength(0);
            float mHeight = graphicsPanel1.ClientSize.Height / mSpace.GetLength(1);


            for (int x = 0; x < mSpace.GetLength(0); x++)
            {
                for (int y = 0; y < mSpace.GetLength(1); y++)
                {
                    RectangleF mRectangle = RectangleF.Empty;

                    mRectangle.X = (float)x * mWidth;
                    mRectangle.Y = (float)y * mHeight;
                    mRectangle.Width = mWidth;
                    mRectangle.Height = mHeight;

                    if (mSpace[x, y] == true)
                    {
                        e.Graphics.FillRectangle(mLiveCellBrush, mRectangle.X, mRectangle.Y, mRectangle.Width, mRectangle.Height);

                    }

                    e.Graphics.DrawRectangle(mEpipen, mRectangle.X, mRectangle.Y, mRectangle.Width, mRectangle.Height);
                }
            }

            if (HUD)
            {
                Font font = new Font("Arial", 12);

                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Far;

                Rectangle shrekt = new Rectangle(0, graphicsPanel1.ClientSize.Height - 100, 300, 100);
                string hOut = "Generations: " + mGenerations.ToString() + "\n";
                hOut += "Cell Count: " + mCellCount + "\n";
                hOut += "Boundary Type: " + "\n"; //add + mBoundary
                hOut += "Universe Size: {Width =" + gWidth + ", Height=" + gHeight + "}";
                //mWidth and mHeight are showing numbers that aren't what I predefined

                e.Graphics.DrawString(hOut, font, Brushes.Blue, shrekt);
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
                    mSpace[x, y] = !mSpace[x, y];
                    CellCountCheck();
                    graphicsPanel1.Invalidate();
                    toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
                    "      Seed: " + mSeed + "       Boundary: " /*+ mBoundary + */;

                }

                else if (mSpace[x, y] == true)
                {
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
            mGrid = !mGrid;
            gridVisibleToolStripMenuItem.Checked = mGrid;

            graphicsPanel1.Invalidate();

        }

        private void headsUpVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HUD = !HUD;
            headsUpVisibleToolStripMenuItem.Checked = HUD;

            graphicsPanel1.Invalidate();
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

            //Timer fromTime = new Timer();    //How do we use timer's time to randomize? I know we get a number and mod it, but how?
            Random rand = new Random();
            for (int i = 0; i < mSpace.GetLength(0); i++)
            {
                for (int j = 0; j < mSpace.GetLength(1); j++)
                {
                    int x = rand.Next(0, 3);
                    if (x == 0)
                    {
                        nextSpace[i, j] = true;
                    }

                    else if (x == 1)
                    {
                        nextSpace[i, j] = false;
                    }

                    else if (x == 2)
                    {
                        nextSpace[i, j] = false;
                    }

                }
            }
            for (int i = 0; i < mSpace.GetLength(0); i++)
            {
                for (int j = 0; j < mSpace.GetLength(1); j++)
                {
                    mSpace[i, j] = nextSpace[i, j];
                }
            }

            CellCountCheck();
            toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
            "      Seed: " + mSeed + "       Boundary: " /*+ mBoundary + */;

            graphicsPanel1.Invalidate();
        }

        private int NeighborCellCheck(int x, int y)
        {
            int ArrayWidth = mSpace.GetLength(0);
            int ArrayHeight = mSpace.GetLength(1);

            int Count = 0;

            if (x != ArrayWidth - 1)
            {
                if (mSpace[x + 1, y] == true)
                    Count++;
            }

            if (x != ArrayWidth - 1 && y != ArrayHeight - 1)
            {
                if (mSpace[x + 1, y + 1] == true)
                {
                    Count++;
                }
            }

            if (y != ArrayHeight - 1)
            {
                if (mSpace[x, y + 1] == true)
                {
                    Count++;
                }
            }

            if (x != 0 && y != ArrayHeight - 1)
            {
                if (mSpace[x - 1, y + 1] == true)
                {
                    Count++;
                }
            }

            if (x != 0)
            {
                if (mSpace[x - 1, y] == true)
                {
                    Count++;
                }
            }

            if (x != 0 && y != 0)
            {
                if (mSpace[x - 1, y - 1] == true)
                {
                    Count++;
                }
            }

            if (y != 0)
            {
                if (mSpace[x, y - 1] == true)
                {
                    Count++;
                }
            }

            if (x != ArrayWidth - 1 && y != 0)
            {
                if (mSpace[x + 1, y - 1] == true)
                {
                    Count++;
                }
            }

            return Count;

        }

        private void CellLogic()
        {
            int width = mSpace.GetLength(0);
            int height = mSpace.GetLength(1);

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
            mGenerations = 0;
            Array.Clear(mSpace, 0, mSpace.Length);
            Array.Clear(nextSpace, 0, nextSpace.Length);
            CellCountCheck();
            toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
            "      Seed: " + mSeed + "       Boundary: " /*+ mBoundary + */;
            graphicsPanel1.Invalidate();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {

            mGenerations = 0;
            Array.Clear(mSpace, 0, mSpace.Length);
            Array.Clear(nextSpace, 0, nextSpace.Length);
            CellCountCheck();
            toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
            "      Seed: " + mSeed + "       Boundary: " /*+ mBoundary + */;
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

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //RunTo needs work
        private void runToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Run to will have a much faster interval than normal so that the user can just go to whichever position he wants
            //as fast as possible
            timer.Interval = 20;
            timer.Enabled = true;
        }
    }


}
