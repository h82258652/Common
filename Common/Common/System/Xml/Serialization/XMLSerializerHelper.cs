using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Xml.Serialization
{
    public static partial class XMLSerializerHelper
    {
        /// <summary>
        /// 将当前对象 XML 序列化到内存流中。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>序列化的 XML 内存流。</returns>
        public static MemoryStream SerializeToXMLStream<T>(this T obj)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            xs.Serialize(ms, obj);
            return ms;
        }

        /// <summary>
        /// 将指定的 XML 流反序列化为 T 类型的对象。
        /// </summary>
        /// <typeparam name="T">所生成对象的类型。</typeparam>
        /// <param name="input">要进行反序列化的 XML 流。</param>
        /// <returns>反序列化的对象。</returns>
        public static T Deserialize<T>(Stream input)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            return (T)xs.Deserialize(input);
        }

        /// <summary>
        /// 将当前对象以 XML 格式保存在文件中。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="filePath">文件路径。</param>
        public static void SerializeToXMLFile<T>(this T obj, string filePath)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            xs.Serialize(File.Create(filePath), obj);
        }

        /// <summary>
        /// 将指定的 XML 文件反序列化为 T 类型的对象。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath">文件路径。</param>
        /// <returns>反序列化的对象。</returns>
        public static T Deserialize<T>(string filePath)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            return (T)xs.Deserialize(File.OpenRead(filePath));
        }
    }
}
