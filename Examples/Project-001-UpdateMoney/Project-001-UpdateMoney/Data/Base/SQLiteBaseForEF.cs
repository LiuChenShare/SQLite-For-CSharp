using Chy.SQLite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_001_UpdateMoney.Data
{
    /// <summary>
    /// SQlite数据基础(EF)
    /// </summary>
    public static class SQLiteBaseForEF
    {
        private static string path = System.Environment.CurrentDirectory + @"\Data\";
        private static string dbName = "Bank.s3db";

        /// <summary>
        /// 查找并创建SQLite数据文件
        /// </summary>
        /// <returns></returns>
        public static bool ExistsDBFile(string connectionString = null, string dbNameString = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(connectionString))
                {
                    path = connectionString;
                }
                if (!string.IsNullOrEmpty(dbNameString))
                {
                    dbName = dbNameString;
                }
                if (!Directory.Exists(path + dbName))
                {
                    return CreateDBFile();
                }
                return true;
            }
            catch (Exception e)
            {
                var message = e.Message;
                return false;
            }
        }

        /// <summary>
        /// 创建数据库文件(直接覆盖)
        /// </summary>
        /// <param name="fileName"></param>
        public static bool CreateDBFile()
        {
            try
            {
                using (BankContext2 context = new BankContext2())
                {
                    Directory.CreateDirectory(path);
                    //SQLiteConnection.CreateFile(path + dbName);

                    //创建银行账户表
                    context.Database.ExecuteSqlCommand(@"CREATE TABLE [Vault] (
                    [Id] BLOB  NOT NULL PRIMARY KEY,
                    [Account] TEXT  NOT NULL,
                    [Password] TEXT  NOT NULL,
                    [Name] TEXT  NOT NULL,
                    [Balance] FLOAT DEFAULT '0' NOT NULL )");

                    //创建存取款记录表
                    context.Database.ExecuteSqlCommand(@"CREATE TABLE [Record] (
                    [Id] BLOB  PRIMARY KEY NOT NULL,
                    [AccountId] BLOB  NOT NULL,
                    [Amount] FLOAT  NOT NULL,
                    [Balance] FLOAT  NOT NULL,
                    [Remark] TEXT  NULL,
                    [CreateTime] DATE  NOT NULL )");
                    return true;
                }
            }
            catch (Exception e)
            {
                var message = e.Message;
                return false;
            }
        }
    }
}
