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
                if (lbc.Tag != null)
                {
                    lbc.BackColor = Color.White;
                }
            }
            System.Windows.Forms.Label lb = (System.Windows.Forms.Label)sender;
            lb.BackColor = Color.Yellow;
        }
        private void Lb_DoubleClick(object? sender, EventArgs e)
        {
            FrmWin frmwin = new FrmWin();
            System.Windows.Forms.Label lb = (System.Windows.Forms.Label)sender;
            int i = (int)lb.Tag;
            frmwin.Tag = i;
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
                foreach (var screen in System.Windows.Forms.Screen.AllScreens)
                {
                    // screen.Bounds;
                    // screen.WorkingArea;
                    System.Windows.Forms.Label lb = new System.Windows.Forms.Label();
                    lb.Text = screen.DeviceName;
                    lb.AutoSize = false;
                    lb.Location = new Point(screen.Bounds.X / Scale, screen.Bounds.Y / Scale);
                    lb.Size = new Size((screen.Bounds.Width) / Scale,
                                        (screen.Bounds.Height) / Scale);
                    lb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    lb.BackColor = Color.Gray;
                    panel1.Controls.Add(lb);

                    System.Windows.Forms.Label lb2 = new System.Windows.Forms.Label();
                    lb2.Text = screen.DeviceName;
                    lb2.AutoSize = false;
                    lb2.Location = new Point(screen.WorkingArea.X / Scale, screen.WorkingArea.Y / Scale);
                    lb2.Size = new Size((screen.WorkingArea.Width) / Scale,
                                        (screen.WorkingArea.Height) / Scale);
                    lb2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    lb2.BackColor = Color.Blue;
                    panel1.Controls.Add(lb2);


                }

            }

            var cnt = WinApi._wpd.Count() - 1;

            for (int i = cnt; i >= 0; i--)
            {
                WinApi._st_WinPosData item = WinApi._wpd[i];
                //WinApi._DrawRect(Color.Red, item._wi.rcWindow);
                //WinApi._DrawRect(Color.Blue, item._wi.rcClient);
                RECT vrect = new RECT();
                RECT orect = new RECT();
                vrect = ViewRect(item._wi,ref orect);
                // WinApi._DrawRect(Color.Yellow, vrect);

                System.Windows.Forms.Label lb = new System.Windows.Forms.Label();
                lb.Text = $"{i} {item.title}";
                lb.AutoSize = false;
                lb.Location = new Point(vrect.left / Scale, (vrect.top) / Scale);
                lb.Size = new Size((vrect.right - vrect.left) / Scale,
                                   (vrect.bottom - vrect.top) / Scale);


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

            Program.LoadSet( path );

            PSWin_Shown(sender, e);

        }

        private void PSWin_Activated(object sender, EventArgs e)
        {
            PSWin_Shown(sender, e);
        }

        private void Mnu_Tile_Click(object sender, EventArgs e)
        {
            int tx = 0;
            int ty = 0;
            IntPtr whnd = IntPtr.Zero;
            for ( int i=0; i < WinApi._wpd.Count;i++ )
            {
                WinApi._st_WinPosData item = WinApi._wpd[i];
                if (this.Handle != item.whnd)
                {
                    RECT orect = new RECT();
                    RECT vrect = new RECT();
                    RECT wrect = new RECT();
                    vrect = ViewRect(item._wi, ref orect);
                    int w = vrect.right - vrect.left;
                    int h = vrect.bottom - vrect.top;
                    vrect.left = tx;
                    vrect.top = ty;
                    vrect.right = vrect.left + w;
                    vrect.bottom = vrect.top + h;
                    wrect = View2WindowRect(vrect, orect);

                    var ret = WinApi.SetWindowPos(item.whnd , WinApi.HWND_NOTOPMOST , wrect.left, wrect.top, w, h, WinApi.SWP_SHOWWINDOW | WinApi.SWP_NOSIZE);

                    if (ret == true)
                    {
                        whnd = item.whnd;
                        WinApi.SetForegroundWindow(item.whnd);
                        Debug.Print($"{i} {item.title},{tx},{ty}");
                        tx += 50;
                        ty += 50;
                    }
                }
            }
            PSWin_Shown(sender, e);

        }
    }
}
