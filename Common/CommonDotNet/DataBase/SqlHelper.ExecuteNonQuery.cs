using System.Data;
using System.Data.Common;

namespace Common.DataBase
{
    public partial class SqlHelper
    {
        /// <summary>
        /// 针对 .NET Framework 数据提供程序的 Connection 对象执行 SQL 语句，并返回受影响的行数。
        /// </summary>
        /// <param name="sql">sql 语句。</param>
        /// <param name="parameters">sql 参数。</param>
        /// <returns>受影响的行数。</returns>
        public int ExecuteNonQuery(string sql, params  DbParameter[] parameters)
        {
            if (this._connection.State != ConnectionState.Open)
            {
                this._connection.ConnectionString = this._connString;
                this._connection.Open();
            }
            using (IDbCommand cmd = this._connection.CreateCommand())
            {
                cmd.CommandText = sql;
                foreach (DbParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
