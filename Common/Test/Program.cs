using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace Test
{

   public class MessageBase
    {
        public string ToUserName
        {
            get;
            set;
        }

        public string FromUserName
        {
            get;
            set;
        }
    }


    static class Program
    {
        static void Main(string[] args)
        {
            string s = @"<xml>
 <ToUserName><![CDATA[toUser]]></ToUserName>
 <FromUserName><![CDATA[fromUser]]></FromUserName> 
 <CreateTime>1348831860</CreateTime>
 <MsgType><![CDATA[text]]></MsgType>
 <Content><![CDATA[this is a test]]></Content>
 <MsgId>1234567890123456</MsgId>
 </xml>";
            XDocument xd = 
            XDocument.Parse(s);

            var root = xd.Root;
            var qqq = root.Element("MsgType").Value;

            Console.ReadKey();
        }

        public static MemoryStream SerializeToXMLStream<T>(this T obj)
        {
            MemoryStream ms = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(typeof(T));
            xs.Serialize(ms, obj);
            return ms;
        }



    }

    class Ini
    {
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
