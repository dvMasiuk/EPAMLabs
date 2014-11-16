using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class PortStateChangedEventArgs : EventArgs
    {
        public PortStateChangedEventArgs(object data = null)
        {
            Data = data;
        }

        public object Data { get; private set; }
    }
}
