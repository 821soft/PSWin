namespace PSWin
{
    partial class PSWin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            MnuBar1 = new MenuStrip();
            Mnu_File = new ToolStripMenuItem();
            Mnu_Save = new ToolStripMenuItem();
            Mnu_Load = new ToolStripMenuItem();
            Mnu_View = new ToolStripMenuItem();
            Mnu_Scale = new ToolStripMenuItem();
            Mnu_Scale20 = new ToolStripMenuItem();
            Mnu_Scale25 = new ToolStripMenuItem();
            Mnu_Scale50 = new ToolStripMenuItem();
            Mnu_Refresh = new ToolStripMenuItem();
            panel1 = new Panel();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            TTP_tip1 = new ToolTip(components);
            MnuBar1.SuspendLayout();
            SuspendLayout();
            // 
            // MnuBar1
            // 
            MnuBar1.Items.AddRange(new ToolStripItem[] { Mnu_File, Mnu_View });
            MnuBar1.Location = new Point(0, 0);
            MnuBar1.Name = "MnuBar1";
            MnuBar1.Size = new Size(902, 27);
            MnuBar1.TabIndex = 0;
            MnuBar1.Text = "menuStrip1";
            // 
            // Mnu_File
            // 
            Mnu_File.DropDownItems.AddRange(new ToolStripItem[] { Mnu_Save, Mnu_Load });
            Mnu_File.Name = "Mnu_File";
            Mnu_File.Size = new Size(41, 23);
            Mnu_File.Text = "File";
            // 
            // Mnu_Save
            // 
            Mnu_Save.Name = "Mnu_Save";
            Mnu_Save.Size = new Size(180, 24);
            Mnu_Save.Text = "Save";
            Mnu_Save.Click += Mnu_Save_Click;
            // 
            // Mnu_Load
            // 
            Mnu_Load.Name = "Mnu_Load";
            Mnu_Load.Size = new Size(180, 24);
            Mnu_Load.Text = "Load";
            Mnu_Load.Click += Mnu_Load_Click;
            // 
            // Mnu_View
            // 
            Mnu_View.DropDownItems.AddRange(new ToolStripItem[] { Mnu_Scale, Mnu_Refresh });
            Mnu_View.Name = "Mnu_View";
            Mnu_View.Size = new Size(50, 23);
            Mnu_View.Text = "View";
            // 
            // Mnu_Scale
            // 
            Mnu_Scale.DropDownItems.AddRange(new ToolStripItem[] { Mnu_Scale20, Mnu_Scale25, Mnu_Scale50 });
            Mnu_Scale.Name = "Mnu_Scale";
            Mnu_Scale.Size = new Size(123, 24);
            Mnu_Scale.Text = "Scale";
            // 
            // Mnu_Scale20
            // 
            Mnu_Scale20.Name = "Mnu_Scale20";
            Mnu_Scale20.Size = new Size(105, 24);
            Mnu_Scale20.Text = "20%";
            Mnu_Scale20.Click += Mnu_Scale20_Click;
            // 
            // Mnu_Scale25
            // 
            Mnu_Scale25.Name = "Mnu_Scale25";
            Mnu_Scale25.Size = new Size(105, 24);
            Mnu_Scale25.Text = "25%";
            Mnu_Scale25.Click += Mnu_Scale25_Click;
            // 
            // Mnu_Scale50
            // 
            Mnu_Scale50.Name = "Mnu_Scale50";
            Mnu_Scale50.Size = new Size(105, 24);
            Mnu_Scale50.Text = "50%";
            Mnu_Scale50.Click += Mnu_Scale50_Click;
            // 
            // Mnu_Refresh
            // 
            Mnu_Refresh.Name = "Mnu_Refresh";
            Mnu_Refresh.Size = new Size(123, 24);
            Mnu_Refresh.Text = "Refresh";
            Mnu_Refresh.Click += Mnu_Refresh_Click;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 27);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(902, 352);
            panel1.TabIndex = 1;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "psw";
            saveFileDialog1.FileName = "pswin.psw";
            saveFileDialog1.Filter = "データ|*.psw|すべて|*.*";
            saveFileDialog1.Title = "保存";
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "psw";
            openFileDialog1.FileName = "pswin.psw";
            openFileDialog1.Filter = "pswデータ|*.psw|すべて|*.*";
            openFileDialog1.Title = "開く";
            // 
            // PSWin
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(902, 379);
            Controls.Add(panel1);
            Controls.Add(MnuBar1);
            Font = new Font("ＭＳ ゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            MainMenuStrip = MnuBar1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "PSWin";
            Text = "PSWin";
            Activated += PSWin_Activated;
            Shown += PSWin_Shown;
            MnuBar1.ResumeLayout(false);
            MnuBar1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MnuBar1;
        private Panel panel1;
        private ToolStripMenuItem Mnu_File;
        private ToolStripMenuItem Mnu_View;
        private ToolStripMenuItem Mnu_Scale;
        private ToolStripMenuItem Mnu_Scale20;
        private ToolStripMenuItem Mnu_Scale25;
        private ToolStripMenuItem Mnu_Scale50;
        private ToolStripMenuItem Mnu_Refresh;
        private ToolStripMenuItem Mnu_Save;
        private ToolStripMenuItem Mnu_Load;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private HelpProvider helpProvider1;
        private ToolTip TTP_tip1;
    }
}
