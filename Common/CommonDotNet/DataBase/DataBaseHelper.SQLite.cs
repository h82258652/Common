using System;
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
                try
                {
                    return DbProviderFactories.GetFactory(SQLiteInvariant);
                }
                catch (ArgumentException)
                {
                    return null;
                }
            }
        }

        public static DbConnection SQLiteConnection
        {
            get
            {
                return SQLiteProviderFactory == null ? null : SQLiteProviderFactory.CreateConnection();
            }
        }

        public static DbCommand SQLiteCommand
        {
            get
            {
                return SQLiteProviderFactory == null ? null : SQLiteProviderFactory.CreateCommand();
            }
        }

        public static DbParameter SQLiteParameter
        {
            get
            {
                return SQLiteProviderFactory == null ? null : SQLiteProviderFactory.CreateParameter();
            }
        }

        public static DbDataAdapter SQLiteDataAdapter
        {
            get
            {
                return SQLiteProviderFactory == null ? null : SQLiteProviderFactory.CreateDataAdapter();
            }
        }
    }
}
