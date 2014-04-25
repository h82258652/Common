using System.Data.Common;

namespace Common.DataBase
{
    public partial class DataBaseHelper
    {
        private const string OleDbInvariant = "System.Data.OleDb";

        public static DbProviderFactory OleDbProviderFactory
        {
            get
            {
                return DbProviderFactories.GetFactory(OleDbInvariant);
            }
        }

        public static DbConnection OleDbConnection
        {
            get
            {
                return OleDbProviderFactory.CreateConnection();
            }
        }

        public static DbCommand OleDbCommand
        {
            get
            {
                return OleDbProviderFactory.CreateCommand();
            }
        }

        public static DbParameter OleDbParameter
        {
            get
            {
                return OleDbProviderFactory.CreateParameter();
            }
        }

        public static DbDataAdapter OleDbDataAdapter
        {
            get
            {
                return OleDbProviderFactory.CreateDataAdapter();
            }
        }
    }
}
