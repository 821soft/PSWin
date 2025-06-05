using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Diagnostics;

namespace PSWin
{
    public static class WinApi
    {

        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWINFO
        {
            public int cbSize;
            public RECT rcWindow;
            public RECT rcClient;
            public uint dwStyle;
            public uint dwExStyle;
            public uint dwWindowStatus;
            public uint cxWindowBorders;
            public uint cyWindowBorders;
            public short atomWindowType;
            public short wCreatorVersion;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        public const int SWP_NOSIZE = 0x0001;//現在のサイズを保持（cx,cyパラメーターを無視）。
        public const int SWP_NOMOVE = 0x0002;//現在位置を保持（X,Yパラメーターを無視）。
        public const int SWP_NOZORDER = 0x0004;
        public const int SWP_NOACTIVATE = 0x0010 ;
        public const int SWP_SHOWWINDOW = 0x0040;
        public const int SWP_ASYNCWINDOWPOS = 0x4000;

        public const int HWND_BOTTOM = 1;
        public const int HWND_NOTOPMOST = -2;
        public const int HWND_TOP = 0;
        public const int HWND_TOPMOST = -1;

        [DllImport("USER32.DLL", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetDesktopWindow();

        public const uint GW_CHILD = 5;
        public const uint GW_ENABLEDPOPUP = 6;
        public const uint GW_HWNDFIRST = 0;
        public const uint GW_HWNDLAST = 1;
        public const uint GW_HWNDNEXT = 2;
        public const uint GW_HWNDPREV = 3;
        public const uint GW_OWNER = 5;
        [DllImport("USER32.DLL", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindow(IntPtr HWND , uint uCmd);

        [DllImport("USER32.DLL", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetNextWindow(IntPtr HWND, uint uCmd);

        [DllImport("USER32.DLL", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int length);

        public const uint WS_BORDER = 0x00800000;
        public const uint WS_CAPTION = 0x00C00000;
        public const uint WS_CHILD = 0x40000000;
        public const uint WS_CHILDWINDOW = 0x40000000;
        public const uint WS_CLIPCHILDREN = 0x02000000;
        public const uint WS_CLIPSIBLINGS = 0x04000000;
        public const uint WS_DISABLED = 0x08000000;
        public const uint WS_DLGFRAME = 0x00400000;
        public const uint WS_GROUP = 0x00020000;
        public const uint WS_HSCROLL = 0x00100000;
        public const uint WS_ICONIC = 0x20000000;
        public const uint WS_MAXIMIZE = 0x01000000;
        public const uint WS_MAXIMIZEBOX = 0x00010000;
        public const uint WS_MINIMIZE = 0x20000000;
        public const uint WS_MINIMIZEBOX = 0x00020000;
        public const uint WS_OVERLAPPED = 0x00000000;
        public const uint WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX);
        public const uint WS_POPUP = 0x80000000;
        public const uint WS_POPUPWINDOW = (WS_POPUP | WS_BORDER | WS_SYSMENU);
        public const uint WS_SIZEBOX = 0x00040000;
        public const uint WS_SYSMENU = 0x00080000;
        public const uint WS_TABSTOP = 0x00010000;
        public const uint WS_THICKFRAME = 0x00040000;
        public const uint WS_TILED = 0x00000000;
        public const uint WS_TILEDWINDOW = (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX);
        public const uint WS_VISIBLE = 0x10000000;
        public const uint WS_VSCROLL = 0x00200000;

        public struct _st_WinPosData
        {
            public IntPtr whnd;
            public uint dwstyle;
            public string title;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public int bx;
            public int by;
            public WINDOWINFO _wi;
        }

        [DllImport("user32.dll")]
        public static extern bool GetWindowInfo(IntPtr hwnd, ref WINDOWINFO pwi);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd,int x,int y,int nWidth,int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public extern static bool EnumWindows(EnumWindowsDelegate lpEnumFunc, IntPtr lparam);

        [DllImport("USER32.DLL")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("USER32.DLL")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindowEx(IntPtr parentWnd, IntPtr previousWnd, string className, string windowText);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("User32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);


        public static List<_st_WinPosData> _wpd = new List<_st_WinPosData>();
        public static List<_st_WinPosData> _wpd_stor = new List<_st_WinPosData>();

        public static int _WinPosDataFindTitleIndex(string title)
        {
            int index = -1;
            foreach (var item in _wpd)
            {
                if(item.title.Equals(title))
                {
                    return( index );
                }
                index++;
            }
            return (index);
        }

        public static void _WinPosData_store()
        {
            _wpd_stor.Clear();
            foreach (_st_WinPosData item in WinApi._wpd)
            {
                _wpd_stor.Add(item);
            }
        }

        public static Boolean _WinPosData_comp()
        {
            _st_WinPosData a = new _st_WinPosData();
            _st_WinPosData b = new _st_WinPosData();
            if ( _wpd.Count != _wpd_stor.Count )
            {
                return ( true );
            }

            for ( int i = 0; i< _wpd_stor.Count;i++)
            {
                a = _wpd[i];
                b = _wpd_stor[i];

                string e = "";
                if ( a.title != b.title) { e += $"{a.title} {b.title} ";}
                if (a.dwstyle != b.dwstyle) { e += $"style {a.dwstyle:x8} {b.dwstyle:x8} "; }
                if (a.whnd != b.whnd) { e += $"whnd {a.whnd:x8} {b.whnd:x8} "; }
                if (a.x != b.x) { e += $"x {a.x:d} {b.x:d} "; }
                if (a.y != b.y) { e += $"y {a.y:d} {b.y:d} "; } 
                if (a.cx != b.cx) { e += $"cx {a.cx:d} {b.cx:d} "; }
                if (a.cy != b.cy) { e += $"cy {a.cy:d} {b.cy:d} "; }
                if ( e.Length > 1 )
                {
                    Debug.Print($"{i} {e} {b.title}" );
                    return (true);
                }
            }

            return (false);
        }

        public static void _WinPosData()
        {
            WinApi._WinPosData_store();
            IntPtr w = WinApi.GetDesktopWindow();
            WinApi.WINDOWINFO _wi = new WinApi.WINDOWINFO();

            WinApi._wpd.Clear();
            w = WinApi.GetWindow(w, WinApi.GW_CHILD);
            WinApi.GetWindowInfo(w, ref _wi);

            while (w != IntPtr.Zero)
            {
                if ((_wi.dwStyle & WinApi.WS_VISIBLE) != 0)
                {
                    // if ( ((_wi.dwStyle & WinApi.WS_TABSTOP) != 0) && (_wi.dwStyle & WinApi.WS_ICONIC) == 0) 
                    if ( ((_wi.dwStyle & 0x80000000) != 0x80000000) && ((_wi.dwStyle & 0x50000000) != 0x50000000) && ((_wi.dwStyle & 0x30000000) != 0x30000000))
                    {
                        _st_WinPosData wpd_rec = new _st_WinPosData();
                        wpd_rec.whnd = w;
                        wpd_rec.dwstyle = _wi.dwStyle;
                        wpd_rec.x = _wi.rcWindow.left;// + (int)_wi.cxWindowBorders;
                        wpd_rec.y = _wi.rcWindow.top;// + (int)_wi.cyWindowBorders;
                        wpd_rec.cx = _wi.rcWindow.right - _wi.rcWindow.left;// - ((int)_wi.cxWindowBorders*2);
                        wpd_rec.cy = _wi.rcWindow.bottom - _wi.rcWindow.top;// - ((int)_wi.cyWindowBorders*2); ;
                        wpd_rec.bx = (int)_wi.cxWindowBorders ;
                        wpd_rec.by = (int)_wi.cyWindowBorders;
                        int l = WinApi.GetWindowTextLength(w);
                        StringBuilder tsb = new StringBuilder(l + 1);
                        WinApi.GetWindowText(w, tsb, tsb.Capacity);
                        wpd_rec.title = tsb.ToString();
                        wpd_rec._wi = _wi;
                        _wpd.Add(wpd_rec);
                    }
                }
                w = WinApi.GetWindow(w, WinApi.GW_HWNDNEXT);
                WinApi.GetWindowInfo(w, ref _wi);
            }
        }

        public static IntPtr _FindWindow(string class_name, string window_name)
        {
            IntPtr hWnd = IntPtr.Zero;
            while (IntPtr.Zero != (hWnd = FindWindowEx(IntPtr.Zero, hWnd, class_name, window_name)))
            {
                return (hWnd);
            }

            return (IntPtr.Zero);
        }
        /*
         * (-11, 0)-(1197, 752) 1208x752
         */
        public static Boolean _MoveWindows(string title,int x ,int y,int w,int h)
        {
            IntPtr hwnd = IntPtr.Zero;
            bool ret = false;

            hwnd = _FindWindow(null,title);
            ret = MoveWindow(hwnd, x, y, w, h,true);
            return (ret);
        }
        public static Boolean _DrawRect(Color c , RECT rect)
        {

            IntPtr desktopDC = GetDC(IntPtr.Zero);
            using (Graphics g = Graphics.FromHdc(desktopDC))
            {
                Pen p = new Pen(c);
                g.DrawRectangle(p,rect.left,rect.top,rect.right-rect.left,rect.bottom-rect.top);
            }
            return (false);
        }


    }


    public delegate bool EnumWindowsDelegate(IntPtr hWnd, IntPtr lparam);


    /// <summary>
    /// キーボードをシミュレート
    /// </summary>
    class KeyboardEmulate
    {
        /// <summary>
        /// 現在選択されているウィンドウに対してキーを送信
        /// </summary>
        /// <param name="keys">送信するキー</param>
        public void writeKeys(string keys)
        {
            // 選択しているウィンドウを取得
            IntPtr targetWindowHandle = WinApi.GetForegroundWindow();
            if (targetWindowHandle == IntPtr.Zero)
            {
                // 操作できるウィンドウがない
                return;
            }

            // 現在選択しているウィンドウに対してキーを送信
            SendKeys.Send(keys+ "~");
//            // タイプ後にENTERを送信
//            SendKeys.Send("{ENTER}");
        }
    }
}
