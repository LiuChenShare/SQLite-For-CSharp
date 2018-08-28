using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_001_UpdateMoney.Data
{
    /// <summary>
    /// 连接银行数据库
    /// （数据库是在C:\Users\admin中）
    /// </summary>
    public class BankContext : DbContext
    {
        public BankContext()
            //: base("SqliteBank")
            : base(System.Environment.CurrentDirectory + @"/Data/Bank.db")
        {
        }
        public DbSet<VaultInfo> VaultInfo { set; get; }
        //public DbSet<RecordInfo> RecordInfo { set; get; }
    }
}
