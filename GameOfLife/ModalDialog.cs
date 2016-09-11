using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class3_ModalDialog
{
    public partial class ModalDialog : Form
    {
        public ModalDialog()
        {
            InitializeComponent();
        }

        public Point RectangleLocation
        {
            get
            {
                return new Point((int)numericUpDownX.Value, (int)numericUpDownY.Value);
            }

            set
            {
                numericUpDownX.Value = value.X;
                numericUpDownY.Value = value.Y;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
