
namespace System.Data
{
    /// <summary>
    /// IDataRecord 扩展类。
    /// </summary>
    public static partial class IDataRecordExtension
    {
        /// <summary>
        /// 获取指定列的布尔值形式的值。
        /// </summary>
        /// <param name="record">DataRecord 实例。</param>
        /// <param name="name">要查找的字段的名称。</param>
        /// <returns>列的值。</returns>
        /// <exception cref="System.IndexOutOfRangeException">不存在该名称的字段。</exception>
        public static bool GetBoolean(this IDataRecord record, string name)
        {
            return record.GetBoolean(record.GetOrdinal(name));
        }

        /// <summary>
        /// 获取指定列的 8 位无符号整数值。
        /// </summary>
        /// <param name="record">DataRecord 实例。</param>
        /// <param name="name">要查找的字段的名称。</param>
        /// <returns>指定列的 8 位无符号整数值。</returns>
        /// <exception cref="System.IndexOutOfRangeException">不存在该名称的字段。</exception>
        public static byte GetByte(this IDataRecord record, string name)
        {
            return record.GetByte(record.GetOrdinal(name));
        }

        /// <summary>
        /// 获取指定列的字符值。
        /// </summary>
        /// <param name="record">DataRecord 实例。</param>
        /// <param name="name">要查找的字段的名称。</param>
        /// <returns>指定列的字符值。</returns>
        /// <exception cref="System.IndexOutOfRangeException">不存在该名称的字段。</exception>
        public static char GetChar(this IDataRecord record, string name)
        {
            return record.GetChar(record.GetOrdinal(name));
        }

        /// <summary>
        /// 获取指定字段的日期和时间数据值。
        /// </summary>
        /// <param name="record">DataRecord 实例。</param>
        /// <param name="name">要查找的字段的名称。</param>
        /// <returns>指定字段的日期和时间数据值。</returns>
        /// <exception cref="System.IndexOutOfRangeException">不存在该名称的字段。</exception>
        public static DateTime GetDateTime(this IDataRecord record, string name)
        {
            return record.GetDateTime(record.GetOrdinal(name));
        }

        /// <summary>
        /// 获取指定字段的固定位置的数值。
        /// </summary>
        /// <param name="record">DataRecord 实例。</param>
        /// <param name="name">要查找的字段的名称。</param>
        /// <returns>指定字段的固定位置的数值。</returns>
        /// <exception cref="System.IndexOutOfRangeException">不存在该名称的字段。</exception>
        public static decimal GetDecimal(this IDataRecord record, string name)
        {
            return record.GetDecimal(record.GetOrdinal(name));
        }

        /// <summary>
        /// 获取指定字段的双精度浮点数。
        /// </summary>
        /// <param name="record">DataRecord 实例。</param>
        /// <param name="name">要查找的字段的名称。</param>
        /// <returns>指定字段的双精度浮点数。</returns>
        /// <exception cref="System.IndexOutOfRangeException">不存在该名称的字段。</exception>
        public static double GetDouble(this IDataRecord record, string name)
        {
            return record.GetDouble(record.GetOrdinal(name));
        }

        /// <summary>
        /// 获取指定字段的单精度浮点数。
        /// </summary>
        /// <param name="record">DataRecord 实例。</param>
        /// <param name="name">要查找的字段的名称。</param>
        /// <returns>指定字段的单精度浮点数。</returns>
        /// <exception cref="System.IndexOutOfRangeException">不存在该名称的字段。</exception>
        public static float GetFloat(this IDataRecord record, string name)
        {
            return record.GetFloat(record.GetOrdinal(name));
        }

        /// <summary>
        /// 返回指定字段的 GUID 值。
        /// </summary>
        /// <param name="record">DataRecord 实例。</param>
        /// <param name="name">要查找的字段的名称。</param>
        /// <returns>指定字段的 GUID 值。</returns>
        /// <exception cref="System.IndexOutOfRangeException">不存在该名称的字段。</exception>
        public static Guid GetGuid(this IDataRecord record, string name)
        {
            return record.GetGuid(record.GetOrdinal(name));
        }

        /// <summary>
        /// 获取指定字段的 16 位有符号整数值。
        /// </summary>
        /// <param name="record">DataRecord 实例。</param>
        /// <param name="name">要查找的字段的名称。</param>
        /// <returns>指定字段的 16 位有符号整数值。</returns>
        /// <exception cref="System.IndexOutOfRangeException">不存在该名称的字段。</exception>
        public static short GetInt16(this IDataRecord record, string name)
        {
            return record.GetInt16(record.GetOrdinal(name));
        }

        /// <summary>
        /// 获取指定字段的 32 位有符号整数值。
        /// </summary>
        /// <param name="record">DataRecord 实例。</param>
        /// <param name="name">要查找的字段的名称。</param>
        /// <returns>指定字段的 32 位有符号整数值。</returns>
        /// <exception cref="System.IndexOutOfRangeException">不存在该名称的字段。</exception>
        public static int GetInt32(this IDataRecord record, string name)
        {
            return record.GetInt32(record.GetOrdinal(name));
        }

        /// <summary>
        /// 获取指定字段的 64 位有符号整数值。
        /// </summary>
        /// <param name="record">DataRecord 实例。</param>
        /// <param name="name">要查找的字段的名称。</param>
        /// <returns>指定字段的 64 位有符号整数值。</returns>
        /// <exception cref="System.IndexOutOfRangeException">不存在该名称的字段。</exception>
        public static long GetInt64(this IDataRecord record, string name)
        {
            return record.GetInt64(record.GetOrdinal(name));
        }

        /// <summary>
        /// 获取指定字段的字符串值。
        /// </summary>
        /// <param name="record">DataReader 实例。</param>
        /// <param name="name">要查找的字段的名称。</param>
        /// <returns>指定字段的字符串值。</returns>
        /// <exception cref="System.IndexOutOfRangeException">不存在该名称的字段。</exception>
        public static string GetString(this IDataRecord record, string name)
        {
            return record.GetString(record.GetOrdinal(name));
        }

        /// <summary>
        /// 返回指定字段的值。
        /// </summary>
        /// <param name="record">DataRecord 实例。</param>
        /// <param name="name">要查找的字段的名称。</param>
        /// <returns>返回时将包含字段值的 Object。</returns>
        /// <exception cref="System.IndexOutOfRangeException">不存在该名称的字段。</exception>
        public static object GetValue(this IDataRecord record, string name)
        {
            return record.GetValue(record.GetOrdinal(name));
        }

        /// <summary>
        /// 返回是否将指定字段设置为空。
        /// </summary>
        /// <param name="record">DataRecord 实例。</param>
        /// <param name="name">要查找的字段的名称。</param>
        /// <returns>如果指定的字段设置为 Null，则为 true；否则为 false。</returns>
        /// <exception cref="System.IndexOutOfRangeException">不存在该名称的字段。</exception>
        public static bool IsDBNull(this IDataRecord record, string name)
        {
            return record.IsDBNull(record.GetOrdinal(name));
        }

        /// <summary>
        /// 尝试返回命名字段的索引。
        /// </summary>
        /// <param name="record">DataRecord 实例。</param>
        /// <param name="name">要查找的字段的名称。</param>
        /// <param name="index">命名字段的索引。</param>
        /// <returns>是否存在命名的字段。</returns>
        public static bool TryGetOrdinal(this IDataRecord record, string name, out int index)
        {
            if (record == null)
            {
                index = -1;
                return false;
            }
            if (name == null)
            {
                index = -1;
                return false;
            }
            try
            {
                index = record.GetOrdinal(name);
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                index = -1;
                return false;
            }
        }
    }
}
