using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
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
        bool NeighborCountValid = true;

        public Form1()
        {
            InitializeComponent();
            timer.Enabled = false;
            timer.Interval = 100;
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
                    
                    //We're adding a number to see how many neighbors the current cell has
                    if (NeighborCellCheck(x, y) > 0 & NeighborCountValid == true)
                    {
                        if (NeighborCellCheck(x, y) == 3 || mSpace[x,y] == true && NeighborCellCheck(x, y) == 2)
                        {
                            Font font = new Font("Arial", 10);
                            Brush CellCountColor = new SolidBrush(Color.Green);
                            e.Graphics.DrawString(NeighborCellCheck(x, y).ToString(), font, CellCountColor, mRectangle.X, mRectangle.Y);
                        }

                        else
                        {
                            Font font = new Font("Arial", 10);
                            Brush CellCountColor = new SolidBrush(Color.Red);
                            e.Graphics.DrawString(NeighborCellCheck(x, y).ToString(), font, CellCountColor, mRectangle.X, mRectangle.Y);
                        }
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
            NeighborCountValid = !NeighborCountValid;
            neighborCountVisibleToolStripMenuItem.Checked = NeighborCountValid;

            graphicsPanel1.Invalidate();
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
            SettingsModalDialog dlg = new SettingsModalDialog();

            if (DialogResult.OK == dlg.ShowDialog())
            {
                
            }
        }
        //Below you'll find both saves, 1st 1 == dropdown menu item, 2nd 1 == icon click
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "All Files|*.*|Cells|*.cells";
                dlg.FilterIndex = 2; dlg.DefaultExt = "cells";


                if (DialogResult.OK == dlg.ShowDialog())
                {
                    StreamWriter writer = new StreamWriter(dlg.FileName);

                    // Write any comments you want to include first.
                    // Prefix all comment strings with an exclamation point.
                    // Use WriteLine to write the strings to the file. 
                    // It appends a CRLF for you.
                    writer.WriteLine("!Written on Emanuel Antablin's GameOfLife");

                    // Iterate through the universe one row at a time.
                    for (int y = 0; y < mSpace.GetLength(0); y++)
                    {
                        // Create a string to represent the current row.
                        String currentRow = string.Empty;

                        // Iterate through the current row one cell at a time.
                        for (int x = 0; x < mSpace.GetLength(1); x++)
                        {
                            if (mSpace[x, y] == true)
                            {
                                currentRow += 'O';
                            }
                            // If the universe[x,y] is alive then append 'O' (capital O)
                            // to the row string.
                            else if (mSpace[x, y] == false)
                            {
                                currentRow += '.';
                            }
                            // Else if the universe[x,y] is dead then append '.' (period)
                            // to the row string.
                        }

                        writer.WriteLine(currentRow);
                        // Once the current row has been read through and the 
                        // string constructed then write it to the file using WriteLine.
                    }

                    // After all rows and columns have been written then close the file.
                    writer.Close();
                }
            }
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2; dlg.DefaultExt = "cells";

            
            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);

                // Write any comments you want to include first.
                // Prefix all comment strings with an exclamation point.
                // Use WriteLine to write the strings to the file. 
                // It appends a CRLF for you.
                writer.WriteLine("!Written on Emanuel Antablin's GameOfLife");

                // Iterate through the universe one row at a time.
                for (int y = 0; y < mSpace.GetLength(0); y++)
                {
                    // Create a string to represent the current row.
                    String currentRow = string.Empty;

                    // Iterate through the current row one cell at a time.
                    for (int x = 0; x < mSpace.GetLength(1); x++)
                    {
                        if (mSpace[x,y] == true)
                        {
                            currentRow += 'O';
                        }
                        // If the universe[x,y] is alive then append 'O' (capital O)
                        // to the row string.
                        else if (mSpace[x,y] == false)
                        {
                            currentRow += '.';
                        }
                        // Else if the universe[x,y] is dead then append '.' (period)
                        // to the row string.
                    }

                    writer.WriteLine(currentRow);
                    // Once the current row has been read through and the 
                    // string constructed then write it to the file using WriteLine.
                }

                // After all rows and columns have been written then close the file.
                writer.Close();
            }
        }


        //Below you'll find both open's, 1st 1 == dropdown menu item, 2nd 1 == icon click
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);

                // Create a couple variables to calculate the width and height
                // of the data in the file.
                int maxWidth = 0;
                int maxHeight = 0;

                for (int i = 0; i < 0; i++)
                {

                }
                // Iterate through the file once to get its size.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then it is a comment
                    // and should be ignored.

                    // If the row is not a comment then it is a row of cells.
                    // Increment the maxHeight variable for each row read.

                    // Get the length of the current row string
                    // and adjust the maxWidth variable if necessary.
                }

                // Resize the current universe and scratchPad
                // to the width and height of the file calculated above.

                // Reset the file pointer back to the beginning of the file.
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                // Iterate through the file again, this time reading in the cells.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then
                    // it is a comment and should be ignored.

                    // If the row is not a comment then 
                    // it is a row of cells and needs to be iterated through.
                    for (int xPos = 0; xPos < row.Length; xPos++)
                    {
                        // If row[xPos] is a 'O' (capital O) then
                        // set the corresponding cell in the universe to alive.

                        // If row[xPos] is a '.' (period) then
                        // set the corresponding cell in the universe to dead.
                    }
                }

                // Close the file.
                reader.Close();
            }
        }
        private void openToolStripButton_Click(object sender, EventArgs e)
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
