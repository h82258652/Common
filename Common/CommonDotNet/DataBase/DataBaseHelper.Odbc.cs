using System;
using System.Data.Common;

namespace Common.DataBase
{
    /// <summary>
    /// DataBase 帮助类。
    /// </summary>
    public partial class DataBaseHelper
    {
        private const string OdbcInvariant = "System.Data.Odbc";

        public static DbProviderFactory OdbcProviderFactory
        {
            get
            {
                try
                {
                    return DbProviderFactories.GetFactory(OdbcInvariant);
                }
                catch (ArgumentException)
                {
                    return null;
                }
            }
        }

        public static DbConnection OdbcConnection
        {
            get
            {
                return OdbcProviderFactory == null ? null : OdbcProviderFactory.CreateConnection();
            }
        }

        public static DbCommand OdbcCommand
        {
            get
            {
                return OdbcProviderFactory == null ? null : OdbcProviderFactory.CreateCommand();
            }
        }

        public static DbParameter OdbcParameter
        {
            get
            {
                return OdbcProviderFactory == null ? null : OdbcProviderFactory.CreateParameter();
            }
        }

        public static DbDataAdapter OdbcDataAdapter
        {
            get
            {
                return OdbcProviderFactory == null ? null : OdbcProviderFactory.CreateDataAdapter();
            }
        }
    }
}
