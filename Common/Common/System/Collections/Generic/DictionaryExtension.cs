using System;
using System.Collections.Generic;

namespace Common.System.Collections.Generic
{
    public static partial class DictionaryExtension
    {
        /// <summary>
        /// 尝试删除指定的键相关联的值。
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key">要获取的值的键。</param>
        /// <param name="value">当此方法返回值时，如果成功删除，便会返回与指定的键相关联的值；否则，则会返回<c> value </c>参数的类型的默认值。该参数未经初始化即被传递。</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static bool TryRemove<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, out TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key 不能为空。");
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
    }
}
