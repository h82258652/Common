using System.Collections;
using System.Collections.Concurrent;
using System.Globalization;
using System.IO.Compression;
using System.Linq.Expressions;
using System.Net.Mime;
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
using Common.Serialization;

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

    class JT : Ex<JT>, IQueryable<int>
    {
        public JT FirstOrDefault(Expression<Func<JT, bool>> expression)
        {
            return new JT();
        }

        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Type ElementType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Expression Expression
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }

    interface Ex<T>
    {
        T FirstOrDefault(Expression<Func<T, bool>> expression);
    }

    class Program
    {
        public static string Select(Expression<Func<Program, bool>> expression)
        {
            return "";
        }

        public static string E(Expression<Func<bool>> a)
        {
            return "";
        }


        public static int Hahahahaha(string sss)
        {
            try
            {
                if (sss == "111")
                {
                    return 111;
                }
                else
                {
                    return 222;
                }
            }
            catch (Exception)
            {
                return 10;
            }
        }

        public static void Go(Expression expression)
        {
            if (expression is BinaryExpression)
            {
                Console.WriteLine("BinaryExpression");
            }
            else if(expression is LambdaExpression)
            {
                Go(((LambdaExpression)expression).Body);
            }
            else if (expression is ConditionalExpression)
            {
var xxx=                (ConditionalExpression) expression;
                Go(xxx.IfFalse);
            }
            else if (expression is ConstantExpression)
            {
var q=                (ConstantExpression) expression;
            }
            else
            {
                throw new Exception(expression.ToString());
            }
        }


        public static void Main(string[] args)
        {
            int aa = 1;
            Console.WriteLine(aa is ValueType);
            Console.ReadKey();
            return;
                


            ForTest.MyMain();
            Environment.Exit(1);

            IQueryable<int> a;
         

            Expression<Func<string, int>> xqqq = (s) => s.StartsWith("") ? 0 : 1;

            Go(xqqq);
            return;

            var b = xqqq.Body;


            Func<int, bool> deleg = i => i < 5;
            // Invoke the delegate and display the output.
            Console.WriteLine("deleg(4) = {0}", deleg(4));

            // Lambda expression as data in the form of an expression tree.
            System.Linq.Expressions.Expression<Func<int, bool>> expr = i => i < 5;
            // Compile the expression tree into executable code.
            Func<int, bool> deleg2 = expr.Compile();
            // Invoke the method and print the output.
            Console.WriteLine("deleg2(4) = {0}", deleg2(4));


            var xx = Expression.MakeBinary(ExpressionType.Subtract, Expression.Constant(5), Expression.Constant(4));


            var rs = xx.Method.Invoke(null, null);

            JT jt = new JT();
            jt.FirstOrDefault(temp => temp.ToString() == "");

            Console.ReadKey();
        }
    }

}
