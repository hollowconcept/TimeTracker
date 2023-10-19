using GlobalDefinitions_TimeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_TimeTracker.DataAccess
{
    public class TimeRecordingDB
    {
        public event OnErrorEventHandler OnError;
        public delegate void OnErrorEventHandler(string message);

        public SQL SQLManager;

        public TimeRecordingDB()
        {
            SQLManager = new SQL();

           
        }

        /* Luke Zwerger 04.10.2023 */
        public bool InsertTimeRecording(TimeRecordingProperty currentTimeRecording)
        {
            bool result = false;

            string sqlQuery = string.Empty;

            try
            {
                sqlQuery = "PP2K_TimeTracker_InsertTimeRecording";

                long checkId = SQLManager.ExecuteInsert(sqlQuery,
                    new string[] { "@RecordingUserID", "@CustomerID", "@ProjectID", "@BusinessAreaID", "@WorkingDate", "@WorkingHours", "@ExecutedActivity" },
                    new object[] { currentTimeRecording.RecordingUserId, currentTimeRecording.CustomerId, currentTimeRecording.ProjectId, currentTimeRecording.BusinessAreaId, currentTimeRecording.WorkingDate, currentTimeRecording.WorkingHours, currentTimeRecording.ExecutedActivity });
                
                if (checkId > 0)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                OnError($"TimeRecordingDB.InsertTimeRecording");
            }

            return result;
        }

        /* Luke Zwerger 04.10.2023 */
        public bool UpdateTimeRecording(TimeRecordingProperty currentTimeRecording)
        {
            bool result = false;

            string sqlQuery = string.Empty;

            try
            {
                sqlQuery = "PP2K_TimeTracker_UpdateTimeRecording";
            }
            catch(Exception ex)
            {
                OnError($"TimeRecordingDB.UpdateTimeRecording {ex.Message}");
            }

            return result;
        }

        /* Luke Zwerger 04.10.2023 */
        public List<TimeRecordingProperty> GetTimeRecordings(long? timeRecordingId, long? userId, long? customerId, long? projectId, long? businessAreaId)
        {
            List<TimeRecordingProperty> listTimeRecordings = new List<TimeRecordingProperty>();

            string sqlQuery = string.Empty;

            try
            {
                sqlQuery = "PP2K_TimeTracker_SelectTimeRecordings";
            }
            catch(Exception ex)
            {
                OnError($"TimeRecordingDB.GetTimeRecordings {ex.Message}");
            }

            return listTimeRecordings;
        }
    }
}
