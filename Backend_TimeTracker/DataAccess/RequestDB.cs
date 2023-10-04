using GlobalDefinitions_TimeTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_TimeTracker.DataAccess
{
    internal class RequestDB
    {
        public event OnErrorEventHandler OnError;
        public delegate void OnErrorEventHandler(string message);

        /// <summary>
        /// Klassenbeschreibung: 
        /// </summary>

        public SQL SQLManager;

        public RequestDB()
        {
            SQLManager = new SQL();

            SQLManager.OnError += new SQL.OnErrorEventHandler(ErrorLogger);
        }

        /* Luke Zwerger 02.10.2023 | Kontrolliert: N */
        /* Ernad Jakupovic 02.10.2023 */
        public bool InsertRequest(RequestProperty currentRequest)
        {
            bool result = false;

            string sqlQuery = string.Empty;

            try
            {
                sqlQuery = "PP2K_TimeTracker_InsertRequest";

                long checkId = SQLManager.ExecuteInsert(sqlQuery,
                    new string[] { "@RequestTypeID", "@RequestTypeRequestID", "@InitiatorUserID", "@StatusID" },
                    new object[] { currentRequest.RequestTypeId, currentRequest.RequestTypeRequestId, currentRequest.InitiatorUserId, currentRequest.StatusId });

                if(checkId > 0)
                {
                    result = true;
                }
            }
            catch(Exception ex)
            {
                OnError($"RequestDB.InsertRequest {ex.Message}");
            }

            return result;
        }

        /* Luke Zwerger 02.10.2023 | Kontrolliert: N */
        /* Ernad Jakupovic 02.10.2023 */
        public bool InsertRequestWorkFlow(RequestWorkflowProperty currentRequestWorkflow)
        {
            bool result = false;

            string sqlQuery = string.Empty;

            try
            {
                sqlQuery = "PP2K_TimeTracker_InsertRequestWorkFlow";

                long checkId = SQLManager.ExecuteInsert(sqlQuery,
                    new string[] { "@RequestID", "@RequestActionID", "@RequestStatusID", "@ActionUserID", "@UserRemark" },
                    new object[] { currentRequestWorkflow.RequestId, currentRequestWorkflow.RequestActionId, currentRequestWorkflow.RequestStatusId, currentRequestWorkflow.ActionUserId, currentRequestWorkflow.UserRemark });

                if(checkId > 0)
                {
                    result = true;
                }
            }
            catch(Exception ex)
            {
                OnError($"RequestDB.InsertRequestworkFlow {ex.Message}");
            }

            return result;
        }

        /* Luke Zwerger 02.10.2023 | Kontrolliert: N */
        /* Ernad Jakupovic 02.10.2023 */
        public bool UpdateRequest(RequestProperty currentRequest)
        {
            bool result = false;

            string sqlQuery = string.Empty;

            try
            {
                sqlQuery = "PP2K_TimeTracker_UpdateRequest";

                result = SQLManager.ExecuteUpdate(sqlQuery,
                    new string[] { "@ID", "@RequestTypeID", "@RequestTypeRequestID", "@InitiatorUserID", "@StatusID" },
                    new object[] { currentRequest.Id, currentRequest.RequestTypeId, currentRequest.RequestTypeRequestId });
            }
            catch(Exception ex)
            {
                OnError($"RequestDB.UpdateRequest {ex.Message}");
            }

            return result;
        }

        /* Luke Zwerger 02.10.2023 | Kontrolliert: N */
        /* Ernad Jakupovic 02.10.2023 */
        public RequestProperty GetRequest(long requestId)
        {
            RequestProperty currentRequest = new RequestProperty();

            string sqlQuery = string.Empty;

            DataTable requestTable = new DataTable();

            try
            {
                sqlQuery = "PP2K_TimeTracker_SelectRequests";

                requestTable = SQLManager.ExecuteSelect(sqlQuery,
                    new string[] { "@RequestID" },
                    new object[] { requestId });

                if(requestTable.Rows.Count > 0)
                {
                    for (int i = 0; i < requestTable.Rows.Count; i++)
                    {
                        if(!Convert.IsDBNull(requestTable.Rows[i]["ID"]))
                        {
                            currentRequest.Id = Convert.ToInt64(requestTable.Rows[i]["ID"]);
                        }
                        if (!Convert.IsDBNull(requestTable.Rows[i]["RequestTypeID"]))
                        {
                            currentRequest.RequestTypeId = Convert.ToInt64(requestTable.Rows[i]["RequestTypeID"]);
                        }
                        if (!Convert.IsDBNull(requestTable.Rows[i]["RequestTypeRequestID"]))
                        {
                            currentRequest.RequestTypeRequestId = Convert.ToInt64(requestTable.Rows[i]["RequestTypeRequestID"]);
                        }
                        if (!Convert.IsDBNull(requestTable.Rows[i]["InitiatorUserID"]))
                        {
                            currentRequest.InitiatorUserId = Convert.ToInt64(requestTable.Rows[i]["InitiatorUserID"]);
                        }
                        if (!Convert.IsDBNull(requestTable.Rows[i]["StatusID"]))
                        {
                            currentRequest.StatusId = Convert.ToInt64(requestTable.Rows[i]["StatusID"]);
                        }
                        if (!Convert.IsDBNull(requestTable.Rows[i]["CreationDate"]))
                        {
                            currentRequest.CreationDate = Convert.ToDateTime(requestTable.Rows[i]["CreationDate"]);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                OnError($"RequestDB.GetRequests {ex.Message}");
            }

            return currentRequest;
        }

        /* Luke Zwerger 02.10.2023 | Kontrolliert: N */
        /* Ernad Jakupovic 02.10.2023 */
        public List<RequestProperty> GetRequests()
        {
            List<RequestProperty> listRequests = new List<RequestProperty>();

            string sqlQuery = string.Empty;

            DataTable requestTable = new DataTable();

            try
            {
                sqlQuery = "PP2K_TimeTracker_SelectRequests";

                requestTable = SQLManager.ExecuteSelect(sqlQuery,
                    new string[] { },
                    new object[] { });

                if (requestTable.Rows.Count > 0)
                {
                    for (int i = 0; i < requestTable.Rows.Count; i++)
                    {
                        RequestProperty currentRequest = new RequestProperty();

                        if (!Convert.IsDBNull(requestTable.Rows[i]["ID"]))
                        {
                            currentRequest.Id = Convert.ToInt64(requestTable.Rows[i]["ID"]);
                        }
                        if (!Convert.IsDBNull(requestTable.Rows[i]["RequestTypeID"]))
                        {
                            currentRequest.RequestTypeId = Convert.ToInt64(requestTable.Rows[i]["RequestTypeID"]);
                        }
                        if (!Convert.IsDBNull(requestTable.Rows[i]["RequestTypeRequestID"]))
                        {
                            currentRequest.RequestTypeRequestId = Convert.ToInt64(requestTable.Rows[i]["RequestTypeRequestID"]);
                        }
                        if (!Convert.IsDBNull(requestTable.Rows[i]["InitiatorUserID"]))
                        {
                            currentRequest.InitiatorUserId = Convert.ToInt64(requestTable.Rows[i]["InitiatorUserID"]);
                        }
                        if (!Convert.IsDBNull(requestTable.Rows[i]["StatusID"]))
                        {
                            currentRequest.StatusId = Convert.ToInt64(requestTable.Rows[i]["StatusID"]);
                        }
                        if (!Convert.IsDBNull(requestTable.Rows[i]["CreationDate"]))
                        {
                            currentRequest.CreationDate = Convert.ToDateTime(requestTable.Rows[i]["CreationDate"]);
                        }

                        listRequests.Add(currentRequest);
                    }
                }
            }
            catch(Exception ex)
            {
                OnError($"RequeDB.GetRequests {ex.Message}");
            }

            return listRequests;
        }

        private void ErrorLogger(string message)
        {
            OnError($"RequestDB.ErrorLogger {message}");
        }
    }
}
