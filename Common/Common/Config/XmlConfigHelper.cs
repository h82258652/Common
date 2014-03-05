using System;
using System.Linq;
using System.Xml.Linq;

namespace Common.Config
{
    public partial class XmlConfigHelper
    {
        public static string Get(string xmlPath, string xpath)
        {
            XDocument xd = XDocument.Load(xmlPath);
            string[] paths = xpath.Split('/', '\\');
            var xes = xd.Elements();
            for (int i = 0; i < paths.Length; i++)
            {
                var xe = xes.Where(temp => temp.Name.LocalName.Equals(paths[i], StringComparison.OrdinalIgnoreCase) == true).FirstOrDefault();
                if (xe == null)
                {
                    return "";
                }
                if (i == paths.Length - 1)
                {
                    return xe.Value;
                }
                xes = xe.Elements();
            }
            return "";
        }

        public static void Set(string xmlPath, string xpath, object value)
        {
            XDocument xd = XDocument.Load(xmlPath);
            string[] paths = xpath.Split('/', '\\');
            var xes = xd.Elements();
            for (int i = 0; i < paths.Length; i++)
            {
                var xe = xes.Where(temp => temp.Name.LocalName.Equals(paths[i], StringComparison.OrdinalIgnoreCase) == true).FirstOrDefault();
                if (xe == null)
                {
                    var lastElement = xes.ElementAt(xes.Count() - 1);
                    xe = new XElement(XName.Get(paths[i]));
                    lastElement.AddAfterSelf(xe);
                }
                if (i == paths.Length - 1)
                {
                    xe.Value = value.ToString();
                    xd.Save(xmlPath);
                    return;
                }
                xes = xe.Elements();
            }
        }
    }
}