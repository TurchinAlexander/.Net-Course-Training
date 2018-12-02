using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes.DataEvent
{
    public class DataEventArgs : EventArgs
    {
        public string Message { get; }

        public DataEventArgs(string message)
        {
            this.Message = message;
        }
    }
}
