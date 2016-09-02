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
        Timer mCount = new Timer();
        int mGenerations = 0;
        int mCellCount = 0;
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
                                           "      Seed: " /* + mSeed */+ "       Boundary: " /*+ mBoundary + */;


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

                mSpace[x, y] = !mSpace[x, y];

                graphicsPanel1.Invalidate();
                mCellCount++;
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

        }
    }
}
