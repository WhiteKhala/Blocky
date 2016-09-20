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
    public partial class SeedDialog : Form
    {
        int RandomNumber;
        bool AcceptChoices = false;

        public SeedDialog()
        {
            InitializeComponent();
        }

        //G's
        public int GetRandomNumber() { return RandomNumber; }
        public bool GetChoice() { return AcceptChoices; }

        //Our randomizer! Works with a click of a button
        private void RandomizeButton_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            RandomNumber = rand.Next();
            numericUpDown1.Value = RandomNumber;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            RandomNumber = (int)numericUpDown1.Value;
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            AcceptChoices = true;
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            AcceptChoices = false;
        }
    }
}
