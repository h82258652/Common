using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common.Serialization
{
    /// <summary>
    /// 以二进制格式将对象或整个连接对象图形序列化和反序列化。
    /// </summary>
    public static partial class BinarySerializeHelper
    {
        private static readonly BinaryFormatter _bf = new BinaryFormatter();

        /// <summary>
        /// 将指定的字节数组转换为 T 类型的对象。
        /// </summary>
        /// <typeparam name="T">所生成对象的类型。</typeparam>
        /// <param name="value">要进行反序列化的字节数组。</param>
        /// <returns>反序列化的对象。</returns>
        public static T Deserialize<T>(byte[] value)
        {
            using (MemoryStream ms = new MemoryStream(value))
            {
                return (T)_bf.Deserialize(ms);
            }
        }

        /// <summary>
        /// 将当前对象转换为字节数组。（需要对对象的类用 Serializable 进行标记）
        /// </summary>
        /// <typeparam name="T">序列化的对象的类型。</typeparam>
        /// <param name="input">序列化的对象。</param>
        /// <returns>序列化的字节数组。</returns>
        public static byte[] SerializeToBytes<T>(this T input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                _bf.Serialize(ms, input);
                return ms.ToArray();
            }
        }
    }
}
