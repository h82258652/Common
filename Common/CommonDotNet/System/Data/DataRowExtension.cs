using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data
{
    /// <summary>
    /// DataRow 扩展类。
    /// </summary>
    public static partial class DataRowExtension
    {
        /// <summary>
        /// 将当前数据行反射到对象实体。
        /// </summary>
        /// <typeparam name="T">对象实体的类型。</typeparam>
        /// <param name="row">数据行。</param>
        /// <returns>对象实体。</returns>
        public static T ToEntity<T>(this DataRow row)
        {
            if (row == null)
            {
                return default(T);
            }
            var table = row.Table;
            if (table == null)
            {
                return default(T);
            }
            var columns = table.Columns;
            var entity = Activator.CreateInstance<T>();
            foreach (var property in typeof(T).GetProperties())
            {
                var propertyName = property.Name;
                var containProperty = columns.Contains(propertyName);
                if (containProperty == true)
                {
                    property.SetValue(entity, row[propertyName], null);
                }
            }
            return entity;
        }
    }
}
