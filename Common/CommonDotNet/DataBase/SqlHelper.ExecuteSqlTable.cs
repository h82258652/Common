using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Common.DataBase
{
    public partial class SqlHelper
    {
        /// <summary>
        /// 执行 sql 语句并返回一个数据表。
        /// </summary>
        /// <param name="sql">sql 语句。</param>
        /// <param name="parameters">sql 语句参数。</param>
        /// <returns>数据表。</returns>
        public static DataTable ExecuteSqlTable(string sql, params DbParameter[] parameters)
        {
            using (IDataReader reader = ExecuteSqlReader(sql, parameters))
            {
                DataTable table = new DataTable();
                table.Load(reader);
                return table;
            }
        }
    }
}
