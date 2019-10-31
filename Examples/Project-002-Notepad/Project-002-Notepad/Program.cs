using Project_002_Notepad.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_002_Notepad
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

            Task.Factory.StartNew(() =>
            {
                NotepadInfoRepository notepadInfoRepository = new NotepadInfoRepository();
                var infos = notepadInfoRepository.GetInfos();
            });

            Application.Run(new Form1());
        }
    }
}
