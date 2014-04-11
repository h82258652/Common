using System;
using System.Data;
using System.Reflection;

namespace Common.DataBase
{
    public partial class SqlHelper
    {
        /// <summary>
        /// 将数据行反射到对象实体。
        /// </summary>
        /// <typeparam name="T">对象实体的类型。</typeparam>
        /// <param name="row">数据行。</param>
        /// <returns>对象实体。</returns>
        public static T DataRowToEntity<T>(DataRow row)
        {
            if (row == null)
            {
                return default(T);
            }
            DataTable table = row.Table;
            if (table == null)
            {
                return default(T);
            }
            DataColumnCollection columns = table.Columns;
            T entity = Activator.CreateInstance<T>();
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                string propertyName = property.Name;
                bool contain = columns.Contains(propertyName);
                if (contain == true)
                {
                    property.SetValue(entity, row[propertyName], null);
                }
            }
            return entity;
        }
    }
}
