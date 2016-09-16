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
    public partial class SettingsModalDialog : Form
    {
        Form1 Grabber = new Form1();
        bool AcceptChoices = false;
        public SettingsModalDialog()
        {
            InitializeComponent();
        }

        //A's
        public int GetTimerInterval() { return (int)numericUpDown_TimerInterval.Value; }
        public int GetUWidth() { return (int)numericUpDown_UWidth.Value; }
        public int GetUHeight() { return (int)numericUpDown_UHeight.Value; }
        public bool GetChoice() { return AcceptChoices; }
        //G's
        public void SetTimerInterval(int _timer) { numericUpDown_TimerInterval.Value = _timer; }
        public void SetUWidth(int _uWidth) { numericUpDown_UWidth.Value = _uWidth; }
        public void SetUHeight(int _uHeight) { numericUpDown_UHeight.Value = _uHeight; }

        private void GColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = GColorButton.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                GColorButton.BackColor = dlg.Color;
            }
        }

        public void SetGridColor(Color _color) { GColorButton.BackColor = _color; }
        public Color GetGridColor() { return GColorButton.BackColor; }

        private void Gx10ColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = Gx10ColorButton.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                Gx10ColorButton.BackColor = dlg.Color;
            }
        }

        public void SetGx10Color(Color _color) { Gx10ColorButton.BackColor = _color; }
        public Color GetGx10Color() { return Gx10ColorButton.BackColor; }

        private void BGColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = BGColorButton.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                BGColorButton.BackColor = dlg.Color;
            }
        }
        public void SetBGColor(Color _color) { BGColorButton.BackColor = _color; }
        public Color GetBGColor() { return BGColorButton.BackColor; }

        private void LiveCellColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = LiveCellColorButton.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                LiveCellColorButton.BackColor = dlg.Color;
            }
        }

        public void SetLiveCellColor(Color _color) { LiveCellColorButton.BackColor = _color; }
        public Color GetLiveCellColor() { return LiveCellColorButton.BackColor; }


        private void button_OK_Click(object sender, EventArgs e)
        {
            AcceptChoices = true;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            AcceptChoices = false;
        }

        private void numericUpDown_TimerInterval_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown_UWidth_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
