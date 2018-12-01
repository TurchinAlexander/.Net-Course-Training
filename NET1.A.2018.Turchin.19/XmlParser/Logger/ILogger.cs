using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser.Logger
{
    public interface ILogger
    {
        void LogWarn(string message);
    }
}
