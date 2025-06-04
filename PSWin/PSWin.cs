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


        private void Lb_MouseHover(object? sender, EventArgs e)
        {
        }
        private void Lb_MouseLeave(object? sender, EventArgs e)
        {
        }

        private void Lb_Click(object? sender, EventArgs e)
        {
            foreach (System.Windows.Forms.Label lbc in panel1.Controls)
            {
                lbc.BackColor = Color.White;
            }
            System.Windows.Forms.Label lb = (System.Windows.Forms.Label)sender;
            lb.BackColor = Color.Yellow;
        }
        private void Lb_DoubleClick(object? sender, EventArgs e)
        {
            FrmWin frmwin = new FrmWin();
            System.Windows.Forms.Label lb = (System.Windows.Forms.Label)sender;
            int i = (int)lb.Tag ;
            frmwin.Tag = i ;
            frmwin.Show();
        }

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
            }

            var cnt = WinApi._wpd.Count() - 1;

            for (int i = cnt; i > 0; i--)
            {
                WinApi._st_WinPosData item = WinApi._wpd[i];
                System.Windows.Forms.Label lb = new System.Windows.Forms.Label();
                lb.Text = $"{i} {item.title}";
                lb.AutoSize = false;
                if ((item._wi.dwStyle & 0x04000000) == 0x04000000)
                {
                    lb.Location = new Point(item._wi.rcClient.left / Scale, (item._wi.rcWindow.top) / Scale);
                    lb.Size = new Size((item._wi.rcClient.right - item._wi.rcClient.left) / Scale,
                                        (item._wi.rcWindow.bottom - item._wi.rcWindow.top) / Scale);
                }
                else
                {
                    lb.Location = new Point(item._wi.rcClient.left / Scale, (item._wi.rcClient.top) / Scale);
                    lb.Size = new Size((item._wi.rcClient.right - item._wi.rcClient.left) / Scale,
                                        (item._wi.rcClient.bottom - item._wi.rcClient.top) / Scale);
                }
                
                lb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                lb.BackColor = Color.White;
                lb.Tag = i;
                lb.MouseHover += Lb_MouseHover;
                lb.MouseLeave += Lb_MouseLeave;
                lb.Click += Lb_Click;
                lb.DoubleClick += Lb_DoubleClick;
                panel1.Controls.Add(lb);
                int ww = item._wi.rcWindow.right - item._wi.rcWindow.left;
                int wh = item._wi.rcWindow.bottom - item._wi.rcWindow.top;
                int cw = item._wi.rcClient.right - item._wi.rcClient.left;
                int ch = item._wi.rcClient.bottom - item._wi.rcClient.top;
                string tip = $"HWND:0x{item.whnd:X8}\n";
                tip += $"rcWindow({item._wi.rcWindow.left},{item._wi.rcWindow.top})-({item._wi.rcWindow.right},{item._wi.rcWindow.bottom})[{ww},{wh}]\n";
                tip += $"rcClient({item._wi.rcClient.left},{item._wi.rcClient.top})-({item._wi.rcClient.right},{item._wi.rcClient.bottom})[{cw},{ch}]\n";
                tip += $"dwStyle:0x{item._wi.dwStyle:X8}\n";
                tip += $"dwExStyle:0x{item._wi.dwExStyle:X8}\n";
                tip += $"dwWindowStatus:0x{item._wi.dwWindowStatus:X8}\n";
                tip += $"WindowBorders:({item._wi.cxWindowBorders},{item._wi.cyWindowBorders})\n";
                TTP_tip1.SetToolTip(lb, tip);
                lb.BringToFront();

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
            var ret = saveFileDialog1.ShowDialog(this);
            if (ret != DialogResult.OK)
            {
                return;
            }
            string path = saveFileDialog1.FileName;

            Debug.Print($"Save {path}");
            for (int i = 1; i < WinApi._wpd.Count; i++)
            {
                WinApi._st_WinPosData item = WinApi._wpd[i];
                string param = "";
                param += $"{i}\t{item.dwstyle:x8}\t{item.title}\t";
                param += $"{item._wi.rcWindow.left}\t{item._wi.rcWindow.top}\t{item._wi.rcWindow.right}\t{item._wi.rcWindow.bottom}\t";
                param += $"{item._wi.rcClient.left}\t{item._wi.rcClient.top}\t{item._wi.rcClient.right}\t{item._wi.rcClient.bottom}";

                Debug.Print(param);
            }

            // 文字コードを指定
            Encoding enc = Encoding.GetEncoding("UTF-8");

            // ファイルを開く
            StreamWriter writer = new StreamWriter(path, false, enc);

            for (int i = 1; i < WinApi._wpd.Count; i++)
            {
                WinApi._st_WinPosData item = WinApi._wpd[i];

                string param = "";
                param += $"{i}\t{item.dwstyle:x8}\t{item.title}\t";
                param += $"{item._wi.rcWindow.left}\t{item._wi.rcWindow.top}\t{item._wi.rcWindow.right}\t{item._wi.rcWindow.bottom}\t";
                param += $"{item._wi.rcClient.left}\t{item._wi.rcClient.top}\t{item._wi.rcClient.right}\t{item._wi.rcClient.bottom}";

                // テキストを書き込む
                writer.WriteLine(param);
            }
            // ファイルを閉じる
            writer.Close();
        }

        private void Mnu_Load_Click(object sender, EventArgs e)
        {
            var res = openFileDialog1.ShowDialog(this);
            if (res != DialogResult.OK)
            {
                return;
            }
            string path = openFileDialog1.FileName;
            Debug.Print($"Load {path}");

            // ファイルを開く＆文字化け防止
            StreamReader file = new StreamReader(path, Encoding.GetEncoding("UTF-8"));
            if (file == null)
            {
                Console.WriteLine("ファイルを開けませんでした。");
                return;
            }

            // 行末まで１行ずつ読み込む
            while (file.Peek() != -1)
            {
                var str = file.ReadLine();
                string[] dat = str.Split('\t');
                if (dat.Length > 0)
                {
                    int x = int.Parse(dat[3]);
                    int y = int.Parse(dat[4]);
                    int w = int.Parse(dat[5])-x;
                    int h = int.Parse(dat[6])-y;
                    var ret = WinApi._MoveWindows(dat[2], x, y, w, h );
                    Debug.Print($"{ret} {dat[2]}");

                }
            }

            file.Close();
            PSWin_Shown(sender, e);

        }

        private void PSWin_Activated(object sender, EventArgs e)
        {
            PSWin_Shown(sender, e);
        }
    }
}
