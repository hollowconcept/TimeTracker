using GlobalDefinitions_TimeTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_TimeTracker.DataAccess
{
    public class ProjectDB
    {
        public event OnErrorEventHandler OnError;
        public delegate void OnErrorEventHandler(string message);

        /// <summary>
        /// Klassenbeschreibung: 
        /// Die Klasse ProjectDB kümmert sich um die Abwicklung der Projekte.
        /// Insert/Update/Select
        /// </summary>

        public SQL SQLManager;

        public ProjectDB()
        {
            SQLManager = new SQL();

            SQLManager.OnError += new SQL.OnErrorEventHandler(ErrorLogger);
        }

        public bool InsertProjectChangeHistory(ProjectChangeHistoryProperty currentProjectChangeHistory)
        {
            bool result = false;

            string sqlQuery = string.Empty;

            try
            {
                sqlQuery = "PP2K_TimeTracker_InsertProjectChangeHistory";

                long checkId = SQLManager.ExecuteInsert(sqlQuery,
                    new string[] { "@ProjectID", "@CustomerID", "@InitiatorUserID", "@ProjectStatusID", "@ProjectName", "@OrderNumberInternal", "@OrderNumberExternal", "@ResponsibleSalesRepresentative", "@ProjectStartTime", "@ProjectEndTime", "@ProjectHasDeadline", "@ContingentBudget", "@ContingentWorkingDays", "@ChangedByUserID", "@ChangeDate" },
                    new object[] { currentProjectChangeHistory.ProjectId, currentProjectChangeHistory.CustomerId, currentProjectChangeHistory.InitiatorUserId, currentProjectChangeHistory.ProjectStatusId, currentProjectChangeHistory.ProjectName, currentProjectChangeHistory.OrderNumberInternal, currentProjectChangeHistory.OrderNumberExternal, currentProjectChangeHistory.ResponsibleSalesRepresentative, currentProjectChangeHistory.ProjectStartTime, currentProjectChangeHistory.ProjectEndTime, currentProjectChangeHistory.ProjectHasDeadline, currentProjectChangeHistory.Contingent_Budget, currentProjectChangeHistory.Contingent_WorkingDays, currentProjectChangeHistory.ChangedByUserId, currentProjectChangeHistory.ChangeDate });

                if(checkId > 0)
                {
                    result = true;
                }
            }
            catch(Exception ex)
            {
                OnError($"ProjectDB.InsertProjectChangeHistory {ex.Message}");
            }

            return result;
        }

        /* Luke Zwerger 02.10.2023 Kontrolliert: N */
        /* Ernad Jakupovic 02.10.2023 */
        public bool InsertProject(ProjectProperty currentProject)
        {
            bool result = false;

            string sqlQuery = string.Empty;

            try
            {
                sqlQuery = "PP2K_TimeTracker_InsertProject";

                long checkId = SQLManager.ExecuteInsert(sqlQuery,
                    new string[] { "@CustomerID", "@InitiatorUserID", "@ProjectStatusID", "@ProjectName", "@OrderNumberInternal", "@OrderNumberExternal", "@ResponsibleSalesRepresentative", "@ProjectStartTime", "@ProjectEndTime", "@ProjectHasDeadline", "@ContigentBudget", "@ContigentWorkingDays" },
                    new object[] { currentProject.CustomerId, currentProject.InitiatorUserId, currentProject.ProjectStatusId, currentProject.ProjectName, currentProject.OrderNumberInternal, currentProject.OrderNumberExternal, currentProject.ResponsibleSalesRepresentative, currentProject.ProjectStartTime, currentProject.ProjectEndTime, currentProject.ProjectHasDeadline, currentProject.Contingent_Budget, currentProject.Contingent_WorkingDays });

                if(checkId > 0)
                {
                    result = true;
                }
            }
            catch(Exception ex)
            {
                OnError($"ProjectDB.InsertProject {ex.Message}");
            }

            return result;
        }

        public bool UpdateProject(ProjectProperty currentProject)
        {
            bool result = false;

            string sqlQuery = string.Empty;

            try
            {
                sqlQuery = "PP2K_TimeTracker_UpdateProject";

                result = SQLManager.ExecuteUpdate(sqlQuery,
                    new string[] { "@ProjectID", "@CustomerID", "@InitiatorUserID", "@ProjectStatusID", "@ProjectName", "@OrderNumberInternal", "@OrderNumberExternal", "@ResponsibleSalesRepresentative", "@ProjectStartTime", "@ProjectEndTime", "@ProjectHasDeadline", "@ContingentBudget", "@ContingentWorkingDays" },
                    new object[] { currentProject.Id, currentProject.CustomerId, currentProject.InitiatorUserId, currentProject.ProjectStatusId, currentProject.ProjectName, currentProject.OrderNumberInternal, currentProject.OrderNumberExternal, currentProject.ResponsibleSalesRepresentative, currentProject.ProjectStartTime, currentProject.ProjectEndTime, currentProject.ProjectHasDeadline, currentProject.Contingent_Budget, currentProject.Contingent_WorkingDays });
            }
            catch(Exception ex)
            {
                OnError($"ProjectDB.UpdateProject {ex.Message}");
            }

            return result;
        }

        public List<ProjectChangeHistoryProperty> GetProjectChangeHistorys(long? projectId)
        {
            List<ProjectChangeHistoryProperty> listProjectChangeHistory = new List<ProjectChangeHistoryProperty>();

            string sqlQuery = string.Empty;

            DataTable projectChangeTable = new DataTable();

            try
            {
                sqlQuery = "PP2K_TimeTracker_SelectProjectChangeHistory";

                projectChangeTable = SQLManager.ExecuteSelect(sqlQuery,
                    new string[] { "@ProjectID" },
                    new object[] { projectId });

                if (projectChangeTable.Rows.Count > 0)
                {
                    for (int i = 0; i < projectChangeTable.Rows.Count; i++)
                    {
                        ProjectChangeHistoryProperty currentChangeHistory = new ProjectChangeHistoryProperty();

                        if (!Convert.IsDBNull(projectChangeTable.Rows[i]["Id"]))
                        {
                            currentChangeHistory.Id = Convert.ToInt64(projectChangeTable.Rows[i]["Id"]);
                        }
                        if (!Convert.IsDBNull(projectChangeTable.Rows[i]["ProjectId"]))
                        {
                            currentChangeHistory.ProjectId = Convert.ToInt64(projectChangeTable.Rows[i]["ProjectId"]);
                        }
                        if (!Convert.IsDBNull(projectChangeTable.Rows[i]["CustomerId"]))
                        {
                            currentChangeHistory.CustomerId = Convert.ToInt64(projectChangeTable.Rows[i]["CustomerId"]);
                        }
                        if (!Convert.IsDBNull(projectChangeTable.Rows[i]["InitiatorUserId"]))
                        {
                            currentChangeHistory.InitiatorUserId = Convert.ToInt64(projectChangeTable.Rows[i]["InitiatorUserId"]);
                        }
                        if (!Convert.IsDBNull(projectChangeTable.Rows[i]["ProjectStatusId"]))
                        {
                            currentChangeHistory.ProjectStatusId = Convert.ToInt64(projectChangeTable.Rows[i]["ProjectStatusId"]);
                        }
                        if (!Convert.IsDBNull(projectChangeTable.Rows[i]["ProjectName"]))
                        {
                            currentChangeHistory.ProjectName = Convert.ToString(projectChangeTable.Rows[i]["ProjectName"]);
                        }
                        if (!Convert.IsDBNull(projectChangeTable.Rows[i]["OrderNumberInternal"]))
                        {
                            currentChangeHistory.OrderNumberInternal = Convert.ToString(projectChangeTable.Rows[i]["OrderNumberInternal"]);
                        }
                        if (!Convert.IsDBNull(projectChangeTable.Rows[i]["OrderNumberExternal"]))
                        {
                            currentChangeHistory.OrderNumberExternal = Convert.ToString(projectChangeTable.Rows[i]["OrderNumberExternal"]);
                        }
                        if (!Convert.IsDBNull(projectChangeTable.Rows[i]["ResponsibleSalesRepresentative"]))
                        {
                            currentChangeHistory.ResponsibleSalesRepresentative = Convert.ToString(projectChangeTable.Rows[i]["ResponsibleSalesRepresentative"]);
                        }
                        if (!Convert.IsDBNull(projectChangeTable.Rows[i]["ProjectStartTime"]))
                        {
                            currentChangeHistory.ProjectStartTime = Convert.ToDateTime(projectChangeTable.Rows[i]["ProjectStartTime"]);
                        }
                        if (!Convert.IsDBNull(projectChangeTable.Rows[i]["ProjectEndTime"]))
                        {
                            currentChangeHistory.ProjectEndTime = Convert.ToDateTime(projectChangeTable.Rows[i]["ProjectEndTime"]);
                        }
                        if (!Convert.IsDBNull(projectChangeTable.Rows[i]["ProjectHasDeadline"]))
                        {
                            currentChangeHistory.ProjectHasDeadline = Convert.ToBoolean(projectChangeTable.Rows[i]["ProjectHasDeadline"]);
                        }
                        if (!Convert.IsDBNull(projectChangeTable.Rows[i]["Contingent_Budget"]))
                        {
                            currentChangeHistory.Contingent_Budget = Convert.ToDecimal(projectChangeTable.Rows[i]["Contingent_Budget"]);
                        }
                        if (!Convert.IsDBNull(projectChangeTable.Rows[i]["Contingent_WorkingDays"]))
                        {
                            currentChangeHistory.Contingent_WorkingDays = Convert.ToDecimal(projectChangeTable.Rows[i]["Contingent_WorkingDays"]);
                        }
                        if (!Convert.IsDBNull(projectChangeTable.Rows[i]["ChangedByUserId"]))
                        {
                            currentChangeHistory.ChangedByUserId = Convert.ToInt64(projectChangeTable.Rows[i]["ChangedByUserId"]);
                        }
                        if (!Convert.IsDBNull(projectChangeTable.Rows[i]["ChangeDate"]))
                        {
                            currentChangeHistory.ChangeDate = Convert.ToDateTime(projectChangeTable.Rows[i]["ChangeDate"]);
                        }

                        listProjectChangeHistory.Add(currentChangeHistory);
                    }
                }
            }
            catch (Exception ex)
            {
                OnError($"ProjectDB.GetProjectChangeHistorys {ex.Message}");
            }

            return listProjectChangeHistory;
        }


        public ProjectProperty GetProject(long projectId)
        {
            ProjectProperty currentProject = new ProjectProperty();

            string sqlQuery = string.Empty;

            DataTable projectTable = new DataTable();

            try
            {
                sqlQuery = "PP2K_TimeTracker_SelectProjects";

                projectTable = SQLManager.ExecuteSelect(sqlQuery,
                    new string[] { "@ProjectID" },
                    new object[] { projectId });

                if (projectTable.Rows.Count > 0)
                {
                    for (int i = 0; i < projectTable.Rows.Count; i++)
                    {
                        if (!Convert.IsDBNull(projectTable.Rows[i]["ID"]))
                        {
                            currentProject.Id = Convert.ToInt64(projectTable.Rows[i]["ID"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["CustomerID"]))
                        {
                            currentProject.CustomerId = Convert.ToInt64(projectTable.Rows[i]["CustomerID"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["InitiatorUserID"]))
                        {
                            currentProject.InitiatorUserId = Convert.ToInt64(projectTable.Rows[i]["InitiatorUserID"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["ProjectStatusID"]))
                        {
                            currentProject.ProjectStatusId = Convert.ToInt64(projectTable.Rows[i]["ProjectStatusID"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["ProjectName"]))
                        {
                            currentProject.ProjectName = Convert.ToString(projectTable.Rows[i]["ProjectName"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["OrderNumberInternal"]))
                        {
                            currentProject.OrderNumberInternal = Convert.ToString(projectTable.Rows[i]["OrderNumberInternal"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["OrderNumberExternal"]))
                        {
                            currentProject.OrderNumberExternal = Convert.ToString(projectTable.Rows[i]["OrderNumberExternal"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["ResponsibleSalesRepresentative"]))
                        {
                            currentProject.ResponsibleSalesRepresentative = Convert.ToString(projectTable.Rows[i]["ResponsibleSalesRepresentative"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["ProjectStartTime"]))
                        {
                            currentProject.ProjectStartTime = Convert.ToDateTime(projectTable.Rows[i]["ProjectStartTime"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["ProjectEndTime"]))
                        {
                            currentProject.ProjectEndTime = Convert.ToDateTime(projectTable.Rows[i]["ProjectEndTime"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["ProjectHasDeadline"]))
                        {
                            currentProject.ProjectHasDeadline = Convert.ToBoolean(projectTable.Rows[i]["ProjectHasDeadline"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["Contingent_Budget"]))
                        {
                            currentProject.Contingent_Budget = Convert.ToDecimal(projectTable.Rows[i]["Contingent_Budget"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["Contingent_WorkingDays"]))
                        {
                            currentProject.Contingent_WorkingDays = Convert.ToDecimal(projectTable.Rows[i]["Contingent_WorkingDays"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["LastUpdate"]))
                        {
                            currentProject.LastUpdate = Convert.ToDateTime(projectTable.Rows[i]["LastUpdate"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["CreationDate"]))
                        {
                            currentProject.CreationDate = Convert.ToDateTime(projectTable.Rows[i]["CreationDate"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnError($"ProjectDB.GetProject {ex.Message}");
            }

            return currentProject;
        }


        public List<ProjectProperty> GetProjects()
        {
            List<ProjectProperty> listProjects = new List<ProjectProperty>();

            string sqlQuery = string.Empty;

            DataTable projectTable = new DataTable();

            try
            {
                sqlQuery = "PP2K_TimeTracker_SelectProjects";

                projectTable = SQLManager.ExecuteSelect(sqlQuery,
                    new string[] { },
                    new object[] { });

                if (projectTable.Rows.Count > 0)
                {
                    for (int i = 0; i < projectTable.Rows.Count; i++)
                    {
                        ProjectProperty currentProject = new ProjectProperty();

                        if (!Convert.IsDBNull(projectTable.Rows[i]["ID"]))
                        {
                            currentProject.Id = Convert.ToInt64(projectTable.Rows[i]["ID"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["CustomerID"]))
                        {
                            currentProject.CustomerId = Convert.ToInt64(projectTable.Rows[i]["CustomerID"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["InitiatorUserID"]))
                        {
                            currentProject.InitiatorUserId = Convert.ToInt64(projectTable.Rows[i]["InitiatorUserID"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["ProjectStatusID"]))
                        {
                            currentProject.ProjectStatusId = Convert.ToInt64(projectTable.Rows[i]["ProjectStatusID"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["ProjectName"]))
                        {
                            currentProject.ProjectName = Convert.ToString(projectTable.Rows[i]["ProjectName"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["OrderNumberInternal"]))
                        {
                            currentProject.OrderNumberInternal = Convert.ToString(projectTable.Rows[i]["OrderNumberInternal"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["OrderNumberExternal"]))
                        {
                            currentProject.OrderNumberExternal = Convert.ToString(projectTable.Rows[i]["OrderNumberExternal"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["ResponsibleSalesRepresentative"]))
                        {
                            currentProject.ResponsibleSalesRepresentative = Convert.ToString(projectTable.Rows[i]["ResponsibleSalesRepresentative"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["ProjectStartTime"]))
                        {
                            currentProject.ProjectStartTime = Convert.ToDateTime(projectTable.Rows[i]["ProjectStartTime"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["ProjectEndTime"]))
                        {
                            currentProject.ProjectEndTime = Convert.ToDateTime(projectTable.Rows[i]["ProjectEndTime"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["ProjectHasDeadline"]))
                        {
                            currentProject.ProjectHasDeadline = Convert.ToBoolean(projectTable.Rows[i]["ProjectHasDeadline"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["Contingent_Budget"]))
                        {
                            currentProject.Contingent_Budget = Convert.ToDecimal(projectTable.Rows[i]["Contingent_Budget"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["Contingent_WorkingDays"]))
                        {
                            currentProject.Contingent_WorkingDays = Convert.ToDecimal(projectTable.Rows[i]["Contingent_WorkingDays"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["LastUpdate"]))
                        {
                            currentProject.LastUpdate = Convert.ToDateTime(projectTable.Rows[i]["LastUpdate"]);
                        }
                        if (!Convert.IsDBNull(projectTable.Rows[i]["CreationDate"]))
                        {
                            currentProject.CreationDate = Convert.ToDateTime(projectTable.Rows[i]["CreationDate"]);
                        }

                        listProjects.Add(currentProject);
                    }
                }
            }
            catch(Exception ex)
            {
                OnError($"ProjectDB.GetProjects {ex.Message}");
            }

            return listProjects;
        }

        private void ErrorLogger(string message)
        {
            OnError($"ProjectDB.ErrorLogger {message}");
        }
    }
}
