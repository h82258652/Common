
namespace System.Collections.Generic
{
    /// <summary>
    /// 字典扩展类。
    /// </summary>
    public static partial class IDictionaryExtension
    {
        /// <summary>
        /// 尝试删除指定的键相关联的值。
        /// </summary>
        /// <typeparam name="TKey">键的类型。</typeparam>
        /// <typeparam name="TValue">值的类型。</typeparam>
        /// <param name="dict">字典。</param>
        /// <param name="key">要获取的值的键。</param>
        /// <param name="value">当此方法返回值时，如果成功删除，便会返回与指定的键相关联的值；否则，则会返回<c> value </c>参数的类型的默认值。该参数未经初始化即被传递。</param>
        /// <returns>是否成功删除。</returns>
        /// <exception cref="ArgumentNullException"><c>key</c> 为 null。</exception>
        public static bool TryRemove<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, out TValue value)
        {
            if (dict == null)
            {
                throw new ArgumentNullException("dict");
            }
            if (key is ValueType == false && object.Equals(key, default(TKey)) == true)
            {
                throw new ArgumentNullException("key");
            }
            if (dict.ContainsKey(key) == true)
            {
                value = dict[key];
                dict.Remove(key);
                return true;
            }
            else
            {
                value = default(TValue);
                return false;
            }
        }

        /// <summary>
        /// 添加或更新字典中指定的键的值。
        /// </summary>
        /// <typeparam name="TKey">键的类型。</typeparam>
        /// <typeparam name="TValue">值的类型。</typeparam>
        /// <param name="dict">字典。</param>
        /// <param name="key">要添加或更新的元素的键。</param>
        /// <param name="value">要添加或更新的值。</param>
        /// <exception cref="System.ArgumentNullException"><c>key</c> 为 null。</exception>
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (dict == null)
            {
                throw new ArgumentNullException("dict");
            }
            if (key is ValueType == false && object.Equals(key, default(TKey)) == true)
            {
                throw new ArgumentNullException("key");
            }
            if (dict.ContainsKey(key) == true)
            {
                dict[key] = value;
            }
            else
            {
                dict.Add(key, value);
            }
        }

        /// <summary>
        /// 添加或更新字典中指定的键的值。
        /// </summary>
        /// <typeparam name="TKey">键的类型。</typeparam>
        /// <typeparam name="TValue">值的类型。</typeparam>
        /// <param name="dict">字典。</param>
        /// <param name="key">要添加或更新的元素的键。</param>
        /// <param name="value">要添加或更新的值。</param>
        /// <returns>是否成功添加或更新。</returns>
        public static bool AddOrUpdateSafely<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (dict == null)
            {
                return false;
            }
            if (key is ValueType == false && object.Equals(key, default(TKey)) == true)
            {
                return false;
            }
            lock (dict)
            {
                if (dict.ContainsKey(key) == true)
                {
                    dict[key] = value;
                }
                else
                {
                    dict.Add(key, value);
                }
            }
            return true;
        }
    }
}
