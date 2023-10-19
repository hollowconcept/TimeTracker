using Backend_TimeTracker.DataAccess;
using GlobalDefinitions_TimeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_TimeTracker.Management
{
    public class RequestManager
    {
        public static event OnErrorEventHandler OnError;
        public delegate void OnErrorEventHandler(string message);

        private static RequestDB RequestDB;

        public RequestManager()
        {
            RequestDB = new RequestDB();
        }

        public static List<RequestProperty> GetRequests()
        {
            List<RequestProperty> listRequests = default;

            try
            {
                listRequests = RequestDB.GetRequests();
            }
            catch(Exception ex)
            {
                OnError($"RequestManager.GetRequests {ex.Message}");
            }

            return listRequests;
        }

        public static RequestProperty GetRequest(long requestId)
        {
            RequestProperty currentRequest = default;

            try
            {
                currentRequest = RequestDB.GetRequest(requestId);
            }
            catch(Exception ex)
            {
                OnError($"RequestManager.GetRequest {ex.Message}");
            }

            return currentRequest;
        }


        public static int ApprovalLevelRequest(RequestProperty currentRequest, RequestWorkflowProperty currentRequestWorkFlow)
        {
            int result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumInsert.Default;

            try
            {
                if (!RequestDB.InsertRequestWorkFlow(currentRequestWorkFlow))
                {
                    result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumInsert.Error;
                }

                if (!RequestDB.UpdateRequest(currentRequest))
                {
                    result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumUpdate.Error;
                }

                result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumInsert.Success;
            }
            catch(Exception ex)
            {
                OnError($"RequestManager.ApproveRequest {ex.Message}"); 
            }

            return result;
        }

        public static int EditRequest(RequestProperty currentRequest)
        {
            int result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumUpdate.Default;

            try
            {
                if (!RequestDB.UpdateRequest(currentRequest))
                {
                    result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumUpdate.Error;
                }

                result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumUpdate.Success;
            }
            catch(Exception ex)
            {
                OnError($"RequestManager.EditRequest {ex.Message}");
            }

            return result;
        }

        /// <summary>
        /// Return Values:
        /// Default : 0
        /// Exists : 1
        /// Error : 2
        /// Success : 3
        /// </summary>
        public static int CreateNewRequest(RequestProperty currentRequest)
        {
            RequestDB = new RequestDB();

            int result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumInsert.Default;

            RequestWorkflowProperty currentRequestWorkFlow = new RequestWorkflowProperty();

            try
            {
                if (!RequestDB.InsertRequest(currentRequest))
                {
                    result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumInsert.Error;
                }

                if (!RequestDB.InsertRequestWorkFlow(currentRequestWorkFlow))
                {
                    result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumInsert.Error;
                }

                result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumInsert.Success;
            }
            catch(Exception ex)
            {
                OnError($"RequestManager.CreateNewRequest {ex.Message}");
            }

            return result;
        }

        private void ErrorLogger(string message)
        {
            OnError($"RequestManager.ErrorLogger {message}");
        }
    }
}
