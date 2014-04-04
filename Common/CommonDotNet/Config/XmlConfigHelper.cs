using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Common.Config
{
    /// <summary>
    /// XML 设置帮助类。
    /// </summary>
    public static partial class XmlConfigHelper
    {
        internal static XmlNode SelectNode(XmlDocument xd, string xpath)
        {
            Stack<string> stack = new Stack<string>();
            XmlNode node;
            for (; ; )
            {
                node = xd.SelectSingleNode(xpath);
                if (node == null)
                {
                    stack.Push(xpath.Substring(xpath.LastIndexOfAny(new char[] { '/', '\\' }) + 1));
                    xpath = xpath.Substring(0, xpath.LastIndexOfAny(new char[] { '/', '\\' }));
                    continue;
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                if (stack.Count == 0)
                {
                    break;
                }
                else
                {
                    string s = stack.Pop();
                    XmlElement temp = xd.CreateElement(s);
                    node.AppendChild(temp);
                    node = temp;
                }
            }
            return node;
        }

        /// <summary>
        /// 获取 xml 文件中指定 xml 路径的值。
        /// </summary>
        /// <param name="xmlPath">xml 文件路径。</param>
        /// <param name="xpath">xml 查询路径。</param>
        /// <returns>若存在值，则返回值，否则返回空字符串。</returns>
        public static string Get(string xmlPath, string xpath)
        {
            if (File.Exists(xmlPath) == false)
            {
                return string.Empty;
            }

            XDocument xd = XDocument.Load(xmlPath);
            string[] paths = xpath.Split('/', '\\');
            var xes = xd.Elements();
            for (int i = 0; i < paths.Length; i++)
            {
                var xe = xes.Where(temp => temp.Name.LocalName.Equals(paths[i], StringComparison.OrdinalIgnoreCase) == true).FirstOrDefault();
                if (xe == null)
                {
                    return string.Empty;
                }
                if (i == paths.Length - 1)
                {
                    return xe.Value;
                }
                xes = xe.Elements();
            }
            return string.Empty;
        }

        /// <summary>
        /// 设置 xml 文件中指定 xml 路径的值。
        /// </summary>
        /// <param name="xmlPath">xml 文件路径。</param>
        /// <param name="xpath">xml 查询路径。</param>
        /// <param name="value">新的值。</param>
        public static void Set(string xmlPath, string xpath, object value)
        {
            // 检查参数。
            if (string.IsNullOrWhiteSpace(xmlPath) == true)
            {
                throw new ArgumentException("XML 的路径不能为空。");
            }
            if (string.IsNullOrWhiteSpace(xpath) == true)
            {
                throw new ArgumentException("查询字符串不能为空。");
            }

            // 加载xml，并检查根节点是否存在，若不存在则添加根节点。
            XmlDocument xd = new XmlDocument();
            if (File.Exists(xmlPath) == true)
            {
                xd.Load(xmlPath);
                var root = xd.ChildNodes.OfType<XmlElement>().FirstOrDefault();
                if (root == null)
                {
                    root = xd.CreateElement(xpath.Split('/', '\\')[0]);
                    xd.AppendChild(root);
                }
                else
                {
                    // 根节点名称不符合。
                    if (root.Name.Equals(xpath.Split('/', '\\')[0], StringComparison.OrdinalIgnoreCase) == false)
                    {
                        return;
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(Path.GetDirectoryName(xmlPath));
                File.WriteAllText(xmlPath, "<" + xpath.Split('/', '\\')[0] + "></" + xpath.Split('/', '\\') + ">");
                xd.Load(xmlPath);
            }

            XmlNode node = SelectNode(xd, xpath);
            node.InnerText = value.ToString();
            xd.Save(xmlPath);
        }
    }
}
