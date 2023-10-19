using Backend_TimeTracker.DataAccess;
using GlobalDefinitions_TimeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_TimeTracker.Management
{
    public class TimeTrackerManager
    {
        public static event OnErrorEventHandler OnError;
        public delegate void OnErrorEventHandler(string message);

        TimeRecordingDB TimeEntriesDB;

        public TimeTrackerManager()
        {
            TimeEntriesDB = new TimeRecordingDB();
        }

        public static List<TimeRecordingProperty> GetTimeRecordings()
        {
            List<TimeRecordingProperty> listTimeRecordings = default;

            TimeRecordingDB timeRecordingDB = new TimeRecordingDB();

            long? timeRecordingId = 0;
            long? userId = 0;
            long? customerId = 0;
            long? projectId = 0;
            long? businessAreaId = 0;

            try
            {
                listTimeRecordings = timeRecordingDB.GetTimeRecordings(timeRecordingId, userId, customerId, projectId, businessAreaId);
            }
            catch(Exception ex)
            {
                OnError($"TimeTrackerManager.GetUsers {ex.Message}");
            }

            return listTimeRecordings;
        }

        //public static TimeRecordingProperty GetTimeRecording(long? userId, string emailAddress)
        //{
        //    TimeRecordingProperty currentTimeRecording = default;

        //    TimeRecordingProperty timerecordingproperty = new TimeRecordingProperty();

        //    TimeRecordingDB timeRecordingDB = new TimeRecordingDB();

        //    try
        //    {
        //        currentTimeRecording = timeRecordingDB.GetTimeRecording(userId, emailAddress);
        //    }
        //    catch(Exception ex)
        //    {
        //        OnError($"UserManager.GetUserInformation {ex.Message}");
        //    }

        //    return currentTimeRecording;
        //}

        public static int UpdateCurrentUser(TimeRecordingProperty currentTimeRecording)
        {
            int result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumUpdate.Default;

            TimeRecordingDB timeRecordingDB = new TimeRecordingDB();

            try
            {
                if (!timeRecordingDB.UpdateTimeRecording(currentTimeRecording))
                {
                    result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumUpdate.Error;
                    return result;
                }

                result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumUpdate.Success;
            }
            catch(Exception ex)
            {
                OnError($"UserManager.UpdateUser {ex.Message}");
            }

            return result;
        }

        /// <summary>
        /// Return Values:
        /// Default : 0
        /// UserExists : 1
        /// Error : 2
        /// Success : 3
        /// </summary>
        public static int CreateTimeRecording(TimeRecordingProperty currentTimeRecording)
        {
            TimeRecordingDB timeRecordingDB = new TimeRecordingDB();

            int result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumInsert.Default;

            

            try
            {
                if (!timeRecordingDB.InsertTimeRecording(currentTimeRecording))
                {
                    result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumInsert.Error;
                }

                if (!timeRecordingDB.InsertTimeRecording(currentTimeRecording))
                {
                    result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumInsert.Error;
                }

                result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumInsert.Success;
            }
            catch (Exception ex)
            {
                OnError($"TimeTrackerManager.CreateTimeRecording {ex.Message}");
            }

             return result;
        }

        private void ErrorLogger(string message)
        {
            OnError($"UserManager.ErrorLogger {message}");
        }

        //GetEntries, InsertEntries, GetEntry, 




    }
}
