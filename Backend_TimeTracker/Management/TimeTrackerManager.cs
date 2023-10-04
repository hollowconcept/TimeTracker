using Backend_TimeTracker.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_TimeTracker.Management
{
    public class TimeTrackerManager
    {
        public event OnErrorEventHandler OnError;
        public delegate void OnErrorEventHandler(string message);

        TimeRecordingDB TimeEntriesDB;

        public TimeTrackerManager()
        {
            TimeEntriesDB = new TimeRecordingDB();
        }

      
    }
}
