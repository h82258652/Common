using System.IO;
using System.Linq;

namespace Common.Config
{
    /// <summary>
    /// ini 文件帮助类。
    /// </summary>
    public static partial class IniConfigHelper
    {
        internal static IniTree BuildIniTree(string iniPath)
        {
            using (StreamReader sr = new StreamReader(iniPath))
            {
                IniTree iniTree = new IniTree();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith(";") == true)
                    {
                        IniComment iniComment = new IniComment()
                        {
                            Text = line
                        };
                        IniSection lastSection = (IniSection)iniTree.Nodes.Where(temp => temp is IniSection).LastOrDefault();
                        if (lastSection == null)
                        {
                            iniTree.Nodes.Add(iniComment);
                        }
                        else
                        {
                            lastSection.Nodes.Add(iniComment);
                        }
                    }
                    else if (line.StartsWith("[") == true && line.EndsWith("]") == true)
                    {
                        IniSection iniSection = new IniSection()
                        {
                            Text = line
                        };
                        iniTree.Nodes.Add(iniSection);
                    }
                    else if (line.Contains('=') == true && iniTree.Nodes.Count(temp => temp is IniSection) > 0)
                    {
                        IniKey iniKey = new IniKey()
                        {
                            Text = line
                        };
                        IniSection lastSection = (IniSection)iniTree.Nodes.Where(temp => temp is IniSection).Last();
                        lastSection.Nodes.Add(iniKey);
                    }
                    else
                    {
                        IniUnknownLine iniUnknownLine = new IniUnknownLine()
                        {
                            Text = line
                        };
                        IniSection lastSection = (IniSection)iniTree.Nodes.Where(temp => temp is IniSection).LastOrDefault();
                        if (lastSection == null)
                        {
                            iniTree.Nodes.Add(iniUnknownLine);
                        }
                        else
                        {
                            lastSection.Nodes.Add(iniUnknownLine);
                        }
                    }
                }
                return iniTree;
            }
        }

        /// <summary>
        /// 获取指定 ini 文件中指定节，指定键的值。
        /// </summary>
        /// <param name="iniPath">ini 文件的路径。</param>
        /// <param name="section">节名。</param>
        /// <param name="key">键名。</param>
        /// <returns>若成功，则返回指定节，指定键的值。否则返回空字符串。</returns>
        public static string Get(string iniPath, string section, string key)
        {
            if (File.Exists(iniPath) == false)
            {
                return string.Empty;
            }

            IniTree iniTree = BuildIniTree(iniPath);
            var iniSections = (from temp in iniTree.Nodes
                               where temp is IniSection
                               select (IniSection)temp);
            IniSection iniSection = iniSections.Where(temp => temp.Section == section).FirstOrDefault();
            if (iniSection == null)
            {
                return string.Empty;
            }
            else
            {
                var iniKeys = (from temp in iniSection.Nodes
                               where temp is IniKey
                               select (IniKey)temp);
                IniKey iniKey = iniKeys.Where(temp => temp.Key == key).FirstOrDefault();
                if (iniKey == null)
                {
                    return string.Empty;
                }
                else
                {
                    return iniKey.Value;
                }
            }
        }

        /// <summary>
        /// 设置指定 ini 文件中指定节，指定键的值。
        /// </summary>
        /// <param name="iniPath">ini 文件的路径。</param>
        /// <param name="section">节名。</param>
        /// <param name="key">键名。</param>
        /// <param name="value">值。</param>
        public static void Set(string iniPath, string section, string key, object value)
        {
            if (File.Exists(iniPath) == false)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(iniPath));

                IniTree t = new IniTree();
                IniSection s = new IniSection()
                {
                    Text = section
                };
                IniKey k = new IniKey()
                {
                    Text = key + '=' + value.ToString()
                };
                s.Nodes.Add(k);
                t.Nodes.Add(s);
                File.WriteAllText(iniPath, t.ToString());
                return;
            }

            IniTree iniTree = BuildIniTree(iniPath);
            var iniSections = (from temp in iniTree.Nodes
                               where temp is IniSection
                               select (IniSection)temp);
            IniSection iniSection = iniSections.Where(temp => temp.Section == section).FirstOrDefault();
            if (iniSection == null)
            {
                iniSection = new IniSection();
                iniSection.Text = section;
                iniSection.Nodes.Add(new IniKey()
                {
                    Text = key + '=' + value.ToString()
                });
                iniTree.Nodes.Add(iniSection);
                File.WriteAllText(iniPath, iniTree.ToString());
            }
            else
            {
                var iniKeys = (from temp in iniSection.Nodes
                               where temp is IniKey
                               select (IniKey)temp);
                IniKey iniKey = iniKeys.Where(temp => temp.Key == key).FirstOrDefault();
                if (iniKey == null)
                {
                    iniSection.Nodes.Add(new IniKey()
                    {
                        Text = key + '=' + value.ToString()
                    });
                    File.WriteAllText(iniPath, iniTree.ToString());
                }
                else
                {
                    iniKey.Value = value.ToString();
                    File.WriteAllText(iniPath, iniTree.ToString());
                }
            }
        }
    }
}
