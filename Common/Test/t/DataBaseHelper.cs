using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.t
{
    public class DataBaseHelper
    {
        public static DbConnection SqlServerConnection
        {
            get
            {
                return DbProviderFactories.GetFactory("System.Data.SqlClient").CreateConnection();
            }
        }

        public static DbCommand SqlServerCommand
        {
            get
            {
                return DbProviderFactories.GetFactory("System.Data.SqlClient").CreateCommand();
            }
        }

        public static DbParameter SqlServerParameter
        {
            get
            {
                return DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
            }
        }

        public static DbDataAdapter SqlServerAdapter
        {
            get
            {
                return DbProviderFactories.GetFactory("System.Data.SqlClient").CreateDataAdapter();
            }
        }
    }
}
