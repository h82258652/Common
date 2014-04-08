using System;
using System.Data;
using System.Data.Common;

namespace Common.DataBase
{
    public static partial class SqlHelper
    {
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。 忽略额外的列或行。
        /// </summary>
        /// <param name="sql">sql 语句。</param>
        /// <param name="parameters">sql 参数。</param>
        /// <returns>结果集中第一行的第一列。</returns>
        public static object ExecuteScalar(string sql, params DbParameter[] parameters)
        {
            using (IDbConnection conn = Activator.CreateInstance(DbProvider) as IDbConnection)
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    foreach (DbParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
