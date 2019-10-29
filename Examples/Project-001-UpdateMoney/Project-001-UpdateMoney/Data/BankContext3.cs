using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Project_001_UpdateMoney.Data
{
    /// <summary>
    /// 连接银行数据库
    /// （使用字符串配置数据库地址）
    /// </summary>
    public class BankContext3 : DbContext
    {

        //使用自定义连接串（未成功）
        private static string GetEFConnctionString()
        {
            //string connString = "metadata=res://*/EFModel_FromDb.csdl|res://*/EFModel_FromDb.ssdl|res://*/EFModel_FromDb.msl;provider=System.Data.SqlClient;provider connection string=\"data source=localhost;initial catalog=leadmw2_ef;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework\"";
            //string enString = SecurityHelper.DESEncrypt(connString);
            //string enString = "4AA347EFAA33B94A6E197901484E3104608AB02A9E246BB73B0EB205881B7EE7B314D698E61A418E1F5619CFE648CC1E84F7E5BA7B450D5B396FA2D25EC7F93467DE6CF72CDD682EEF92DBC30A72A28416CC0328C39A6A8E5990E448D136D11FE42B9118C9A1039479504C92B75F0B9535A92F76E4705C31D33C9622517404DA585C2E9A1D8133B3971E1AB2FA64D5AF39BDC1D8852A2EA1E3F46C10FB3FDD058BDA0C1A8D52C5272866884F209D8113A8B5FC3D85625D202D2364C79FAC9E8C85C550743EF616EE3772EE55C06A5C11B968A4EF7193DD88F7E7B7984FD83067DE9B10967B31DE7B7352604F9FC65BA9720CD9D058DE28ECD269AB53D4F91004629BAE43BD184B762C202000CC9E62DB7D15BC77D1821FA3";


            //这里暂时先不读config的信息
            //string enString = System.Configuration.ConfigurationManager.AppSettings["customConnString"];
            //string connString = SecurityHelper.DESDecrypt(enString);        //这句应该是解密的
            //return connString;

            var str = string.Format("Data Source={0}\\Bank.s3db", System.Environment.CurrentDirectory + "\\Data");    //E:\GitHub\LiuChenShare\SQLite-For-CSharp\Examples\Project-001-UpdateMoney\Project-001-UpdateMoney\bin\Debug\Data
            return str;
        }
        public BankContext3()
            : base(GetEFConnctionString())
        {
        }




        public DbSet<VaultInfo> VaultInfo { set; get; }
        public DbSet<RecordInfo> RecordInfo { set; get; }
        //public DbSet<AAA> AAA { set; get; }
    }
}
