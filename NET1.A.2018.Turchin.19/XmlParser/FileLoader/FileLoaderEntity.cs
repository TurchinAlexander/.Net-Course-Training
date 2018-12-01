using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser.FileLoader
{
    public  class FileLoaderEntity : IFileLoader<string>
    {
        private string path = string.Empty;

        public FileLoaderEntity(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(nameof(path));
            }

            this.path = path;
        }

        public IEnumerable<string> GetAllStrings()
        {
            return File.ReadLines(path);
        }
    }
}
