using System.Data.Common;

namespace Common.DataBase
{
    public partial class DataBaseHelper
    {
        private const string MySqlInvariant = "MySql.Data.MySqlClient";

        public static DbProviderFactory MySqlProviderFactory
        {
            get
            {
                return DbProviderFactories.GetFactory(MySqlInvariant);
            }
        }

        public static DbConnection MySqlConnection
        {
            get
            {
                return MySqlProviderFactory.CreateConnection();
            }
        }

        public static DbCommand MySqlCommand
        {
            get
            {
                return MySqlProviderFactory.CreateCommand();
            }
        }

        public static DbParameter MySqlParameter
        {
            get
            {
                return MySqlProviderFactory.CreateParameter();
            }
        }

        public static DbDataAdapter MySqlDataAdapter
        {
            get
            {
                return MySqlProviderFactory.CreateDataAdapter();
            }
        }
    }
}
