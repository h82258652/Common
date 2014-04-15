using System;
using System.Data;

namespace Common.DataBase
{
    /// <summary>
    /// sql 帮助类。
    /// </summary>
    public partial class SqlHelper : IDisposable
    {
        private static Type _dbProvider;

        /// <summary>
        /// 设置或获取连接字符串。
        /// </summary>
        public static string ConnectionString
        {
            get;
            set;
        }

        /// <summary>
        /// 设置或获取数据库连接类。
        /// </summary>
        public static Type DbProvider
        {
            get
            {
                return _dbProvider;
            }
            set
            {
                if (typeof(IDbConnection).IsAssignableFrom(value) == true)
                {
                    _dbProvider = value;
                }
                else
                {
                    throw new ArgumentException("DbProvider 必须实现 IDbConnection 接口。");
                }
            }
        }

        private string _connString;
        private IDbConnection _connection;

        /// <summary>
        /// 创建一个 SqlHelper 实例。
        /// </summary>
        /// <param name="connection">数据库连接。</param>
        public SqlHelper(IDbConnection connection)
        {
            this._connString = connection.ConnectionString;
            this._connection = connection;
        }

        /// <summary>
        /// 创建一个 SqlHelper 实例。
        /// </summary>
        /// <param name="connectionString">连接字符串。</param>
        /// <param name="provider">数据库连接类。</param>
        public SqlHelper(string connectionString, Type provider)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException("connectionString");
            }
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            if (connectionString.Length == 0)
            {
                throw new ArgumentException("连接字符串不能为空字符串。", "connectionString");
            }
            if (typeof(IDbConnection).IsAssignableFrom(provider) == false)
            {
                throw new ArgumentException("Provider 必须实现 IDbConnection 接口。");
            }
            this._connString = connectionString;
            this._connection = (IDbConnection)Activator.CreateInstance(provider);
        }

        /// <summary>
        /// 释放当前 SqlHelper 的数据库连接。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        ~SqlHelper()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                if (this._connection != null)
                {
                    this._connection.Dispose();
                    this._connection = null;
                }
            }
        }
    }
}
