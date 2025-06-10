using System.Diagnostics;
using System.IO;
using System.Text;

namespace PSWin
{
    internal static class Program
    {
        public static Boolean LoadSet(string path)
        {
            // ファイルを開く＆文字化け防止
            StreamReader file = new StreamReader(path, Encoding.GetEncoding("UTF-8"));
            if (file == null)
            {
                Console.WriteLine("ファイルを開けませんでした。");
                return(false);
            }

            // 行末まで１行ずつ読み込む
            IntPtr hWndInsertAfter = IntPtr.Zero;
            while (file.Peek() != -1)
            {
                var str = file.ReadLine();
                // Debug.Print(str);
                string[] dat = str.Split('\t');
                if (dat.Length > 0)
                {
                    int x = int.Parse(dat[3]);
                    int y = int.Parse(dat[4]);
                    int w = int.Parse(dat[5]) - x;
                    int h = int.Parse(dat[6]) - y;
                    IntPtr hwnd = WinApi._FindWindow(null, dat[2]);
                    if (hwnd != IntPtr.Zero)
                    {
                        var ret = WinApi.SetWindowPos(hwnd, hWndInsertAfter, x, y, w, h, WinApi.SWP_SHOWWINDOW | WinApi.SWP_NOACTIVATE);
                        Debug.Print($"{ret} {dat[2]}");
                        hWndInsertAfter = hwnd;
                    }
                }
            }
            file.Close();
            return(true);
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            if (args.Length == 0)
            {
                Application.Run(new PSWin());
            }
            else
            {
                LoadSet(args[0]);
            }
        }
    }
}