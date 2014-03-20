using System.Collections;
using System.Collections.Concurrent;
using System.Globalization;
using System.IO.Compression;
using System.Runtime.Remoting.Messaging;
using System.Web.UI.WebControls;
using Common.Config;
using Common.Reflection;
using Common.Security;
using Common.Serialization;
using Common.Threading;
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

    internal class P
    {
        [Json(CollectionCountGreaterThan = 2, CollectionCountLessThan = 5)]
        public string[] SS
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        public P()
        {
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            var x = new
            {
                name = "haha",
                age = 18
            };
            string s;
            Console.WriteLine(s=JsonHelper.SerializeToJson(x));
            Type t = x.GetType();
            var q = JsonHelper.Deserialize(s, t);
            Console.WriteLine(ReflectionHelper.GetField(q, "name"));

var xxx=            ReflectionHelper.Create(t);

            Console.ReadKey();
        }
    }
}
