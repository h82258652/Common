using System;
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
                try
                {
                    return DbProviderFactories.GetFactory(OleDbInvariant);
                }
                catch (ArgumentException)
                {
                    return null;
                }
            }
        }

        public static DbConnection OleDbConnection
        {
            get
            {
                return OleDbProviderFactory == null ? null : OleDbProviderFactory.CreateConnection();
            }
        }

        public static DbCommand OleDbCommand
        {
            get
            {
                return OleDbProviderFactory == null ? null : OleDbProviderFactory.CreateCommand();
            }
        }

        public static DbParameter OleDbParameter
        {
            get
            {
                return OleDbProviderFactory == null ? null : OleDbProviderFactory.CreateParameter();
            }
        }

        public static DbDataAdapter OleDbDataAdapter
        {
            get
            {
                return OleDbProviderFactory == null ? null : OleDbProviderFactory.CreateDataAdapter();
            }
        }
    }
}
