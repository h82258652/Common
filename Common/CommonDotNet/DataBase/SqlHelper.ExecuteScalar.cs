using System.Data;
using System.Data.Common;

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
        public object ExecuteScalar(string sql, params DbParameter[] parameters)
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
                return cmd.ExecuteScalar();
            }
        }
    }
}
