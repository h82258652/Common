using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace Common.DataBase
{
    public partial class SqlHelper
    {
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。 忽略额外的列或行。
        /// </summary>
        /// <param name="sql">sql 语句。</param>
        /// <param name="parameters">sql 参数。</param>
        /// <returns>结果集中第一行的第一列。</returns>
        [SuppressMessage("Microsoft.Security", "CA2100")]
        public static object ExecuteSqlScalar(string sql, params DbParameter[] parameters)
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
