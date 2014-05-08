using System;
using System.Data.Common;

namespace Common.DataBase
{
    public partial class DataBaseHelper
    {
        private const string SqlServerInvariant = "System.Data.SqlClient";

        /// <summary>
        /// 返回 System.Data.Common.DbProviderFactory 的一个实例。
        /// </summary>
        public static DbProviderFactory SqlServerProviderFactory
        {
            get
            {
                try
                {
                    return DbProviderFactories.GetFactory(SqlServerInvariant);
                }
                catch (ArgumentException)
                {
                    return null;
                }
            }
        }

        public static DbConnection SqlServerConnection
        {
            get
            {
                return SqlServerProviderFactory == null ? null : SqlServerProviderFactory.CreateConnection();
            }
        }

        public static DbCommand SqlServerCommand
        {
            get
            {
                return SqlServerProviderFactory == null ? null : SqlServerProviderFactory.CreateCommand();
            }
        }

        public static DbParameter SqlServerParameter
        {
            get
            {
                return SqlServerProviderFactory == null ? null : SqlServerProviderFactory.CreateParameter();
            }
        }

        public static DbDataAdapter SqlServerDataAdapter
        {
            get
            {
                return SqlServerProviderFactory == null ? null : SqlServerProviderFactory.CreateDataAdapter();
            }
        }
    }
}
