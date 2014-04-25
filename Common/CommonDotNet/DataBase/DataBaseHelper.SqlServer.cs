using System.Data.Common;

namespace Common.DataBase
{
    public partial class DataBaseHelper
    {
        private const string SqlServerInvariant = "System.Data.SqlClient";

        public static DbProviderFactory SqlServerDbProviderFactory
        {
            get
            {
                return DbProviderFactories.GetFactory(SqlServerInvariant);
            }
        }

        public static DbConnection SqlServerConnection
        {
            get
            {
                return SqlServerDbProviderFactory.CreateConnection();
            }
        }

        public static DbCommand SqlServerCommand
        {
            get
            {
                return SqlServerDbProviderFactory.CreateCommand();
            }
        }

        public static DbParameter SqlServerParameter
        {
            get
            {
                return SqlServerDbProviderFactory.CreateParameter();
            }
        }

        public static DbDataAdapter SqlServerDataAdapter
        {
            get
            {
                return SqlServerDbProviderFactory.CreateDataAdapter();
            }
        }
    }
}
