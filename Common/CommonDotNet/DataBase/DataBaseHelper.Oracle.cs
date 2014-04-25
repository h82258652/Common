using System.Data.Common;

namespace Common.DataBase
{
    public partial class DataBaseHelper
    {
        private const string OracleInvariant = "System.Data.OracleClient";

        public static DbProviderFactory OracleProviderFactory
        {
            get
            {
                return DbProviderFactories.GetFactory(OracleInvariant);
            }
        }

        public static DbConnection OracleConnection
        {
            get
            {
                return OracleProviderFactory.CreateConnection();
            }
        }

        public static DbCommand OracleCommand
        {
            get
            {
                return OracleProviderFactory.CreateCommand();
            }
        }

        public static DbParameter OracleParameter
        {
            get
            {
                return OracleProviderFactory.CreateParameter();
            }
        }

        public static DbDataAdapter OracleDataAdapter
        {
            get
            {
                return OracleProviderFactory.CreateDataAdapter();
            }
        }
    }
}
