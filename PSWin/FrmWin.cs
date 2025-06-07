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
        private RECT orect = new RECT();
        private RECT vrect = new RECT();
        private void FrmWin_Shown(object sender, EventArgs e)
        {
            int i = (int)this.Tag;
            item = WinApi._wpd[i];

            vrect = ViewRect(item._wi, ref orect);
            NUD_Left.Maximum = 10000;
            NUD_Left.Minimum = -10000;
            NUD_Left.Value = vrect.left;
            NUD_Top.Maximum = 10000;
            NUD_Top.Minimum = -10000;
            NUD_Top.Value = vrect.top;
            NUD_Width.Maximum = 10000;
            NUD_Width.Minimum = -10000;
            NUD_Width.Value = vrect.right - vrect.left;
            NUD_Height.Maximum = 10000;
            NUD_Height.Minimum = -10000;
            NUD_Height.Value = vrect.bottom - vrect.top;
            offset_wc.left = item._wi.rcWindow.left - item._wi.rcClient.left;
            offset_wc.top = item._wi.rcWindow.top ;
            offset_wc.right = item._wi.rcWindow.right - item._wi.rcClient.right;
            offset_wc.bottom = item._wi.rcWindow.bottom - item._wi.rcClient.bottom;
            var lt = $"({offset_wc.left},{offset_wc.top})-({offset_wc.right},{offset_wc.bottom})";
            label1.Text = lt ;
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

            vrect.left = (int)NUD_Left.Value;
            vrect.top = (int)NUD_Top.Value ;
            vrect.right = (int)NUD_Left.Value + (int)NUD_Width.Value ;
            vrect.bottom = (int)NUD_Top.Value + (int)NUD_Height.Value ;
            rect = View2WindowRect(vrect, orect);

            int w = rect.right - rect.left;
            int h = rect.bottom - rect.top;

            var ret = MoveWindow(hwnd, rect.left, rect.top, w, h, true);
            this.Close();
        }
    }
}
