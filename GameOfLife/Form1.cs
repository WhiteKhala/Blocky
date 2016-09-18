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

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        int gWidth = 30, gHeight = 30;
        //Shove mwidth, height into both spaces
        bool[,] mSpace, nextSpace;
        Timer timer = new Timer();
        //Timer runTo = new Timer();  Might use this
        int mGenerations = 0;
        int mCellCount = 0;
        int mSeed = 0;
        int mRunToGen; //This will be for runtodialogbox
        int timerSpeed = 100; //This will set the timer to runto's specifications
        bool HUD = true;
        bool mGrid = true;
        bool NeighborCountValid = true;
        Random RandomStartSeed = new Random();
        Color GridColor = Color.Gray;
        Color Gridx10Color = Color.Black;
        Color AliveCellColor = Color.DarkGray;
        Color BackGroundColor = Color.White;
        string BoundaryType = "Finite";
        public Form1()
        {
            mSpace = new bool[gWidth, gHeight];
            nextSpace = new bool[gWidth, gHeight];
            InitializeComponent();
            timer.Enabled = false;
            timer.Interval = timerSpeed;
            timer.Tick += Timer_Tick;
            mSeed = RandomStartSeed.Next();
            CellCountCheck();
            toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
                   "      Seed: " + mSeed + "       Boundary: " + BoundaryType;
        }

        //This resets our universe every tick of our timer
        private void Timer_Tick(object sender, EventArgs e)
        {
            mGenerations++;
            CellLogic();
            CellCountCheck();
            toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
                               "      Seed: " + mSeed + "       Boundary: " + BoundaryType;
            graphicsPanel1.Invalidate();

            if (mCellCount == 0)
            {
                timer.Enabled = false;
            }

            //WORK this is the runTo function
            if (mGenerations == mRunToGen)
            {
                timer.Enabled = false;
                timer.Interval = timerSpeed;
            }
        }

        //WORK what is this?
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //WORK This will do all the graphics inside of our panel, the MOST essential part of project
        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {

            Pen mEpipen = new Pen(GridColor, 1);
            Pen Gridx10 = new Pen(Gridx10Color, 2); //Have to install x10 grid
            Brush mLiveCellBrush = new SolidBrush(AliveCellColor);
            graphicsPanel1.BackColor = BackGroundColor; 

            if (mGrid == false)
            {
                mEpipen.Color = Color.Empty;
                Gridx10.Color = Color.Empty;
            }
            
            //WORK Gotta fix the float math
            float mWidth = graphicsPanel1.ClientSize.Width / Convert.ToSingle(mSpace.GetLength(0));
            float mHeight = graphicsPanel1.ClientSize.Height / Convert.ToSingle(mSpace.GetLength(1));

            //WORK Creating our cell rectangles //Make ints into floats!
            for (int x = 0; x < mSpace.GetLength(0); x++)
            {
                for (int y = 0; y < mSpace.GetLength(1); y++)
                {
                    RectangleF mRectangle = RectangleF.Empty;

                    mRectangle.X = (float)(x * mWidth);
                    mRectangle.Y = (float)(y * mHeight);
                    mRectangle.Width = mWidth;
                    mRectangle.Height = mHeight;

                    if (mSpace[x, y] == true)
                    {
                        e.Graphics.FillRectangle(mLiveCellBrush, mRectangle.X, mRectangle.Y, mRectangle.Width, mRectangle.Height);

                    }
                    

                    //We're adding a number to see how many neighbors the current cell has
                    if (NeighborCellCheck(x, y) > 0 & NeighborCountValid == true)
                    {
                        if (NeighborCellCheck(x, y) == 3 || mSpace[x, y] == true && NeighborCellCheck(x, y) == 2)
                        {
                            Font font = new Font("Arial", 10);
                            Brush CellCountColor = new SolidBrush(Color.Green);
                            e.Graphics.DrawString(" " + NeighborCellCheck(x, y).ToString(), font, CellCountColor, mRectangle.X, mRectangle.Y);
                        }

                        else
                        {
                            Font font = new Font("Arial", 10);
                            Brush CellCountColor = new SolidBrush(Color.Red);
                            e.Graphics.DrawString(" " + NeighborCellCheck(x, y).ToString(), font, CellCountColor, mRectangle.X, mRectangle.Y);
                        }
                    }
                    //Work on grid x 10 lines

                    e.Graphics.DrawRectangle(mEpipen, mRectangle.X, mRectangle.Y, mRectangle.Width, mRectangle.Height);

                    //if (HUD)
                    //{
                    //    int GridWidth = graphicsPanel1.ClientSize.Width;
                    //    int GridHeight = graphicsPanel1.ClientSize.Height;
                    //    for (int i = 0; x < GridWidth; i++)
                    //    {
                    //        for (int j = 0; j < GridHeight; j += 10)
                    //        {
                    //            if (i == 10)
                    //            {
                    //                e.Graphics.DrawLine(Gridx10, mRectangle.X, 0, mRectangle.X, 0);
                    //                continue;
                    //            }

                    //            if (j == 10)
                    //            {
                    //                e.Graphics.DrawLine(Gridx10, 0, j, 0, GridHeight);
                    //                continue;
                    //            }
                    //        }
                    //    }
                    //}
                }
            }





            if (HUD)
            {
                Font font = new Font("Arial", 12);

                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Far;

                Rectangle shrekt = new Rectangle(0, graphicsPanel1.ClientSize.Height - 73, 300, 100);
                string hOut = "Generations: " + mGenerations.ToString() + "\n";
                hOut += "Cell Count: " + mCellCount + "\n";
                hOut += "Boundary Type: " + BoundaryType + "\n"; 
                hOut += "Universe Size: {Width =" + gWidth + ", Height=" + gHeight + "}";

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
                float width = graphicsPanel1.ClientSize.Width / Convert.ToSingle(mSpace.GetLength(0));
                float height = graphicsPanel1.ClientSize.Height / Convert.ToSingle(mSpace.GetLength(1));

                int x = (int)(e.X / width);
                int y = (int)(e.Y / height);
                if (mSpace[x, y] == false)
                {
                    mSpace[x, y] = !mSpace[x, y];
                    CellCountCheck();
                    graphicsPanel1.Invalidate();
                    toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
                    "      Seed: " + mSeed + "       Boundary: " + BoundaryType;

                }

                else if (mSpace[x, y] == true)
                {
                    mSpace[x, y] = !mSpace[x, y];
                    CellCountCheck();
                    graphicsPanel1.Invalidate();
                    toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
                    "      Seed: " + mSeed + "       Boundary: " + BoundaryType;
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

        //WORK Unsure about this method, once I work on it, we'll see
        private void toolStripStatusLabelGen_Click(object sender, EventArgs e)
        {

        }

        //WORK This will be our dropdown import utility, needs to be worked on
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //This will show whoever clicks on it, the developer and his contact info
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 blg = new AboutBox1();
            blg.ShowDialog();
        }

        //Enables/disables the visibility of our grid (where the cells live)
        private void gridVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mGrid = !mGrid;
            gridVisibleToolStripMenuItem.Checked = mGrid;

            graphicsPanel1.Invalidate();

        }
        //Enables/disables a bigger representation of useful information
        private void headsUpVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HUD = !HUD;
            headsUpVisibleToolStripMenuItem.Checked = HUD;

            graphicsPanel1.Invalidate();
        }
        //Activates/deactivates the count of how many neighbors every cell has
        private void neighborCountVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NeighborCountValid = !NeighborCountValid;
            neighborCountVisibleToolStripMenuItem.Checked = NeighborCountValid;

            graphicsPanel1.Invalidate();
        }

        //WORK Unsure for now gotta check with this one does once I give it something
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //WORK Random needs work
        private void randomizeToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        //Randomizes the universe with our current seed
        private void FromCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Array.Clear(mSpace, 0, mSpace.Length);
            Array.Clear(nextSpace, 0, nextSpace.Length);
            Random rand = new Random(mSeed);
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

            mGenerations = 0;
            CellCountCheck();
            toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
            "      Seed: " + mSeed + "       Boundary: " + BoundaryType;

            graphicsPanel1.Invalidate();
        }

        //Randomizes the universe with a random or user-set seed
        private void fromNewSeedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Array.Clear(mSpace, 0, mSpace.Length);
            Array.Clear(nextSpace, 0, nextSpace.Length);

            SeedDialog dlg = new SeedDialog();
            dlg.ShowDialog();
            mSeed = dlg.GetRandomNumber();

            Array.Clear(mSpace, 0, mSpace.Length);
            Array.Clear(nextSpace, 0, nextSpace.Length);
            Random rand = new Random(mSeed);
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

            mGenerations = 0;
            CellCountCheck();
            CellCountCheck();
            toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
            "      Seed: " + mSeed + "       Boundary: " + BoundaryType;

            graphicsPanel1.Invalidate();
        }

        //Randomizes our universe
        private void fromTimeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Array.Clear(mSpace, 0, mSpace.Length);
            Array.Clear(nextSpace, 0, nextSpace.Length);

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

            mGenerations = 0;

            CellCountCheck();
            toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
            "      Seed: " + mSeed + "       Boundary: " + BoundaryType;

            graphicsPanel1.Invalidate();
        }

        //Cell neighbor check, this will check and return the number of neighbors a cell has (0 - 8)
        private int NeighborCellCheck(int x, int y)
        {
            int ArrayWidth = mSpace.GetLength(0);
            int ArrayHeight = mSpace.GetLength(1);

            int Count = 0;
            if (BoundaryType == "Finite") // Finite Boundary
            {
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
            }

            else if (BoundaryType == "Toroidal") //Toroidal boundary
            {
                if (x != ArrayWidth - 1 && y != 0)
                {
                    if (mSpace[x + 1, y - 1])
                        Count++;
                }
                else if (x == ArrayWidth - 1 && y != 0)
                {
                    if (mSpace[0, y - 1])
                        Count++;
                }

                if (x != ArrayWidth - 1)
                {
                    if (mSpace[x + 1, y])
                        Count++;
                }
                else if (x == ArrayWidth - 1)
                {
                    if (mSpace[0, y])
                        Count++;
                }

                if (x != ArrayWidth - 1 && y != ArrayHeight - 1)
                {
                    if (mSpace[x + 1, y + 1])
                        Count++;
                }
                else if (x == ArrayWidth - 1 && y != ArrayHeight - 1)
                {
                    if (mSpace[0, y + 1])
                        Count++;
                }

                if (y != ArrayHeight - 1)
                {
                    if (mSpace[x, y + 1])
                        Count++;
                }
                else if (y == ArrayHeight - 1 && x != 0 && x != ArrayWidth - 1)
                {
                    if (mSpace[x, 0])
                        Count++;
                    if (mSpace[x + 1, 0])
                        Count++;
                    if (mSpace[x - 1, 0])
                        Count++;
                }

                if (x != 0 && y != ArrayHeight - 1)
                {
                    if (mSpace[x - 1, y + 1])
                        Count++;
                }
                else if (x == 0 && y != ArrayHeight - 1)
                {
                    if (mSpace[ArrayHeight - 1, y + 1])
                        Count++;
                }

                if (x != 0)
                {
                    if (mSpace[x - 1, y])
                        Count++;
                }
                else if (x == 0)
                {
                    if (mSpace[ArrayWidth - 1, y])
                        Count++;
                }

                if (x != 0 && y != 0)
                {
                    if (mSpace[x - 1, y - 1])
                        Count++;
                }
                else if (x == 0 && y != 0)
                {
                    if (mSpace[ArrayWidth - 1, y - 1])
                        Count++;
                }

                if (y != 0)
                {
                    if (mSpace[x, y - 1])
                        Count++;
                }
                else if (y == 0 && x != 0 && x != ArrayWidth - 1)
                {
                    if (mSpace[x, ArrayHeight - 1])
                        Count++;
                    if (mSpace[x + 1, ArrayHeight - 1])
                        Count++;
                    if (mSpace[x - 1, ArrayHeight - 1])
                        Count++;
                }
            }
        
            return Count;
        }

        //Cell life/death logic (if it'll survive next gen or not)
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

        //This method will read all alive cells inside of your current universe
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mGenerations = 0;
            Array.Clear(mSpace, 0, mSpace.Length);
            Array.Clear(nextSpace, 0, nextSpace.Length);
            CellCountCheck();
            toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
            "      Seed: " + mSeed + "       Boundary: " + BoundaryType;
            graphicsPanel1.Invalidate();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {

            mGenerations = 0;
            Array.Clear(mSpace, 0, mSpace.Length);
            Array.Clear(nextSpace, 0, nextSpace.Length);
            CellCountCheck();
            toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
            "      Seed: " + mSeed + "       Boundary: " + BoundaryType;
            graphicsPanel1.Invalidate();
        }

        private void NextToolStripButton_Click(object sender, EventArgs e)
        {
            mGenerations++;
            CellLogic();
            CellCountCheck();
            graphicsPanel1.Invalidate();

            toolStripStatusLabelGen.Text = "Generations: " + mGenerations.ToString() + "    Cells: " + mCellCount +
                   "      Seed: " + mSeed + "       Boundary: " + BoundaryType;

        }

        //This is the pause button
        private void PauseToolStripButton_Click(object sender, EventArgs e)
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
                   "      Seed: " + mSeed + "       Boundary: " + BoundaryType;

        }

        //Menu start option
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;

        }



        //Button start option
        private void StartToolStripButton_Click_1(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        //Menu pause option
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        //Button pause option
        private void PauseToolStripButton_Click_1(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        //RunTo option
        private void runToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunTo dlg = new RunTo();
            dlg.ShowDialog();
            mRunToGen = dlg.GetRunToInt();
            timer.Interval = 20;
            timer.Enabled = true;
        }

        //WORK This will be the settings ModalDialog Panel
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsModalDialog dlg = new SettingsModalDialog();
            dlg.SetBGColor(BackGroundColor);
            dlg.SetGridColor(GridColor);
            dlg.SetGx10Color(Gridx10Color);
            dlg.SetLiveCellColor(AliveCellColor);
            dlg.SetTimerInterval(timerSpeed);
            dlg.SetUWidth(gWidth);
            dlg.SetUHeight(gHeight);
            if (BoundaryType == "Finite")
            {
                dlg.SetisFinite(true);
            }
            else if (BoundaryType == "Toroidal")
            {
                dlg.SetisToroidal(true);
            }

            dlg.ShowDialog();
            if (dlg.GetChoice() == true)
            {
                Array.Clear(mSpace, 0, mSpace.Length);
                Array.Clear(nextSpace, 0, nextSpace.Length);
                mGenerations = 0;
                mCellCount = 0;
                BackGroundColor = dlg.GetBGColor();
                AliveCellColor = dlg.GetLiveCellColor();
                GridColor = dlg.GetGridColor();
                Gridx10Color = dlg.GetGx10Color(); 
                timerSpeed = dlg.GetTimerInterval();
                timer.Interval = timerSpeed;
                gWidth = dlg.GetUWidth();
                gHeight = dlg.GetUHeight();
                if (dlg.GetisFinite() == true)
                {
                    BoundaryType = "Finite";
                }
                else if (dlg.GetisToroidal() == true)
                {
                    BoundaryType = "Toroidal";
                }

                mSpace = new bool[gWidth, gHeight];
                nextSpace = new bool[gWidth, gHeight];
                graphicsPanel1.Invalidate();
            }

        }

        //Dropdown menu item save function
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "All Files|*.*|Cells|*.cells";
                dlg.FilterIndex = 2; dlg.DefaultExt = "cells";


                if (DialogResult.OK == dlg.ShowDialog())
                {
                    StreamWriter writer = new StreamWriter(dlg.FileName);
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

        //Button save function
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

        //WORK Dropdown menu item open function
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

        //WORK Button open function
        private void openToolStripButton_Click(object sender, EventArgs e)
        {

        }

    }


}
