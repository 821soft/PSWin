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
            NUD_Right.Maximum = 10000;
            NUD_Right.Minimum = -10000;
            NUD_Right.Value = item._wi.rcClient.right;
            NUD_Bottom.Maximum = 10000;
            NUD_Bottom.Minimum = -10000;
            NUD_Bottom.Value = item._wi.rcClient.bottom;
        }

        private void Btn_Move_Click(object sender, EventArgs e)
        {
            WinApi.RECT rect = new WinApi.RECT();

            IntPtr hwnd = item.whnd;

            if ((item._wi.dwStyle & 0x06000000) == 0x06000000)
            {
                rect.top = (int)NUD_Top.Value;
                rect.left = (int)NUD_Left.Value - (int)item._wi.cxWindowBorders;
                rect.bottom = (int)NUD_Bottom.Value + (int)item._wi.cyWindowBorders;
                rect.right = (int)NUD_Right.Value + (int)item._wi.cxWindowBorders;
                int w = rect.right - rect.left;
                int h = rect.bottom - rect.top;

                var ret  = MoveWindow(hwnd, rect.left, rect.top, w, h, true);

            }
            else if ((item._wi.dwStyle & 0x04000000) == 0x04000000)
            {
                rect.top = (int)NUD_Top.Value - (int)item._wi.cyWindowBorders;
                rect.left = (int)NUD_Left.Value - (int)item._wi.cxWindowBorders;
                rect.bottom = (int)NUD_Bottom.Value + (int)item._wi.cyWindowBorders;
                rect.right = (int)NUD_Right.Value + (int)item._wi.cxWindowBorders;
                int w = rect.right - rect.left;
                int h = rect.bottom - rect.top;

                var ret = MoveWindow(hwnd, rect.left, rect.top, w, h, true);
            }
        }

        private void NUD_Height_ValueChanged(object sender, EventArgs e)
        {
            NUD_Bottom.Value = NUD_Top.Value + NUD_Height.Value;
        }

        private void NUD_Width_ValueChanged(object sender, EventArgs e)
        {
            NUD_Right.Value = NUD_Left.Value + NUD_Width.Value;
        }

        private void NUD_Left_ValueChanged(object sender, EventArgs e)
        {
            NUD_Right.Value = NUD_Left.Value + NUD_Width.Value;
        }

        private void NUD_Top_ValueChanged(object sender, EventArgs e)
        {
            NUD_Bottom.Value = NUD_Top.Value + NUD_Height.Value;
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            Btn_Move_Click(sender, e) ;
            this.Close();
        }
    }
}
