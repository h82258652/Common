using System;
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
                try
                {
                    return DbProviderFactories.GetFactory(OracleInvariant);
                }
                catch (ArgumentException)
                {
                    return null;
                }
            }
        }

        public static DbConnection OracleConnection
        {
            get
            {
                return OracleProviderFactory == null ? null : OracleProviderFactory.CreateConnection();
            }
        }

        public static DbCommand OracleCommand
        {
            get
            {
                return OracleProviderFactory == null ? null : OracleProviderFactory.CreateCommand();
            }
        }

        public static DbParameter OracleParameter
        {
            get
            {
                return OracleProviderFactory == null ? null : OracleProviderFactory.CreateParameter();
            }
        }

        public static DbDataAdapter OracleDataAdapter
        {
            get
            {
                return OracleProviderFactory == null ? null : OracleProviderFactory.CreateDataAdapter();
            }
        }
    }
}
