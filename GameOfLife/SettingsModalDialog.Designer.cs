namespace GameOfLife
{
    partial class SettingsModalDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_UHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_UWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_TimerInterval = new System.Windows.Forms.NumericUpDown();
            this.label_UniverseHeight = new System.Windows.Forms.Label();
            this.label_UniverseWidth = new System.Windows.Forms.Label();
            this.label_TimerInterval = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LiveCellColorButton = new System.Windows.Forms.Button();
            this.BGColorButton = new System.Windows.Forms.Button();
            this.Gx10ColorButton = new System.Windows.Forms.Button();
            this.GColorButton = new System.Windows.Forms.Button();
            this.LiveCellColorLabel = new System.Windows.Forms.Label();
            this.BackgroundColorLabel = new System.Windows.Forms.Label();
            this.Gx10ColorLabel = new System.Windows.Forms.Label();
            this.GColorLabel = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.NoteToroidalLabel = new System.Windows.Forms.Label();
            this.NoteFiniteLabel = new System.Windows.Forms.Label();
            this.BoundaryTypeGBox = new System.Windows.Forms.GroupBox();
            this.WarningLabel3 = new System.Windows.Forms.Label();
            this.WarningLabel2 = new System.Windows.Forms.Label();
            this.WarningLabel = new System.Windows.Forms.Label();
            this.ToroidalradioButton = new System.Windows.Forms.RadioButton();
            this.FiniteradioButton = new System.Windows.Forms.RadioButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_UHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_UWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TimerInterval)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.BoundaryTypeGBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(12, 363);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 0;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(93, 363);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(497, 344);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.numericUpDown_UHeight);
            this.tabPage1.Controls.Add(this.numericUpDown_UWidth);
            this.tabPage1.Controls.Add(this.numericUpDown_TimerInterval);
            this.tabPage1.Controls.Add(this.label_UniverseHeight);
            this.tabPage1.Controls.Add(this.label_UniverseWidth);
            this.tabPage1.Controls.Add(this.label_TimerInterval);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(489, 318);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(10, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "neighbor counter will overlap!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(7, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Warning! Unless you\'re using close to the base intervals (Width: 30, Height: 30)";
            // 
            // numericUpDown_UHeight
            // 
            this.numericUpDown_UHeight.Location = new System.Drawing.Point(155, 61);
            this.numericUpDown_UHeight.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown_UHeight.Name = "numericUpDown_UHeight";
            this.numericUpDown_UHeight.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_UHeight.TabIndex = 5;
            // 
            // numericUpDown_UWidth
            // 
            this.numericUpDown_UWidth.Location = new System.Drawing.Point(155, 34);
            this.numericUpDown_UWidth.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown_UWidth.Name = "numericUpDown_UWidth";
            this.numericUpDown_UWidth.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_UWidth.TabIndex = 4;
            // 
            // numericUpDown_TimerInterval
            // 
            this.numericUpDown_TimerInterval.Location = new System.Drawing.Point(155, 6);
            this.numericUpDown_TimerInterval.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown_TimerInterval.Name = "numericUpDown_TimerInterval";
            this.numericUpDown_TimerInterval.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_TimerInterval.TabIndex = 3;
            // 
            // label_UniverseHeight
            // 
            this.label_UniverseHeight.AutoSize = true;
            this.label_UniverseHeight.Location = new System.Drawing.Point(7, 63);
            this.label_UniverseHeight.Name = "label_UniverseHeight";
            this.label_UniverseHeight.Size = new System.Drawing.Size(131, 13);
            this.label_UniverseHeight.TabIndex = 2;
            this.label_UniverseHeight.Text = "Height of Universe in Cells";
            // 
            // label_UniverseWidth
            // 
            this.label_UniverseWidth.AutoSize = true;
            this.label_UniverseWidth.Location = new System.Drawing.Point(7, 36);
            this.label_UniverseWidth.Name = "label_UniverseWidth";
            this.label_UniverseWidth.Size = new System.Drawing.Size(128, 13);
            this.label_UniverseWidth.TabIndex = 1;
            this.label_UniverseWidth.Text = "Width of Universe in Cells";
            // 
            // label_TimerInterval
            // 
            this.label_TimerInterval.AutoSize = true;
            this.label_TimerInterval.Location = new System.Drawing.Point(7, 9);
            this.label_TimerInterval.Name = "label_TimerInterval";
            this.label_TimerInterval.Size = new System.Drawing.Size(142, 13);
            this.label_TimerInterval.TabIndex = 0;
            this.label_TimerInterval.Text = "Timer Interval in Milliseconds";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LiveCellColorButton);
            this.tabPage2.Controls.Add(this.BGColorButton);
            this.tabPage2.Controls.Add(this.Gx10ColorButton);
            this.tabPage2.Controls.Add(this.GColorButton);
            this.tabPage2.Controls.Add(this.LiveCellColorLabel);
            this.tabPage2.Controls.Add(this.BackgroundColorLabel);
            this.tabPage2.Controls.Add(this.Gx10ColorLabel);
            this.tabPage2.Controls.Add(this.GColorLabel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(489, 318);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LiveCellColorButton
            // 
            this.LiveCellColorButton.BackColor = System.Drawing.Color.Transparent;
            this.LiveCellColorButton.Location = new System.Drawing.Point(23, 93);
            this.LiveCellColorButton.Name = "LiveCellColorButton";
            this.LiveCellColorButton.Size = new System.Drawing.Size(47, 23);
            this.LiveCellColorButton.TabIndex = 7;
            this.LiveCellColorButton.UseVisualStyleBackColor = false;
            this.LiveCellColorButton.Click += new System.EventHandler(this.LiveCellColorButton_Click);
            // 
            // BGColorButton
            // 
            this.BGColorButton.Location = new System.Drawing.Point(23, 64);
            this.BGColorButton.Name = "BGColorButton";
            this.BGColorButton.Size = new System.Drawing.Size(47, 23);
            this.BGColorButton.TabIndex = 6;
            this.BGColorButton.UseVisualStyleBackColor = true;
            this.BGColorButton.Click += new System.EventHandler(this.BGColorButton_Click);
            // 
            // Gx10ColorButton
            // 
            this.Gx10ColorButton.Location = new System.Drawing.Point(23, 35);
            this.Gx10ColorButton.Name = "Gx10ColorButton";
            this.Gx10ColorButton.Size = new System.Drawing.Size(47, 23);
            this.Gx10ColorButton.TabIndex = 5;
            this.Gx10ColorButton.UseVisualStyleBackColor = true;
            this.Gx10ColorButton.Click += new System.EventHandler(this.Gx10ColorButton_Click);
            // 
            // GColorButton
            // 
            this.GColorButton.Location = new System.Drawing.Point(23, 6);
            this.GColorButton.Name = "GColorButton";
            this.GColorButton.Size = new System.Drawing.Size(47, 23);
            this.GColorButton.TabIndex = 4;
            this.GColorButton.UseVisualStyleBackColor = true;
            this.GColorButton.Click += new System.EventHandler(this.GColorButton_Click);
            // 
            // LiveCellColorLabel
            // 
            this.LiveCellColorLabel.AutoSize = true;
            this.LiveCellColorLabel.Location = new System.Drawing.Point(76, 98);
            this.LiveCellColorLabel.Name = "LiveCellColorLabel";
            this.LiveCellColorLabel.Size = new System.Drawing.Size(74, 13);
            this.LiveCellColorLabel.TabIndex = 3;
            this.LiveCellColorLabel.Text = "Live Cell Color";
            // 
            // BackgroundColorLabel
            // 
            this.BackgroundColorLabel.AutoSize = true;
            this.BackgroundColorLabel.Location = new System.Drawing.Point(76, 69);
            this.BackgroundColorLabel.Name = "BackgroundColorLabel";
            this.BackgroundColorLabel.Size = new System.Drawing.Size(92, 13);
            this.BackgroundColorLabel.TabIndex = 2;
            this.BackgroundColorLabel.Text = "Background Color";
            // 
            // Gx10ColorLabel
            // 
            this.Gx10ColorLabel.AutoSize = true;
            this.Gx10ColorLabel.Location = new System.Drawing.Point(76, 40);
            this.Gx10ColorLabel.Name = "Gx10ColorLabel";
            this.Gx10ColorLabel.Size = new System.Drawing.Size(73, 13);
            this.Gx10ColorLabel.TabIndex = 1;
            this.Gx10ColorLabel.Text = "Grid x10 Color";
            // 
            // GColorLabel
            // 
            this.GColorLabel.AutoSize = true;
            this.GColorLabel.Location = new System.Drawing.Point(76, 11);
            this.GColorLabel.Name = "GColorLabel";
            this.GColorLabel.Size = new System.Drawing.Size(53, 13);
            this.GColorLabel.TabIndex = 0;
            this.GColorLabel.Text = "Grid Color";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.NoteToroidalLabel);
            this.tabPage3.Controls.Add(this.NoteFiniteLabel);
            this.tabPage3.Controls.Add(this.BoundaryTypeGBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(489, 318);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Advanced";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // NoteToroidalLabel
            // 
            this.NoteToroidalLabel.AutoSize = true;
            this.NoteToroidalLabel.ForeColor = System.Drawing.Color.Red;
            this.NoteToroidalLabel.Location = new System.Drawing.Point(7, 131);
            this.NoteToroidalLabel.Name = "NoteToroidalLabel";
            this.NoteToroidalLabel.Size = new System.Drawing.Size(329, 13);
            this.NoteToroidalLabel.TabIndex = 2;
            this.NoteToroidalLabel.Text = "Toroidal - Anything that goes over a border get\'s looped to other side";
            // 
            // NoteFiniteLabel
            // 
            this.NoteFiniteLabel.AutoSize = true;
            this.NoteFiniteLabel.ForeColor = System.Drawing.Color.Red;
            this.NoteFiniteLabel.Location = new System.Drawing.Point(7, 114);
            this.NoteFiniteLabel.Name = "NoteFiniteLabel";
            this.NoteFiniteLabel.Size = new System.Drawing.Size(217, 13);
            this.NoteFiniteLabel.TabIndex = 1;
            this.NoteFiniteLabel.Text = "Finite - Anything that goes over a border dies";
            // 
            // BoundaryTypeGBox
            // 
            this.BoundaryTypeGBox.Controls.Add(this.WarningLabel3);
            this.BoundaryTypeGBox.Controls.Add(this.WarningLabel2);
            this.BoundaryTypeGBox.Controls.Add(this.WarningLabel);
            this.BoundaryTypeGBox.Controls.Add(this.ToroidalradioButton);
            this.BoundaryTypeGBox.Controls.Add(this.FiniteradioButton);
            this.BoundaryTypeGBox.Location = new System.Drawing.Point(7, 7);
            this.BoundaryTypeGBox.Name = "BoundaryTypeGBox";
            this.BoundaryTypeGBox.Size = new System.Drawing.Size(200, 100);
            this.BoundaryTypeGBox.TabIndex = 0;
            this.BoundaryTypeGBox.TabStop = false;
            this.BoundaryTypeGBox.Text = "Boundary Type";
            // 
            // WarningLabel3
            // 
            this.WarningLabel3.AutoSize = true;
            this.WarningLabel3.ForeColor = System.Drawing.Color.Red;
            this.WarningLabel3.Location = new System.Drawing.Point(101, 48);
            this.WarningLabel3.Name = "WarningLabel3";
            this.WarningLabel3.Size = new System.Drawing.Size(67, 13);
            this.WarningLabel3.TabIndex = 4;
            this.WarningLabel3.Text = "current cells.";
            // 
            // WarningLabel2
            // 
            this.WarningLabel2.AutoSize = true;
            this.WarningLabel2.ForeColor = System.Drawing.Color.Red;
            this.WarningLabel2.Location = new System.Drawing.Point(75, 35);
            this.WarningLabel2.Name = "WarningLabel2";
            this.WarningLabel2.Size = new System.Drawing.Size(125, 13);
            this.WarningLabel2.TabIndex = 3;
            this.WarningLabel2.Text = "boundary type may erase";
            // 
            // WarningLabel
            // 
            this.WarningLabel.AutoSize = true;
            this.WarningLabel.ForeColor = System.Drawing.Color.Red;
            this.WarningLabel.Location = new System.Drawing.Point(87, 22);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(98, 13);
            this.WarningLabel.TabIndex = 2;
            this.WarningLabel.Text = "Warning! Changing";
            // 
            // ToroidalradioButton
            // 
            this.ToroidalradioButton.AutoSize = true;
            this.ToroidalradioButton.Location = new System.Drawing.Point(7, 44);
            this.ToroidalradioButton.Name = "ToroidalradioButton";
            this.ToroidalradioButton.Size = new System.Drawing.Size(63, 17);
            this.ToroidalradioButton.TabIndex = 1;
            this.ToroidalradioButton.TabStop = true;
            this.ToroidalradioButton.Text = "Toroidal";
            this.ToroidalradioButton.UseVisualStyleBackColor = true;
            this.ToroidalradioButton.CheckedChanged += new System.EventHandler(this.ToroidalradioButton_CheckedChanged);
            // 
            // FiniteradioButton
            // 
            this.FiniteradioButton.AutoSize = true;
            this.FiniteradioButton.Checked = true;
            this.FiniteradioButton.Location = new System.Drawing.Point(7, 20);
            this.FiniteradioButton.Name = "FiniteradioButton";
            this.FiniteradioButton.Size = new System.Drawing.Size(50, 17);
            this.FiniteradioButton.TabIndex = 0;
            this.FiniteradioButton.TabStop = true;
            this.FiniteradioButton.Text = "Finite";
            this.FiniteradioButton.UseVisualStyleBackColor = true;
            this.FiniteradioButton.CheckedChanged += new System.EventHandler(this.FiniteradioButton_CheckedChanged);
            // 
            // SettingsModalDialog
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(528, 390);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsModalDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsModalDialog";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_UHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_UWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TimerInterval)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.BoundaryTypeGBox.ResumeLayout(false);
            this.BoundaryTypeGBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NumericUpDown numericUpDown_UHeight;
        private System.Windows.Forms.NumericUpDown numericUpDown_UWidth;
        private System.Windows.Forms.NumericUpDown numericUpDown_TimerInterval;
        private System.Windows.Forms.Label label_UniverseHeight;
        private System.Windows.Forms.Label label_UniverseWidth;
        private System.Windows.Forms.Label label_TimerInterval;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label NoteToroidalLabel;
        private System.Windows.Forms.Label NoteFiniteLabel;
        private System.Windows.Forms.GroupBox BoundaryTypeGBox;
        private System.Windows.Forms.Label WarningLabel3;
        private System.Windows.Forms.Label WarningLabel2;
        private System.Windows.Forms.Label WarningLabel;
        private System.Windows.Forms.RadioButton ToroidalradioButton;
        private System.Windows.Forms.RadioButton FiniteradioButton;
        private System.Windows.Forms.Button LiveCellColorButton;
        private System.Windows.Forms.Button BGColorButton;
        private System.Windows.Forms.Button Gx10ColorButton;
        private System.Windows.Forms.Button GColorButton;
        private System.Windows.Forms.Label LiveCellColorLabel;
        private System.Windows.Forms.Label BackgroundColorLabel;
        private System.Windows.Forms.Label Gx10ColorLabel;
        private System.Windows.Forms.Label GColorLabel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}