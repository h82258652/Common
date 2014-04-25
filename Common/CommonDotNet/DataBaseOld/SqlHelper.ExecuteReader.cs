using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

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
        [SuppressMessage("Microsoft.Security", "CA2100")]
        public IDataReader ExecuteReader(string sql, params DbParameter[] parameters)
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
                return cmd.ExecuteReader();
            }
        }
    }
}
