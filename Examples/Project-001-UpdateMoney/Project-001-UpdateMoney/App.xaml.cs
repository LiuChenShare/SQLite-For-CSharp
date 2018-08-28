using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Project_001_UpdateMoney
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 重写OnStartup
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            ///
            string connectionString = AppDomain.CurrentDomain.BaseDirectory + @"Data\";
            //string connectionString = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", connectionString);

            Data.SQLiteBaseForEF.ExistsDBFile(connectionString, "Bank.s3db");

            base.OnStartup(e);
        }
    }
}
