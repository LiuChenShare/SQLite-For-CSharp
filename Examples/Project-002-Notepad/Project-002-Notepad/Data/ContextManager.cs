using Project_002_Notepad.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;

namespace Project_002_Notepad.Data
{
    /// <summary>
    /// 数据连接管理器
    /// </summary>
    public class ContextManager
    {
        #region 单例
        private static volatile ContextManager instance;
        private static readonly object obj = new object();
        public static ContextManager Instance
        {
            get
            {
                if (null == instance)
                {
                    lock (obj)
                    {
                        if (null == instance)
                        {
                            instance = new ContextManager();
                        }
                    }

                }
                return instance;
            }
        }
        #endregion

        private static string basePath = System.Environment.CurrentDirectory + @"\DataFile\";

        #region 数据连接列表
        /// <summary>
        /// 记事本数据连接
        /// </summary>
        private NotepadContext notepadContext = null;
        #endregion

        public NotepadContext GetNotepadContext()
        {
            if (notepadContext == null)
            {
                var path = basePath + "notepad.qnmd";
                var connection = new SQLiteConnection($"Data Source={path};");
                if (!File.Exists(path))
                {
                    NotepadCreateDBFile(connection);
                }
                else
                {
                    NotepadUpdateDBFile(connection);
                }
                notepadContext = new NotepadContext(connection, false);
            }
            return notepadContext;
        }
        #region 数据库相关
        /// <summary>
        /// 创建记事本数据库文件(直接覆盖)
        /// </summary>
        /// <param name="fileName"></param>
        private void NotepadCreateDBFile(SQLiteConnection connection)
        {
            try
            {
                using (var context = new NotepadContext(connection, false))
                {
                    Directory.CreateDirectory(basePath);
                    //SQLiteConnection.CreateFile(path + dbName);

                    //创建记事本表
                    context.Database.ExecuteSqlCommand(@"CREATE TABLE [NotepadInfo] (
                    [Id] nvarchar  PRIMARY KEY NOT NULL,
                    [NotepadContent] nvarchar  NOT NULL,
                    [CreateTime] datetime  NOT NULL );");

                    //创建数据库版本表
                    context.Database.ExecuteSqlCommand(@"CREATE TABLE [VersionInfo] (
                    [Key] nvarchar  PRIMARY KEY NOT NULL,
                    [VersionNumber] INTEGER  NOT NULL,
                    [CreateTime] datetime  NOT NULL );");

                    var info = new VersionInfo
                    {
                        Key = "Default",
                        VersionNumber = UpdateNotepadScript.Keys.Max(),
                        CreateTime = DateTime.Now
                    };
                    context.VersionInfo.Add(info);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                var message = e.Message;
            }
        }
        /// <summary>
        /// 更新记事本数据库文件(直接覆盖)
        /// </summary>
        /// <param name="fileName"></param>
        private void NotepadUpdateDBFile(SQLiteConnection connection)
        {
            try
            {
                using (var context = new NotepadContext(connection, false))
                {
                    var defaultVersionInfo = context.VersionInfo.Where(x => x.Key == "Default").FirstOrDefault();
                    int version = defaultVersionInfo.VersionNumber;
                    int versionMax = UpdateNotepadScript.Keys.Max();
                    while (version< versionMax)
                    {
                        version += 1;
                        if (UpdateNotepadScript.ContainsKey(version))
                        {
                            //更新表结构
                            context.Database.ExecuteSqlCommand(UpdateNotepadScript[version]);
                            //更新版本号
                            defaultVersionInfo.VersionNumber = version;
                            context.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                var message = e.Message;
            }
        }
        #endregion

        #region 数据库升级脚本
        /// <summary>
        /// 记事本数据库升级脚本
        /// </summary>
        private readonly Dictionary<int, string> UpdateNotepadScript = new Dictionary<int, string>
        {
            { 0, @"--默认" },
            { 1, @"ALTER TABLE [NotepadInfo]
                ADD Test1 TEXT" },
        };
        #endregion
    }


}


