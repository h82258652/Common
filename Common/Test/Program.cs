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
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Xml;

namespace Test
{
    static class Program
    {
        static void Main(string[] args)
        {
            Common.Config.IniConfigHelper.Set(@"d:\xmltest\bb\aa.ini", "App", "zzzz", 1);
            Console.WriteLine(Common.Config.IniConfigHelper.Get(@"d:\xmltest\aa.ini", "App", "zzzz"));
            Console.ReadKey();
        }
    }
}