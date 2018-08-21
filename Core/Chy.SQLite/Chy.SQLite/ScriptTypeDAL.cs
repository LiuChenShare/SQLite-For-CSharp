using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace Chy.SQLite
{
    public class ScriptTypeDAL
    {
        public ScriptTypeM ToScriptType(DataRow row)
        {
            ScriptTypeM type = new ScriptTypeM();
            type.ScriptTypeId = (Guid)row["ScriptTypeId"];
            type.ScriptType = (string)row["ScriptType"];
            type.IsUsing = (bool)row["IsUsing"];
            return type;
        }

        public void Insert(ScriptTypeM Type)
        {
            SQLiteHelper.ExecuteNonQuery(@"insert into TB_ScriptType(ScriptTypeId,ScriptType,IsUsing)
                                           Values(@ScriptTypeId,@ScriptType,1)",
                                           new SQLiteParameter("ScriptTypeId", Type.ScriptTypeId),
                                           new SQLiteParameter("ScriptType", Type.ScriptType));

        }

        public void Update(ScriptTypeM Type)
        {
            SQLiteHelper.ExecuteNonQuery(@"update TB_ScriptType set ScriptType=@ScriptType,
                                           IsUsing=@IsUsing where ScriptTypeId=@ScriptTypeId",
                                           new SQLiteParameter("ScriptType", Type.ScriptType),
                                           new SQLiteParameter("IsUsing", Type.IsUsing),
                                           new SQLiteParameter("ScriptTypeId", Type.ScriptTypeId));
        }

        public ScriptTypeM GetbyId(Guid id)
        {
            DataTable table = SQLiteHelper.GetDataTable("select * from TB_ScriptType where ScriptTypeId=@id",
                                                        new SQLiteParameter("id", id));
            if (table.Rows.Count <= 0)
            {
                return null;
            }
            else if (table.Rows.Count > 1)
            {
                throw new Exception("Id重复！");
            }
            else
            {
                return ToScriptType(table.Rows[0]);
            }
        }

        public ScriptTypeM GetbyName(string name)
        {
            DataTable table = SQLiteHelper.GetDataTable("select * from TB_ScriptType where ScriptType=@name",
                                                        new SQLiteParameter("name", name));
            if (table.Rows.Count <= 0)
            {
                return null;
            }
            else if (table.Rows.Count > 1)
            {
                throw new Exception("类型名称重复！");
            }
            else
            {
                return ToScriptType(table.Rows[0]);
            }
        }

        public ScriptTypeM[] ListAll()
        {
            DataTable table = SQLiteHelper.GetDataTable("select * from TB_ScriptType where IsUsing=1");
            ScriptTypeM[] type = new ScriptTypeM[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                type[i] = ToScriptType(table.Rows[i]);
            }
            return type;
        }

        public ScriptTypeM[] Search(string sql, List<SQLiteParameter> parameterList)
        {
            DataTable table = SQLiteHelper.GetDataTable(sql, parameterList.ToArray());
            ScriptTypeM[] type = new ScriptTypeM[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                type[i] = ToScriptType(table.Rows[i]);
            }
            return type;
        }
    }
}
