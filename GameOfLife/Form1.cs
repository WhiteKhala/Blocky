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
        public Form1()
        {
            InitializeComponent();
            mCount.Enabled = true;
            mCount.Interval = 30;
            mCount.Tick += Timer_Tick;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // NewGeneration

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

            //Gotta switch to floats
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
                
                // Do math as floats
                int width = graphicsPanel1.ClientSize.Width / mSpace.GetLength(0);
                int height = graphicsPanel1.ClientSize.Height / mSpace.GetLength(1);

                int x = e.X / width;
                int y = e.Y / height;
                if (mSpace[x, y] == false)
                {
                    mSpace[x, y] = !mSpace[x, y];
                    graphicsPanel1.Invalidate();
                    mCellCount++;
                }

                else if (mSpace[x, y] == true)
                {
                    mSpace[x, y] = !mSpace[x, y];
                    graphicsPanel1.Invalidate();
                    mCellCount--;
                }


                //Have to add a condition so that if you "unclick" a box cellcount is lowered

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
            MoveGeneration();

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
            //if (sender.Equals((object) fromTimeToolStripMenuItem1)
            //{
            //    seed = new Random().Next();

            //}
        }

        private void fromTimeToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void MoveGeneration()
        {
            mGenerations++;
            int mFamily = 0;
            int width = graphicsPanel1.ClientSize.Width / mSpace.GetLength(0);
            int height = graphicsPanel1.ClientSize.Height / mSpace.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int ii = 0; ii < height; ii++)
                {
                    if (mSpace[i, ii] == true)
                    {
                        //if (i - 1 < 0 || i + 1 > width || ii - 1 < 0 || ii + 1 > height)
                        //{
                        //    continue
                        //        this.left
                        //}

                        if (mSpace[i - 1, ii - 1] == true)
                        {
                            mFamily++;
                            continue;
                        }
                        else if (mSpace[i, ii - 1] == true)
                        {
                            mFamily++;
                            continue;
                        }
                        else if (mSpace[i + 1, ii - 1] == true)
                        {
                            mFamily++;
                            continue;
                        }
                        else if (mSpace[i - 1, ii] == true)
                        {
                            mFamily++;
                            continue;
                        }
                        else if (mSpace[i, ii] == true)
                        {
                            mFamily++;
                            continue;
                        }
                        else if (mSpace[i + 1, ii] == true)
                        {
                            mFamily++;
                            continue;
                        }
                        else if (mSpace[i - 1, ii + 1] == true)
                        {
                            mFamily++;
                            continue;
                        }
                        else if (mSpace[i, ii + 1] == true)
                        {
                            mFamily++;
                            continue;
                        }
                        else if (mSpace[i + 1, ii + 1] == true)
                        {
                            mFamily++;
                            continue;
                        }
                        //Rules to live by
                        if (mFamily < 2)
                        {
                            mSpace[i, ii] = false;
                            break;
                        }
                        else if (mFamily > 3)
                        {
                            mSpace[i, ii] = false;
                            break;
                        }
                        else if (mFamily == 2 || mFamily == 3)
                        {
                            break;
                        }
                    }

                    else if (mSpace[i, ii] == false)
                    {
                        if (mSpace[i - 1, ii - 1] == true)
                        {
                            mFamily++;
                            continue;
                        }
                        else if (mSpace[i, ii - 1] == true)
                        {
                            mFamily++;
                            continue;
                        }
                        else if (mSpace[i + 1, ii - 1] == true)
                        {
                            mFamily++;
                            continue;
                        }
                        else if (mSpace[i - 1, ii] == true)
                        {
                            mFamily++;
                            continue;
                        }
                        else if (mSpace[i, ii] == true)
                        {
                            mFamily++;
                            continue;
                        }
                        else if (mSpace[i + 1, ii] == true)
                        {
                            mFamily++;
                            continue;
                        }
                        else if (mSpace[i - 1, ii + 1] == true)
                        {
                            mFamily++;
                            continue;
                        }
                        else if (mSpace[i, ii + 1] == true)
                        {
                            mFamily++;
                            continue;
                        }
                        else if (mSpace[i + 1, ii + 1] == true)
                        {
                            mFamily++;
                            continue;
                        }
                        //This is supposed to make the NEXT generation live
                        if (mFamily == 3)
                        {
                            mSpace[i, ii] = true;
                        }
                        
                    }

                    mFamily = 0;
                }
            }
        }
    }
}
