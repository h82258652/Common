using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common
{
    public static partial class Ini
    {
        /// <summary>
        /// 获取指定的 ini 文件中是否存在指定节。
        /// </summary>
        /// <param name="filePath"> ini 文件路径。</param>
        /// <param name="section">节名。</param>
        /// <returns>若存在，则返回 true ，否则返回 false 。</returns>
        public static bool HasSection(string filePath, string section)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.StartsWith("[" + section + "]") == true)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 获取指定的 ini 文件中指定的节是否存在指定的键。
        /// </summary>
        /// <param name="filePath"> ini 文件路径。</param>
        /// <param name="section">节名。</param>
        /// <param name="key">键名。</param>
        /// <returns>若存在，则返回 true ，否则返回 false 。</returns>
        public static bool HasKey(string filePath, string section, string key)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.StartsWith("[" + section + "]") == true)
                    {
                        while ((s = sr.ReadLine()) != null)
                        {
                            if (s.StartsWith("[") == true)
                            {
                                break;
                            }
                            if (s.StartsWith(key) == true)
                            {
                                string[] array = s.Split('=');
                                if (array[0].Trim() == key)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 读取指定 ini 文件的指定键值。
        /// </summary>
        /// <param name="filePath"> ini 文件路径。</param>
        /// <param name="section">键所在的节名。</param>
        /// <param name="key">键名。</param>
        /// <returns>若存在，则返回键值。不存在则抛出异常。</returns>
        public static string Read(string filePath, string section, string key)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.StartsWith("[" + section + "]") == true)
                    {
                        while ((s = sr.ReadLine()) != null)
                        {
                            if (s.StartsWith("[") == true)
                            {
                                break;
                            }
                            if (s.StartsWith(key) == true)
                            {
                                if (s.Contains(';') == true)
                                {
                                    s = s.Substring(0, s.IndexOf(';'));
                                }
                                string[] array = s.Split('=');
                                if (array[0].Trim() == key)
                                {
                                    return array[1].Trim();
                                }
                            }
                        }
                    }
                }
            }
            throw new Exception("指定的键不存在！");
        }

        /// <summary>
        /// 写入指定的键值到 ini 文件中。（若不存在该 ini 文件则会创建。）
        /// </summary>
        /// <param name="filePath"> ini 文件路径。</param>
        /// <param name="section">节名。</param>
        /// <param name="key">键名。</param>
        /// <param name="value">键值。</param>
        public static void Write(string filePath, string section, string key, string value)
        {
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("[" + section + "]") == true)
                {
                    for (; i < lines.Length; i++)
                    {
                        if (lines[i].StartsWith("[") == true)
                        {
                            List<string> list = lines.ToList();
                            list.Insert(i, key + "=" + value);
                            using (StreamWriter sw = new StreamWriter(filePath, false))
                            {
                                foreach (var temp in list)
                                {
                                    sw.WriteLine(temp);
                                }
                            }
                            return;
                        }
                        if (lines[i].Contains('=') == false)
                        {
                            continue;
                        }
                        string[] array = lines[i].Split(';');
                        string keyValue = array[0];
                        string comment = ";" + array[1];
                        array = keyValue.Split('=');
                        string inikey = array[0];
                        string inivalue = array[1];
                        if (inikey.Trim() == key)
                        {
                            lines[i] = key + "=" + value + comment;
                            using (StreamWriter sw = new StreamWriter(filePath, false))
                            {
                                foreach (var temp in lines)
                                {
                                    sw.WriteLine(temp);
                                }
                            }
                            return;
                        }
                    }
                }
            }
            File.AppendAllText(filePath, "[" + section + "]");
            File.AppendAllText(filePath, key + "=" + value);
        }
    }
}