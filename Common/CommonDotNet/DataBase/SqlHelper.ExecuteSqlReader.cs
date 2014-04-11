using System;
using System.Data;
using System.Data.Common;

namespace Common.DataBase
{
    public partial class SqlHelper
    {
        /// <summary>
        /// 针对 System.Data.IDbCommand.Connection 执行 System.Data.IDbCommand.CommandText，并生成 System.Data.IDataReader。
        /// </summary>
        /// <param name="sql">sql 语句。</param>
        /// <param name="parameters">sql 参数。</param>
        /// <returns>System.Data.IDataReader 对象。</returns>
        public static IDataReader ExecuteSqlReader(string sql, params DbParameter[] parameters)
        {
            IDbConnection conn = Activator.CreateInstance(DbProvider) as IDbConnection;
            conn.ConnectionString = ConnectionString;
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            foreach (DbParameter parameter in parameters)
            {
                cmd.Parameters.Add(parameter);
            }
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
