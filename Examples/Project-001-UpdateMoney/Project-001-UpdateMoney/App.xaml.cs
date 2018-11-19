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

                //var upList = context.RecordInfo.Where(x => x.Remark == "测试").ToList();
                //for (int i = 0; i < 5; i++)
                //{
                //    var recordinfo = new RecordInfo
                //    {
                //        Id = Guid.Empty,
                //        AccountId = Guid.Empty,
                //        Amount = 0,
                //        Remark = "测试",
                //        CreateTime = DateTime.Now
                //    };
                //    upList.Add(recordinfo);
                //}

                //foreach(var item in upList)
                //{
                //    if(item.Id == Guid.Empty)
                //    {
                //        item.Id = Guid.NewGuid();
                //        context.RecordInfo.Add(item);
                //    }
                //    else
                //    {
                //        item.Remark = "测试";
                //        context.RecordInfo.Attach(item);
                //        context.Entry(info).State = System.Data.Entity.EntityState.Modified;
                //    }
                //}
                //context.SaveChanges();

                //var recordinfo = new RecordInfo
                //{
                //    Id = Guid.NewGuid(),
                //    AccountId = Guid.Empty,
                //    Amount = 1,
                //    Remark = "存钱",
                //    CreateTime = DateTime.Now
                //};
            }

            base.OnStartup(e);
        }
    }
}
