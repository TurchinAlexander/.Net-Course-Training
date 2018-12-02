using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes.DataEvent
{
    public class DataEventArgs : EventArgs
    {
        public string message;

        public DataEventArgs(string message)
        {
            this.message = message;
        }
    }
}
