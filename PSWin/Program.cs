using System.Diagnostics;
using System.Text;

namespace PSWin
{
    internal static class Program
    {
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
                string path = args[0];
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
                    Debug.Print(str);
                    string[] dat = str.Split('\t');
                    if (dat.Length > 0)
                    {
                        int x = int.Parse(dat[3]);
                        int y = int.Parse(dat[4]);
                        int w = int.Parse(dat[5]);
                        int h = int.Parse(dat[6]);
                        int bx = int.Parse(dat[7]);
                        int by = int.Parse(dat[8]);
                        var ret = WinApi._MoveWindows(dat[2], x, y, w, h, bx, by);
                        Debug.Print($"{ret}");

                    }
                }

                file.Close();

            }
        }
    }
}