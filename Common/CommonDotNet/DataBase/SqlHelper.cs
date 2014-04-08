using System;
using System.Data;

namespace Common.DataBase
{
    /// <summary>
    /// sql 帮助类。
    /// </summary>
    public static partial class SqlHelper
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
    }
}
