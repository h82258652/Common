using System;
using System.IO;
using System.Text;

namespace Common
{
    public partial class CommonJS
    {
        public static string Using(string @namespace)
        {
            var currentDirectory = Environment.CurrentDirectory;
            var namespaceDirectory = Path.Combine(currentDirectory, @namespace);
            if (Directory.Exists(namespaceDirectory) == true)
            {
                string[] fileNames = Directory.GetFiles(namespaceDirectory);
                StringBuilder sb = new StringBuilder();
                foreach (string fileName in fileNames)
                {
                    string js = File.ReadAllText(fileName);
                    sb.AppendLine(js);
                }
                return sb.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static string UsingMin(string @namespace)
        {
            return Using(@namespace);
        }
    }
}
