using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PSWin.WinApi;

namespace PSWin
{
    public partial class FrmWin : Form
    {
        public FrmWin()
        {
            InitializeComponent();
        }
        private WinApi._st_WinPosData item = new WinApi._st_WinPosData();
        RECT offset_wc = new RECT();
        private void FrmWin_Shown(object sender, EventArgs e)
        {
            int i = (int)this.Tag;
            item = WinApi._wpd[i];
            NUD_Left.Maximum = 10000;
            NUD_Left.Minimum = -10000;
            NUD_Left.Value = item._wi.rcClient.left;
            NUD_Top.Maximum = 10000;
            NUD_Top.Minimum = -10000;
            NUD_Top.Value = item._wi.rcClient.top;
            NUD_Width.Maximum = 10000;
            NUD_Width.Minimum = -10000;
            NUD_Width.Value = item._wi.rcClient.right - item._wi.rcClient.left;
            NUD_Height.Maximum = 10000;
            NUD_Height.Minimum = -10000;
            NUD_Height.Value = item._wi.rcClient.bottom - item._wi.rcClient.top;
            WinApi._DrawRect(Color.Red , item._wi.rcWindow);
            WinApi._DrawRect(Color.Blue, item._wi.rcClient);
            offset_wc.left = item._wi.rcWindow.left - item._wi.rcClient.left;
            offset_wc.top = item._wi.rcWindow.top - item._wi.rcClient.top;
            offset_wc.right = item._wi.rcWindow.right - item._wi.rcClient.right;
            offset_wc.bottom = item._wi.rcWindow.bottom - item._wi.rcClient.bottom;
            var lt = $"({offset_wc.left},{offset_wc.top})-({offset_wc.right},{offset_wc.bottom})";
            label1.Text = lt ;
        }

        private void Btn_Move_Click(object sender, EventArgs e)
        {
            WinApi.RECT rect = new WinApi.RECT();

            rect.left = (int)NUD_Left.Value + offset_wc.left;
            rect.top = (int)NUD_Top.Value + offset_wc.top; 
            rect.right = (int)NUD_Left.Value + (int)NUD_Width.Value + offset_wc.right ;
            rect.bottom = (int)NUD_Top.Value + (int)NUD_Height.Value + offset_wc.bottom ;

            WinApi._DrawRect(Color.Yellow, rect);
        }

        private void NUD_Height_ValueChanged(object sender, EventArgs e)
        {
        }

        private void NUD_Width_ValueChanged(object sender, EventArgs e)
        {
        }

        private void NUD_Left_ValueChanged(object sender, EventArgs e)
        {
        }

        private void NUD_Top_ValueChanged(object sender, EventArgs e)
        {
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            WinApi.RECT rect = new WinApi.RECT();

            IntPtr hwnd = item.whnd;

            Btn_Move_Click(sender, e) ;
            // rcClient to rcWindow
            rect.left = (int)NUD_Left.Value + offset_wc.left;
            rect.top = (int)NUD_Top.Value + offset_wc.top;
            rect.right = (int)NUD_Left.Value + (int)NUD_Width.Value + offset_wc.right;
            rect.bottom = (int)NUD_Top.Value + (int)NUD_Height.Value + offset_wc.bottom;

            int w = rect.right - rect.left;
            int h = rect.bottom - rect.top;

            var ret = MoveWindow(hwnd, rect.left, rect.top, w, h, true);
            this.Close();
        }
    }
}
