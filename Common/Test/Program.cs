using System.Collections;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
        string CC
        {
            get
            {
                return CallerMemberName;
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(new Program(). CC);

            HHHHH();
            Console.ReadKey();
        }

        public static string CallerMemberName
        {
            get
            {
                return new StackTrace(true).GetFrame(1).GetMethod().Name;
            }
        }

        public static void HHHHH([CallerLineNumber] int propertyNamex = 0)
        {
            Console.WriteLine(CallerMemberName);
            Console.WriteLine(propertyNamex);
        }
    }
}