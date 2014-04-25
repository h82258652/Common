
namespace System.Data.Common
{
    /// <summary>
    /// DbProviderFactory 扩展类。
    /// </summary>
    public static partial class DbProviderFactoryExtension
    {
        /// <summary>
        /// 返回实现 System.Data.Common.DbConnection 类的提供程序的类的一个新实例并设置连接字符串。
        /// </summary>
        /// <param name="factory">DbProviderFactory 实例。</param>
        /// <param name="connectionString">用于打开数据库的连接。</param>
        /// <returns>System.Data.Common.DbConnection 的新实例。</returns>
        public static DbConnection CreateConnection(this DbProviderFactory factory, string connectionString)
        {
            DbConnection connection = factory.CreateConnection();
            if (connection != null)
            {
                connection.ConnectionString = connectionString;
            }
            return connection;
        }
    }
}
