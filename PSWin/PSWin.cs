using System.Diagnostics;
using System.Reflection.Emit;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using static PSWin.WinApi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PSWin
{
    public partial class PSWin : Form
    {
        public PSWin()
        {
            InitializeComponent();
        }
        private int Scale = 5;
        private IntPtr SelectedWin = 0;
        private void DrawLayout()
        {
            WinApi._WinPosData();
            if (WinApi._WinPosData_comp() == false)
            {
                // 変化なし
                return;
            }
            else
            {
                // 変化あり
                WinApi._WinPosData_store();
                panel1.Controls.Clear();
                Mnu_Windows.Items.Clear();
                Mnu_Windows.SelectedIndex = -1;

                for (int i = 1; i < WinApi._wpd.Count; i++)
                {
                    WinApi._st_WinPosData item = WinApi._wpd[i];
                    Mnu_Windows.Items.Add($"{i} {item.dwstyle:x8} {item.title}");
                }

            }

            var cnt = WinApi._wpd.Count() - 1;

            for (int i = cnt; i > 0; i--)
            {
                WinApi._st_WinPosData item = WinApi._wpd[i];
                System.Windows.Forms.Label lb = new System.Windows.Forms.Label();
                lb.Text = $"{i} {item.title}";
                lb.AutoSize = false;
                lb.Location = new Point(item.x / Scale, item.y / Scale);
                lb.Size = new Size(item.cx / Scale, item.cy / Scale);
                lb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                lb.BackColor = Color.White;
                lb.Tag = i;

                panel1.Controls.Add(lb);
                lb.BringToFront();
            }
            for (int i = 0; i < Mnu_Windows.Items.Count; i++)
            {
                if (SelectedWin == WinApi._wpd[i].whnd)
                {
                    Mnu_Windows.SelectedIndex = i;
                }
            }
        }

        private void PSWin_Shown(object sender, EventArgs e)
        {
            IntPtr w = WinApi.GetDesktopWindow();
            WinApi.WINDOWINFO _wi = new WinApi.WINDOWINFO();
            WinApi.GetWindowInfo(w, ref _wi);
            var d_w = _wi.rcWindow.right;
            var d_h = _wi.rcWindow.bottom;
            this.Text = $"Desktop ({d_w},{d_h})";
            panel1.Location = new Point(0, 0);
            panel1.Size = new Size(d_w / Scale, d_h / Scale);

            this.ClientSize = new Size(d_w / Scale, (d_h / Scale) + MnuBar1.Height);
            DrawLayout();

        }

        private void Mnu_Scale20_Click(object sender, EventArgs e)
        {
            Scale = 5;
            PSWin_Shown(sender, e);
        }

        private void Mnu_Scale25_Click(object sender, EventArgs e)
        {
            Scale = 4;
            PSWin_Shown(sender, e);
        }

        private void Mnu_Scale50_Click(object sender, EventArgs e)
        {
            Scale = 2;
            PSWin_Shown(sender, e);
        }

        private void Mnu_Refresh_Click(object sender, EventArgs e)
        {
            PSWin_Shown(sender, e);
        }

        private void Mnu_Save_Click(object sender, EventArgs e)
        {
            Debug.Print("Save");
            for (int i = 1; i < WinApi._wpd.Count; i++)
            {
                WinApi._st_WinPosData item = WinApi._wpd[i];
                Debug.Print($"{i},{item.dwstyle:x8},{item.title},{item.x},{item.y},{item.cx},{item.cy}");
            }

            // 文字コードを指定
            Encoding enc = Encoding.GetEncoding("UTF-8");

            // ファイルを開く
            StreamWriter writer = new StreamWriter(@"PSWin.dat", false, enc);

            for (int i = 1; i < WinApi._wpd.Count; i++)
            {
                WinApi._st_WinPosData item = WinApi._wpd[i];
                // テキストを書き込む
                writer.WriteLine($"{i},{item.dwstyle:x8},{item.title},{item.x},{item.y},{item.cx},{item.cy}");
            }
            // ファイルを閉じる
            writer.Close();
        }

        private void Mnu_Load_Click(object sender, EventArgs e)
        {
            string path = @"PSWin.dat";

            // ファイルを開く＆文字化け防止
            StreamReader file = new StreamReader(path, Encoding.GetEncoding("UTF-8"));
            if (file == null)
            {
                Console.WriteLine("ファイルを開けませんでした。");
                return;
            }
            Debug.Print("Load");

            // 行末まで１行ずつ読み込む
            while (file.Peek() != -1)
            {
                var str = file.ReadLine();
                string[] dat = str.Split(',');
                if (dat.Length > 0)
                {
                    string rec = "";

                    for (int i = 0; i < dat.Length; i++)
                    { 
                        rec += $"{dat[i]} ";
                    }
                    Debug.Print(rec);
                }
            }

            file.Close();

        }
    }
}
