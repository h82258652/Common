using System;
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
                try
                {
                    return DbProviderFactories.GetFactory(MySqlInvariant);
                }
                catch (ArgumentException)
                {
                    return null;
                }
            }
        }

        public static DbConnection MySqlConnection
        {
            get
            {
                return MySqlParameter == null ? null : MySqlProviderFactory.CreateConnection();
            }
        }

        public static DbCommand MySqlCommand
        {
            get
            {
                return MySqlProviderFactory == null ? null : MySqlProviderFactory.CreateCommand();
            }
        }

        public static DbParameter MySqlParameter
        {
            get
            {
                return MySqlProviderFactory == null ? null : MySqlProviderFactory.CreateParameter();
            }
        }

        public static DbDataAdapter MySqlDataAdapter
        {
            get
            {
                return MySqlProviderFactory == null ? null : MySqlProviderFactory.CreateDataAdapter();
            }
        }
    }
}
