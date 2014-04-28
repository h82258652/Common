using System.Data.Common;

namespace Common.DataBase
{
    public partial class DataBaseHelper
    {
        private const string SqlServerInvariant = "System.Data.SqlClient";

        public static DbProviderFactory SqlServerProviderFactory
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
                return SqlServerProviderFactory.CreateConnection();
            }
        }

        public static DbCommand SqlServerCommand
        {
            get
            {
                return SqlServerProviderFactory.CreateCommand();
            }
        }

        public static DbParameter SqlServerParameter
        {
            get
            {
                return SqlServerProviderFactory.CreateParameter();
            }
        }

        public static DbDataAdapter SqlServerDataAdapter
        {
            get
            {
                return SqlServerProviderFactory.CreateDataAdapter();
            }
        }
    }
}
