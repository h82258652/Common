using System.Collections;
using System.Collections.Concurrent;
using System.Globalization;
using System.IO.Compression;
using System.Numerics;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Test
{
    class DownloadHelper
    {
        public string Url
        {
            get;
            set;
        }

        public string FilePath
        {
            get;
            set;
        }

        public long FileSize
        {
            set;
            get;
        }

        private volatile FileStream fs;

        private List<Thread> threadList = new List<Thread>();

        public DownloadHelper(string url, string filePath)
        {
            this.Url = url;
            this.FilePath = filePath;
        }

        public void Start()
        {
            this.FileSize = T.GetFileLength(this.Url);
            if (this.FileSize < 0)
            {
                throw new Exception("");
            }
            else
            {
                for (long i = 0; i < this.FileSize; )
                {
                    long start = i;
                    long end = i + 10;

                    Thread t = new Thread(() =>
                    {
                        T.WritePart(this.Url, this.FilePath, start, end);
                    });
                    threadList.Add(t);
                    i = i + 11;
                }
            }
        }

        public void Switch()
        {
        }

        public void Dispose()
        {

        }
    }

    class T
    {
        public static void Start(string url, string filePath)
        {
            long fileSize = GetFileLength(url);

            List<Thread> list = new List<Thread>();

            for (long i = 0; i < fileSize; )
            {

                long start = i;
                long end = i + 20;
                end = Math.Min(end, fileSize);

                Thread t = new Thread(() =>
                {
                    WritePart(url, filePath, start, end);
                });
                list.Add(t);
                i = i + 21;
            }

            list.All(temp =>
            {
                temp.Start();
                return true;
            });

            return;


            while (true)
            {
                if (list.Count(temp => temp.ThreadState == System.Threading.ThreadState.Stopped) == list.Count)
                {
                    break;
                }
                if (list.Count(temp => temp.ThreadState == System.Threading.ThreadState.Running) < 1)
                {
                    list.Reverse();
                    var t = list.Where(temp => temp.ThreadState == System.Threading.ThreadState.Unstarted).FirstOrDefault();
                    if (t != null)
                    {
                        t.Start();
                    }
                    list.Reverse();
                }
            }
        }

        private static volatile FileStream fs;

        public static void WritePart(string url, string filePath, long start, long end)
        {
            byte[] buffer = DownloadPart(url, start, end);
            if (fs == null)
            {
                fs = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            }
            lock (fs)
            {
                fs.Seek(start, SeekOrigin.Begin);
                fs.Write(buffer, 0, buffer.Length);
                //   fs.Dispose();
                fs.Flush();
            }
        }

        public static long GetFileLength(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.Method = "HEAD";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                return response.ContentLength;
            }
        }

        public static byte[] DownloadPart(string url, long start, long end)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.Method = "GET";
            request.AddRange(start, end);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream s = response.GetResponseStream())
                {
                    List<byte> list = new List<byte>();
                    int c;
                    while ((c = s.ReadByte()) != -1)
                    {
                        list.Add((byte)c);
                    }
                    return list.ToArray();
                }
            }
        }
    }

    class Program
    {
        public static double ToNum(string input)
        {
            Regex r = new Regex(@"^(\-?)(0|[1-9]\d*)(\.\d+)?((e|E)(\+|\-)?\d+)?");
            Match m = r.Match(input);
            if (m.Success == true)
            {
                string num = m.Groups[1].Value + m.Groups[2].Value + m.Groups[3].Value;
                if (m.Groups[4].Success == true)
                {
                    string e = m.Groups[4].Value.Substring(1);
                    return double.Parse(num) * Math.Pow(10, double.Parse(e));
                }
                else
                {
                    return double.Parse(num);
                }
            }
            else
            {
                throw new Exception();
            }
        }

        public static void VV(string s = "")
        {
            Console.WriteLine(s);
        }

        public static void Main(string[] args)
        {
            unchecked
            {
                Console.WriteLine(Double.NaN.ToString());

                var s = Newtonsoft.Json.JsonConvert.SerializeObject(Double.NaN);
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }

    enum  TTTTT
    {
        HHHHHH,
        ggggggggggggggg
    }

    class Tst
    {
        public string Hellp
        {
            get;
            set;
        }

        public string Hellp2
        {
            get;
            set;
        }

        public string Hellp3
        {
            get;
            set;
        }

        public string Hellp4
        {
            get;
            set;
        }

        public string Hellp5
        {
            get;
            set;
        }

        public string Hellp6
        {
            get;
            set;
        }

        public string Hellp7
        {
            get;
            set;
        }

        public string Hellp8
        {
            get;
            set;
        }


        public string Name
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }
    }
}
