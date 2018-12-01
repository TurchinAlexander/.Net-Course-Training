using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace XmlParser.FileStorage
{
    public  class FileStorageEntity : IFileStorage<Uri>
    {
        private string path = string.Empty;

        public FileStorageEntity(string path)
        {
            this.path = path;
        }

        public void Store(IEnumerable<Uri> values)
        {
            XDocument result = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            XElement root = new XElement("urlAddresses");

            foreach(var uri in values)
            {
                XElement address = new XElement("urlAddress");

                address.AddHost(uri);
                address.AddSegments(uri);
                address.AddParameters(uri);

                root.Add(address);
            }

            result.Add(root);
            result.Save(path);
        }
    }

    static class XElementExtensions
    {
        public static void AddHost(this XElement address, Uri uri)
        {
            XElement host =
                new XElement("host",
                    new XAttribute("name", uri.Host));

            address.Add(host);
        }

        public static void AddSegments(this XElement address, Uri uri)
        {
            XElement segments = new XElement("segments");

            string temp;
            foreach (var seg in uri.Segments)
            {
                temp = seg;
                if (temp[temp.Length - 1] == '/')
                {
                    temp = temp.Substring(0, temp.Length - 1);
                }

                segments.Add(new XElement("segment", temp));
            }

            address.Add(segments);
        }

        public static void AddParameters(this XElement address, Uri uri)
        {
            var query = HttpUtility.ParseQueryString(uri.Query);

            if (!query.HasKeys())
                return;

            XElement parameters = new XElement("parameters");
            for (int i = 0; i < query.Count; i++)
            {
                parameters.Add(
                    new XAttribute("value", query[i]),
                    new XAttribute("key", query.AllKeys[i]));
            }

            address.Add(parameters);
        }
    }

}
