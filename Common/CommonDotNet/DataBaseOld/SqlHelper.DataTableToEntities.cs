using System.Collections.Generic;
using System.Data;

namespace Common.DataBase
{
    public partial class SqlHelper
    {
        /// <summary>
        /// 将数据表反射到对象实体集合。
        /// </summary>
        /// <typeparam name="T">对象实体的类型。</typeparam>
        /// <param name="table">数据表。</param>
        /// <returns>对象实体集合。</returns>
        public static IList<T> DataTableToEntities<T>(DataTable table)
        {
            List<T> list = new List<T>();
            foreach (DataRow row in table.Rows)
            {
                T entity = DataRowToEntity<T>(row);
                list.Add(entity);
            }
            return list;
        }
    }
}
