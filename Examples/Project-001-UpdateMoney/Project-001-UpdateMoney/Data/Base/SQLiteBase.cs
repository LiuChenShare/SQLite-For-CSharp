using Chy.SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_001_UpdateMoney.Data
{
    /// <summary>
    /// SQlite数据基础
    /// </summary>
    public static class SQLiteBase
    {
        /// <summary>
        /// 查找SQLite数据文件
        /// </summary>
        /// <returns></returns>
        public static bool ExistsDBFile()
        {
            try
            {
                string path = System.Environment.CurrentDirectory + @"/Data/";
                string databaseFileName = path + "Record.db";
                if (!SQLiteHelper.ExistsDBFile(databaseFileName))
                {
                    return CreateDBFile();
                }
                return true;
            }
            catch (Exception e)
            {
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
                string path = System.Environment.CurrentDirectory + @"/Data/";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string databaseFileName = path + "Record.db";
                SQLiteHelper.CreateDBFile(databaseFileName);
                Create();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 创建表数据
        /// </summary>
        private static void Create()
        {
            BankContext context = new BankContext();
            //创建银行账户
            SQLiteHelper.ExecuteNonQuery(@"CREATE TABLE [Vault] (
                [Id] BLOB  NOT NULL PRIMARY KEY,sss
                [Account] TEXT  NOT NULL,
                [Password] TEXT  NOT NULL,
                [Name] TEXT  NOT NULL,
                [Balance] FLOAT DEFAULT '0' NOT NULL )");
            //创建存取款记录表
            SQLiteHelper.ExecuteNonQuery(@"CREATE TABLE [Record] (
                [Id] BLOB  PRIMARY KEY NOT NULL,
                [AccountId] BLOB  NOT NULL,
                [Amount] FLOAT  NOT NULL,
                [Balance] FLOAT  NOT NULL,
                [Remark] TEXT  NULL,
                [CreateTime] DATE  NOT NULL )");
        }
    }
}
