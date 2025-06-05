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
            label1 = new Label();
            NUD_Width = new NumericUpDown();
            NUD_Height = new NumericUpDown();
            NUD_Top = new NumericUpDown();
            NUD_Left = new NumericUpDown();
            pictureBox1 = new PictureBox();
            Btn_Ok = new Button();
            Btn_Cancel = new Button();
            Btn_Move = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_Width).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Height).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Top).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Left).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(NUD_Width);
            panel1.Controls.Add(NUD_Height);
            panel1.Controls.Add(NUD_Top);
            panel1.Controls.Add(NUD_Left);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(7, 9);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(479, 232);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.Location = new Point(14, 203);
            label1.Name = "label1";
            label1.Size = new Size(206, 17);
            label1.TabIndex = 7;
            label1.Text = "label1";
            // 
            // NUD_Width
            // 
            NUD_Width.Location = new Point(214, 13);
            NUD_Width.Margin = new Padding(3, 2, 3, 2);
            NUD_Width.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NUD_Width.Name = "NUD_Width";
            NUD_Width.Size = new Size(56, 23);
            NUD_Width.TabIndex = 3;
            NUD_Width.ValueChanged += NUD_Width_ValueChanged;
            // 
            // NUD_Height
            // 
            NUD_Height.Location = new Point(11, 107);
            NUD_Height.Margin = new Padding(3, 2, 3, 2);
            NUD_Height.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NUD_Height.Name = "NUD_Height";
            NUD_Height.Size = new Size(56, 23);
            NUD_Height.TabIndex = 4;
            NUD_Height.ValueChanged += NUD_Height_ValueChanged;
            // 
            // NUD_Top
            // 
            NUD_Top.Location = new Point(73, 13);
            NUD_Top.Margin = new Padding(3, 2, 3, 2);
            NUD_Top.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NUD_Top.Name = "NUD_Top";
            NUD_Top.Size = new Size(56, 23);
            NUD_Top.TabIndex = 2;
            NUD_Top.Value = new decimal(new int[] { 1920, 0, 0, 0 });
            NUD_Top.ValueChanged += NUD_Top_ValueChanged;
            // 
            // NUD_Left
            // 
            NUD_Left.Location = new Point(11, 13);
            NUD_Left.Margin = new Padding(3, 2, 3, 2);
            NUD_Left.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NUD_Left.Name = "NUD_Left";
            NUD_Left.Size = new Size(56, 23);
            NUD_Left.TabIndex = 1;
            NUD_Left.Value = new decimal(new int[] { 1920, 0, 0, 0 });
            NUD_Left.ValueChanged += NUD_Left_ValueChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(73, 42);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(333, 151);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Btn_Ok
            // 
            Btn_Ok.Location = new Point(420, 246);
            Btn_Ok.Margin = new Padding(3, 2, 3, 2);
            Btn_Ok.Name = "Btn_Ok";
            Btn_Ok.Size = new Size(66, 24);
            Btn_Ok.TabIndex = 8;
            Btn_Ok.Text = "Ok";
            Btn_Ok.UseVisualStyleBackColor = true;
            Btn_Ok.Click += Btn_Ok_Click;
            // 
            // Btn_Cancel
            // 
            Btn_Cancel.Location = new Point(349, 246);
            Btn_Cancel.Margin = new Padding(3, 2, 3, 2);
            Btn_Cancel.Name = "Btn_Cancel";
            Btn_Cancel.Size = new Size(66, 24);
            Btn_Cancel.TabIndex = 7;
            Btn_Cancel.Text = "Cancel";
            Btn_Cancel.UseVisualStyleBackColor = true;
            Btn_Cancel.Click += Btn_Cancel_Click;
            // 
            // Btn_Move
            // 
            Btn_Move.Location = new Point(278, 246);
            Btn_Move.Margin = new Padding(3, 2, 3, 2);
            Btn_Move.Name = "Btn_Move";
            Btn_Move.Size = new Size(66, 24);
            Btn_Move.TabIndex = 9;
            Btn_Move.Text = "Test";
            Btn_Move.UseVisualStyleBackColor = true;
            Btn_Move.Click += Btn_Move_Click;
            // 
            // FrmWin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 275);
            Controls.Add(Btn_Move);
            Controls.Add(Btn_Cancel);
            Controls.Add(Btn_Ok);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmWin";
            ShowIcon = false;
            ShowInTaskbar = false;
            Shown += FrmWin_Shown;
            panel1.ResumeLayout(false);
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
        private NumericUpDown NUD_Width;
        private NumericUpDown NUD_Height;
        private NumericUpDown NUD_Top;
        private NumericUpDown NUD_Left;
        private Button Btn_Ok;
        private Button Btn_Cancel;
        private Button Btn_Move;
        private Label label1;
    }
}