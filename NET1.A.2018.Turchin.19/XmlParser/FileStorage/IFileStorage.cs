using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser.FileStorage
{
    public interface IFileStorage<in T>
    {
        void Store(IEnumerable<T> values);
    }
}
