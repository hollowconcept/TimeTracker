using GlobalDefinitions_TimeTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_TimeTracker.DataAccess
{
    internal class TimeRecordingDB
    {
        public event OnErrorEventHandler OnError;
        public delegate void OnErrorEventHandler(string message);

        public SQL SQLManager;

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

                result = SQLManager.ExecuteUpdate(sqlQuery,
                    new string[] { "@ID", "@RecordingUserId", "@CustomerId", "@ProjectId", "@BusinessAreaID", "@WorkingDate", "@WorkingHours", "@ExecutedActivity", "@Active" },
                    new object[] { currentTimeRecording.Id, currentTimeRecording.RecordingUserId, currentTimeRecording.CustomerId, currentTimeRecording.ProjectId, currentTimeRecording.BusinessAreaId, currentTimeRecording.WorkingDate, currentTimeRecording.WorkingHours, currentTimeRecording.ExecutedActivity, currentTimeRecording.Active });
            }
            catch(Exception ex)
            {
                OnError($"TimeRecordingDB.UpdateTimeRecording {ex.Message}");
            }

            return result;
        }

        /* Luke Zwerger 04.10.2023 */
        public TimeRecordingProperty GetTimeRecording(long userId, long timeRecordingId)
        {
            TimeRecordingProperty currentTimeRecording = new TimeRecordingProperty();

            string sqlQuery = string.Empty;

            DataTable timeRecordingTable = new DataTable();

            try
            {
                sqlQuery = "PP2K_TimeTracker_SelectTimeRecordings";

                timeRecordingTable = SQLManager.ExecuteSelect(sqlQuery,
                    new string[] { "@ID" },
                    new object[] { timeRecordingId });

                if (timeRecordingTable.Rows.Count > 0)
                {
                    for (int i = 0; i < timeRecordingTable.Rows.Count; i++)
                    {
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["ID"]))
                        {
                            currentTimeRecording.Id = Convert.ToInt64(timeRecordingTable.Rows[i]["ID"]);
                        }
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["RecordingUserID"]))
                        {
                            currentTimeRecording.RecordingUserId = Convert.ToInt64(timeRecordingTable.Rows[i]["RecordingUserID"]);
                        }
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["CustomerID"]))
                        {
                            currentTimeRecording.CustomerId = Convert.ToInt64(timeRecordingTable.Rows[i]["CustomerID"]);
                        }
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["ProjectID"]))
                        {
                            currentTimeRecording.ProjectId = Convert.ToInt64(timeRecordingTable.Rows[i]["ProjectID"]);
                        }
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["BusinessAreaID"]))
                        {
                            currentTimeRecording.BusinessAreaId = Convert.ToInt64(timeRecordingTable.Rows[i]["BusinessAreaID"]);
                        }
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["WorkingDate"]))
                        {
                            currentTimeRecording.WorkingDate = Convert.ToDateTime(timeRecordingTable.Rows[i]["WorkingDate"]);
                        }
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["WorkingHours"]))
                        {
                            currentTimeRecording.WorkingHours = Convert.ToInt64(timeRecordingTable.Rows[i]["WorkingHours"]);
                        }
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["ExecutedActivity"]))
                        {
                            currentTimeRecording.ExecutedActivity = Convert.ToString(timeRecordingTable.Rows[i]["ExecutedActivity"]);
                        }
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["Active"]))
                        {
                            currentTimeRecording.Active = Convert.ToBoolean(timeRecordingTable.Rows[i]["Active"]);
                        }
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["CreationDate"]))
                        {
                            currentTimeRecording.CreationDate = Convert.ToDateTime(timeRecordingTable.Rows[i]["CreationDate"]);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                OnError($"TimeRecordingDB.SelectTimeRecordings {ex.Message}");
            }

            return currentTimeRecording;
        }

        /* Luke Zwerger 04.10.2023 */
        public List<TimeRecordingProperty> GetTimeRecordings(long? id, long? userId, long? customerId, long? projectId, long? businessAreaId)
        {
            List<TimeRecordingProperty> listTimeRecordings = new List<TimeRecordingProperty>();

            string sqlQuery = string.Empty;

            DataTable timeRecordingTable = new DataTable();

            try
            {
                sqlQuery = "PP2K_TimeTracker_SelectTimeRecordings";

                timeRecordingTable = SQLManager.ExecuteSelect(sqlQuery,
                    new string[] {"@ID", "@RecordingUserID", "@CustomerID", "@ProjectID", "@BusinessAreaID" },
                    new object[] { id, userId, customerId, projectId, businessAreaId });

                if (timeRecordingTable.Rows.Count > 0)
                {
                    for (int i = 0; i < timeRecordingTable.Rows.Count; i++)
                    {
                        TimeRecordingProperty currentTimeRecordingProperty = new TimeRecordingProperty();

                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["ID"]))
                        {
                            currentTimeRecordingProperty.Id = Convert.ToInt64(timeRecordingTable.Rows[i]["ID"]);
                        }
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["RecordingUserID"]))
                        {
                            currentTimeRecordingProperty.RecordingUserId = Convert.ToInt64(timeRecordingTable.Rows[i]["RecordingUserID"]);
                        }
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["CustomerID"]))
                        {
                            currentTimeRecordingProperty.CustomerId = Convert.ToInt64(timeRecordingTable.Rows[i]["UserCustomerIDName"]);
                        }
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["ProjectID"]))
                        {
                            currentTimeRecordingProperty.ProjectId = Convert.ToInt64(timeRecordingTable.Rows[i]["ProjectID"]);
                        }
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["BusinessAreaID"]))
                        {
                            currentTimeRecordingProperty.BusinessAreaId = Convert.ToInt64(timeRecordingTable.Rows[i]["BusinessAreaID"]);
                        }
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["WorkingDate"]))
                        {
                            currentTimeRecordingProperty.WorkingDate = Convert.ToDateTime(timeRecordingTable.Rows[i]["WorkingDate"]);
                        }
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["WorkingHours"]))
                        {
                            currentTimeRecordingProperty.WorkingHours = Convert.ToInt64(timeRecordingTable.Rows[i]["WorkingHours"]);
                        }
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["ExecutedActivity"]))
                        {
                            currentTimeRecordingProperty.ExecutedActivity = Convert.ToString(timeRecordingTable.Rows[i]["ExecutedActivity"]);
                        }
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["Active"]))
                        {
                            currentTimeRecordingProperty.Active = Convert.ToBoolean(timeRecordingTable.Rows[i]["Active"]);
                        }
                        if (!Convert.IsDBNull(timeRecordingTable.Rows[i]["CreationDate"]))
                        {
                            currentTimeRecordingProperty.CreationDate = Convert.ToDateTime(timeRecordingTable.Rows[i]["CreationDate"]);
                        }

                        listTimeRecordings.Add(currentTimeRecordingProperty);
                    }
                }
            }
            catch (Exception ex)
            {
                OnError($"TimeRecordingDB.SelectTimeRecordings");
            }

            return listTimeRecordings;
        }
    }
}
