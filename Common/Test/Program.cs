using System.Collections;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Dynamic;
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
using System.Runtime.CompilerServices;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string s = jss.Serialize(dt);
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }

    public class XX
    {
        public int A;
        public string B;
    }

    public struct YY
    {
        public int C;
        public string D;
    }

    public class EmptyInstanceFactory
    {
        public static object Create(Type type)
        {
            //if (type == typeof(int))
            //{
            //    return 0;
            //}
            if (type == typeof(string))
            {
                return string.Empty;
            }
            var emptyInstance = FormatterServices.GetUninitializedObject(type);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var property in properties)
            {
                property.SetValue(emptyInstance, EmptyInstanceFactory.Create(property.PropertyType), null);
            }
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
            foreach (var field in fields)
            {
                field.SetValue(emptyInstance, EmptyInstanceFactory.Create(field.FieldType));
            }
            return emptyInstance;
        }

        public static T Create<T>()
        {
            return (T)Create(typeof(T));
        }
    }
}
