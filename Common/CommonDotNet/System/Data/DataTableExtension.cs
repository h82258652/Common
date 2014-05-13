using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data
{
    /// <summary>
    /// DataTable 扩展类。
    /// </summary>
    public static partial class DataTableExtension
    {
        /// <summary>
        /// 将当前数据表反射到对象实体集合。
        /// </summary>
        /// <typeparam name="T">对象实体的类型。</typeparam>
        /// <param name="table">数据表。</param>
        /// <returns>对象实体集合。</returns>
        public static IList<T> ToEntities<T>(this DataTable table)
        {
            var list = new List<T>();
            if (table == null)
            {
                return list;
            }
            foreach (DataRow row in table.Rows)
            {
                var entity = row.ToEntity<T>();
                list.Add(entity);
            }
            return list;
        }
    }
}
