using GlobalDefinitions_TimeTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_TimeTracker.DataAccess
{
    public class RepositoryDB
    {
        public event OnErrorEventHandler OnError;
        public delegate void OnErrorEventHandler(string message);

        /// <summary>
        /// Klassenbeschreibung:
        /// </summary>

        public SQL SQLManager;

        public RepositoryDB()
        {
            SQLManager = new SQL();

            SQLManager.OnError += new SQL.OnErrorEventHandler(ErrorLogger);
        }

        /* Luke Zwerger 02.10.2023 | Kontolliert: N */
        /* Ernad Jakupovic 02.10.2023 */
        public List<BusinessAreaProperty> GetBusinessAreas()
        {
            List<BusinessAreaProperty> listBusinessAreas = new List<BusinessAreaProperty>();

            string sqlQuery = string.Empty;

            DataTable businessAreaTable = new DataTable();

            try
            {
                sqlQuery = "PP2K_TimeTracker_SelectBusinessAreas";

                businessAreaTable = SQLManager.ExecuteSelect(sqlQuery,
                    new string[] { },
                    new object[] { });

                if(businessAreaTable.Rows.Count > 0)
                {
                    for (int i = 0; i < businessAreaTable.Rows.Count; i++)
                    {
                        BusinessAreaProperty currentBusinessArea = new BusinessAreaProperty();

                        if (!Convert.IsDBNull(businessAreaTable.Rows[i]["ID"]))
                        {
                            currentBusinessArea.Id = Convert.ToInt64(businessAreaTable.Rows[i]["ID"]);
                        }
                        if (!Convert.IsDBNull(businessAreaTable.Rows[i]["BusinessAreaName"]))
                        {
                            currentBusinessArea.BusinessAreaName = Convert.ToString(businessAreaTable.Rows[i]["BusinessAreaName"]);
                        }
                        if (!Convert.IsDBNull(businessAreaTable.Rows[i]["Description"]))
                        {
                            currentBusinessArea.Description = Convert.ToString(businessAreaTable.Rows[i]["Description"]);
                        }
                        if (!Convert.IsDBNull(businessAreaTable.Rows[i]["Active"]))
                        {
                            currentBusinessArea.Active = Convert.ToBoolean(businessAreaTable.Rows[i]["Active"]);
                        }
                        if (!Convert.IsDBNull(businessAreaTable.Rows[i]["CreationDate"]))
                        {
                            currentBusinessArea.CreationDate = Convert.ToDateTime(businessAreaTable.Rows[i]["CreationDate"]);
                        }

                        listBusinessAreas.Add(currentBusinessArea);
                    }
                }
            }
            catch(Exception ex)
            {
                OnError($"RepositoryDB.GetbusinessAreas {ex.Message}");
            }

            return listBusinessAreas;
        }

        /* Luke Zwerger 02.10.2023 | Kontrolliert: N */
        /* Ernad Jakupovic 02.10.2023 */
        public List<RoleProperty> GetRoles()
        {
            List<RoleProperty> listRoles = new List<RoleProperty>();

            string sqlQuery = string.Empty;

            DataTable roleTable = new DataTable();

            try
            {
                sqlQuery = "PP2K_TimeTracker_SelectRoles";

                roleTable = SQLManager.ExecuteSelect(sqlQuery,
                    new string[] { },
                    new object[] { });

                if(roleTable.Rows.Count > 0)
                {
                    for (int i = 0; i < roleTable.Rows.Count; i++)
                    {
                        RoleProperty currentRole = new RoleProperty();

                        if (!Convert.IsDBNull(roleTable.Rows[i]["ID"]))
                        {
                            currentRole.Id = Convert.ToInt64(roleTable.Rows[i]["ID"]);
                        }
                        if (!Convert.IsDBNull(roleTable.Rows[i]["RoleName"]))
                        {
                            currentRole.RoleName = Convert.ToString(roleTable.Rows[i]["RoleName"]);
                        }
                        if (!Convert.IsDBNull(roleTable.Rows[i]["Active"]))
                        {
                            currentRole.Active = Convert.ToBoolean(roleTable.Rows[i]["Active"]);
                        }
                        if (!Convert.IsDBNull(roleTable.Rows[i]["CreationDate"]))
                        {
                            currentRole.CreationDate = Convert.ToDateTime(roleTable.Rows[i]["CreationDate"]);
                        }

                        listRoles.Add(currentRole);
                    }
                }
            }
            catch(Exception ex)
            {
                OnError($"RepositoryDB.GetRoles {ex.Message}");
            }

            return listRoles;
        }

        /* Luke Zwerger 02.10.2023 | Kontrolliert: N */
        /* Ernad Jakupovic 02.10.2023 */
        public List<StatusProperty> GetStatus()
        {
            List<StatusProperty> listStatus = new List<StatusProperty>();

            string sqlQuery = string.Empty;

            DataTable statusTable = new DataTable();

            try
            {
                sqlQuery = "PP2K_TimeTracker_SelectStatus";

                statusTable = SQLManager.ExecuteSelect(sqlQuery,
                    new string[] { },
                    new object[] { });

                if(statusTable.Rows.Count > 0)
                {
                    for (int i = 0; i < statusTable.Rows.Count; i++)
                    {
                        StatusProperty currentStatus = new StatusProperty();

                        if (!Convert.IsDBNull(statusTable.Rows[i]["ID"]))
                        {
                            currentStatus.Id = Convert.ToInt64(statusTable.Rows[i]["ID"]);
                        }
                        if (!Convert.IsDBNull(statusTable.Rows[i]["StatusName"]))
                        {
                            currentStatus.StatusName = Convert.ToString(statusTable.Rows[i]["StatusName"]);
                        }

                        listStatus.Add(currentStatus);
                    }
                }
            }
            catch(Exception ex)
            {
                OnError($"RepositoryDB.GetStatus {ex.Message}");
            }

            return listStatus;
        }

        private void ErrorLogger(string message)
        {
            OnError($"RepositoryDB.ErrorLogger {message}");
        }
    }
}
