using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser.Parser
{
    public interface IParser<in T, out U>
    {
        IEnumerable<U> Parse(IEnumerable<T> values);
    }
}
