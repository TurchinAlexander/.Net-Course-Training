using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser.FileLoader
{
    public interface IFileLoader<out T>
    {
        IEnumerable<T> GetAllStrings();
    }
}
