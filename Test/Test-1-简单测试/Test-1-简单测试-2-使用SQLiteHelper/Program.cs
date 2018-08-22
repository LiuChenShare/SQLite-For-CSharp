using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Test_1_简单测试_2_使用SQLiteHelper
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Chy.SQLite.SQLiteHelper.CreateDBFile("CCC");
        }
    }
}
