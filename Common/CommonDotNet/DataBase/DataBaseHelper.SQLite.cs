using System.Data.Common;

namespace Common.DataBase
{
    public partial class DataBaseHelper
    {
        private const string SQLiteInvariant = "System.Data.SQLite";

        public static DbProviderFactory SQLiteProviderFactory
        {
            get
            {
                return DbProviderFactories.GetFactory(SQLiteInvariant);
            }
        }

        public static DbConnection SQLiteConnection
        {
            get
            {
                return SQLiteProviderFactory.CreateConnection();
            }
        }

        public static DbCommand SQLiteCommand
        {
            get
            {
                return SQLiteProviderFactory.CreateCommand();
            }
        }

        public static DbParameter SQLiteParameter
        {
            get
            {
                return SQLiteProviderFactory.CreateParameter();
            }
        }

        public static DbDataAdapter SQLiteDataAdapter
        {
            get
            {
                return SQLiteProviderFactory.CreateDataAdapter();
            }
        }
    }
}
