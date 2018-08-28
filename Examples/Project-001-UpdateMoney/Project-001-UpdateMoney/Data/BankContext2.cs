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
    /// （使用config文件配置数据库地址）
    /// </summary>
    public class BankContext2 : DbContext
    {
        public BankContext2()
            : base("SqliteBank")
        {
        }
        public DbSet<VaultInfo> VaultInfo { set; get; }
        public DbSet<RecordInfo> RecordInfo { set; get; }
        //public DbSet<AAA> AAA { set; get; }
    }
}
