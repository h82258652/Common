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
                return DbProviderFactories.GetFactory(OdbcInvariant);
            }
        }

        public static DbConnection OdbcConnection
        {
            get
            {
                return OdbcProviderFactory.CreateConnection();
            }
        }

        public static DbCommand OdbcCommand
        {
            get
            {
                return OdbcProviderFactory.CreateCommand();
            }
        }

        public static DbParameter OdbcParameter
        {
            get
            {
                return OdbcProviderFactory.CreateParameter();
            }
        }

        public static DbDataAdapter OdbcDataAdapter
        {
            get
            {
                return OdbcProviderFactory.CreateDataAdapter();
            }
        }
    }
}
