using Project_001_UpdateMoney.Data;
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

            SQLiteBaseForEF.ExistsDBFile(connectionString, "Bank.s3db");

            //初始一个admin账户
            using (BankContext2 context = new BankContext2())
            {
                var info = context.VaultInfo.Where(x => x.Account == "admin").FirstOrDefault();

                if(info == null)
                {
                    info = new VaultInfo
                    {
                        Id = Guid.NewGuid(),
                        Account = "admin",
                        Password = "123",
                        Name = "管理员",
                        Balance = 10000
                    };
                    context.VaultInfo.Add(info);
                    context.SaveChanges();
                }
            }

            base.OnStartup(e);
        }
    }
}
