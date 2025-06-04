namespace PSWin
{
    partial class FrmWin
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
            panel1 = new Panel();
            NUD_Bottom = new NumericUpDown();
            NUD_Right = new NumericUpDown();
            NUD_Width = new NumericUpDown();
            NUD_Height = new NumericUpDown();
            NUD_Top = new NumericUpDown();
            NUD_Left = new NumericUpDown();
            pictureBox1 = new PictureBox();
            Btn_Ok = new Button();
            Btn_Cancel = new Button();
            Btn_Move = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_Bottom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Right).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Width).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Height).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Top).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Left).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(NUD_Bottom);
            panel1.Controls.Add(NUD_Right);
            panel1.Controls.Add(NUD_Width);
            panel1.Controls.Add(NUD_Height);
            panel1.Controls.Add(NUD_Top);
            panel1.Controls.Add(NUD_Left);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(8, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(547, 294);
            panel1.TabIndex = 6;
            // 
            // NUD_Bottom
            // 
            NUD_Bottom.Location = new Point(469, 250);
            NUD_Bottom.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NUD_Bottom.Name = "NUD_Bottom";
            NUD_Bottom.Size = new Size(64, 26);
            NUD_Bottom.TabIndex = 6;
            // 
            // NUD_Right
            // 
            NUD_Right.Location = new Point(399, 250);
            NUD_Right.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NUD_Right.Name = "NUD_Right";
            NUD_Right.Size = new Size(64, 26);
            NUD_Right.TabIndex = 5;
            // 
            // NUD_Width
            // 
            NUD_Width.Location = new Point(245, 17);
            NUD_Width.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NUD_Width.Name = "NUD_Width";
            NUD_Width.Size = new Size(64, 26);
            NUD_Width.TabIndex = 3;
            NUD_Width.ValueChanged += NUD_Width_ValueChanged;
            // 
            // NUD_Height
            // 
            NUD_Height.Location = new Point(13, 135);
            NUD_Height.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NUD_Height.Name = "NUD_Height";
            NUD_Height.Size = new Size(64, 26);
            NUD_Height.TabIndex = 4;
            NUD_Height.ValueChanged += NUD_Height_ValueChanged;
            // 
            // NUD_Top
            // 
            NUD_Top.Location = new Point(83, 17);
            NUD_Top.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NUD_Top.Name = "NUD_Top";
            NUD_Top.Size = new Size(64, 26);
            NUD_Top.TabIndex = 2;
            NUD_Top.Value = new decimal(new int[] { 1920, 0, 0, 0 });
            NUD_Top.ValueChanged += NUD_Top_ValueChanged;
            // 
            // NUD_Left
            // 
            NUD_Left.Location = new Point(13, 17);
            NUD_Left.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NUD_Left.Name = "NUD_Left";
            NUD_Left.Size = new Size(64, 26);
            NUD_Left.TabIndex = 1;
            NUD_Left.Value = new decimal(new int[] { 1920, 0, 0, 0 });
            NUD_Left.ValueChanged += NUD_Left_ValueChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(83, 53);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(380, 191);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Btn_Ok
            // 
            Btn_Ok.Location = new Point(480, 312);
            Btn_Ok.Name = "Btn_Ok";
            Btn_Ok.Size = new Size(75, 31);
            Btn_Ok.TabIndex = 8;
            Btn_Ok.Text = "Ok";
            Btn_Ok.UseVisualStyleBackColor = true;
            Btn_Ok.Click += Btn_Ok_Click;
            // 
            // Btn_Cancel
            // 
            Btn_Cancel.Location = new Point(399, 312);
            Btn_Cancel.Name = "Btn_Cancel";
            Btn_Cancel.Size = new Size(75, 31);
            Btn_Cancel.TabIndex = 7;
            Btn_Cancel.Text = "Cancel";
            Btn_Cancel.UseVisualStyleBackColor = true;
            Btn_Cancel.Click += Btn_Cancel_Click;
            // 
            // Btn_Move
            // 
            Btn_Move.Location = new Point(318, 312);
            Btn_Move.Name = "Btn_Move";
            Btn_Move.Size = new Size(75, 31);
            Btn_Move.TabIndex = 9;
            Btn_Move.Text = "Test";
            Btn_Move.UseVisualStyleBackColor = true;
            Btn_Move.Click += Btn_Move_Click;
            // 
            // FrmWin
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 348);
            Controls.Add(Btn_Move);
            Controls.Add(Btn_Cancel);
            Controls.Add(Btn_Ok);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmWin";
            ShowIcon = false;
            ShowInTaskbar = false;
            Shown += FrmWin_Shown;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NUD_Bottom).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Right).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Width).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Height).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Top).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Left).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private PictureBox pictureBox1;
        private NumericUpDown NUD_Bottom;
        private NumericUpDown NUD_Right;
        private NumericUpDown NUD_Width;
        private NumericUpDown NUD_Height;
        private NumericUpDown NUD_Top;
        private NumericUpDown NUD_Left;
        private Button Btn_Ok;
        private Button Btn_Cancel;
        private Button Btn_Move;
    }
}