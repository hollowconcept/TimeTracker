using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_TimeTracker.Management
{
    public class ReportManager
    {
        public event OnErrorEventHandler OnError;
        public delegate void OnErrorEventHandler(string message);
    }
}
