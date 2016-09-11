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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label_TimerInterval = new System.Windows.Forms.Label();
            this.label_UniverseWidth = new System.Windows.Forms.Label();
            this.label_UniverseHeight = new System.Windows.Forms.Label();
            this.numericUpDown_TimerInterval = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_UWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_UHeight = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TimerInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_UWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_UHeight)).BeginInit();
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
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(489, 318);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(489, 318);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Advanced";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            // label_UniverseWidth
            // 
            this.label_UniverseWidth.AutoSize = true;
            this.label_UniverseWidth.Location = new System.Drawing.Point(7, 36);
            this.label_UniverseWidth.Name = "label_UniverseWidth";
            this.label_UniverseWidth.Size = new System.Drawing.Size(128, 13);
            this.label_UniverseWidth.TabIndex = 1;
            this.label_UniverseWidth.Text = "Width of Universe in Cells";
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
            // numericUpDown_TimerInterval
            // 
            this.numericUpDown_TimerInterval.Location = new System.Drawing.Point(155, 6);
            this.numericUpDown_TimerInterval.Name = "numericUpDown_TimerInterval";
            this.numericUpDown_TimerInterval.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_TimerInterval.TabIndex = 3;
            // 
            // numericUpDown_UWidth
            // 
            this.numericUpDown_UWidth.Location = new System.Drawing.Point(155, 34);
            this.numericUpDown_UWidth.Name = "numericUpDown_UWidth";
            this.numericUpDown_UWidth.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_UWidth.TabIndex = 4;
            // 
            // numericUpDown_UHeight
            // 
            this.numericUpDown_UHeight.Location = new System.Drawing.Point(155, 61);
            this.numericUpDown_UHeight.Name = "numericUpDown_UHeight";
            this.numericUpDown_UHeight.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_UHeight.TabIndex = 5;
            // 
            // SettingsModalDialog
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(522, 398);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsModalDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsModalDialog";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TimerInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_UWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_UHeight)).EndInit();
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
    }
}