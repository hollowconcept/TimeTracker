using GlobalDefinitions_TimeTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_TimeTracker.DataAccess
{
    internal class UserDB
    {
        public event OnErrorEventHandler OnError;
        public delegate void OnErrorEventHandler(string message);

        /// <summary>
        /// Klassenbeschreibung:
        /// 
        /// </summary>

        public SQL SQLManager;

        public UserDB()
        {
            SQLManager = new SQL();

            SQLManager.OnError += new SQL.OnErrorEventHandler(ErrorLogger);
        }

        /* Luke Zwerger 02.10.2023 | Kontrolliert: N */
        /* Ernad Jakupovic 02.10.2023 */
        public bool UpdateUser(UserProperty currentUser)
        {
            bool result = false;

            string sqlQuery = string.Empty;

            try
            {
                sqlQuery = "PP2K_TimeTracker_UpdateUser";

                result = SQLManager.ExecuteUpdate(sqlQuery,
                    new string[] { "@UserID", "@DepartmentID", "@UserName", "@FirstName", "@LastName", "@EMailAddress", "@ManagerName", "@Active", "@LastLogin" },
                    new object[] { currentUser.Id, currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName, currentUser.Active, currentUser.LastLogin });
            }
            catch(Exception ex)
            {
                OnError($"UserDB.UpdateUser {ex.Message}");
            }

            return result;
        }

        /* Luke Zwerger 02.10.2023 | Kontrolliert: N */
        /* Ernad Jakupovic 02.10.2023 */
        public bool InsertUser(UserProperty currentUser)
        {
            bool result = false;

            string sqlQuery = string.Empty;

            try
            {
                sqlQuery = "PP2K_TimeTracker_InsertUser";

                long checkId = SQLManager.ExecuteInsert(sqlQuery,
                    new string[] { "@DepartmentID", "@UserName", "@FirstName", "@LastName", "@EMailAddress", "@ManagerName" },
                    new object[] { currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastLogin, currentUser.EMailAddress, currentUser.ManagerName });

                if(checkId > 0)
                {
                    result = true;
                }
            }
            catch(Exception ex)
            {
                OnError($"UserDB.InsertUser {ex.Message}");
            }

            return result;
        }

        /* Luke Zwerger 02.10.2023 | Kontrolliert: N */
        /* Ernad Jakupovic 02.10.2023 */
        public UserProperty GetUser(long? userId, string emailAddress)
        {
            UserProperty currentUser = new UserProperty();

            string sqlQuery = string.Empty;

            DataTable userTable = new DataTable();

            try
            {
                sqlQuery = "PP2K_TimeTracker_SelectUsers";

                userTable = SQLManager.ExecuteSelect(sqlQuery,
                    new string[] { "@UserID", "@EMailAddress" },
                    new object[] { userId, emailAddress });

                if(userTable.Rows.Count > 0)
                {
                    for (int i = 0; i < userTable.Rows.Count; i++)
                    {
                        if (!Convert.IsDBNull(userTable.Rows[i]["ID"]))
                        {
                            currentUser.Id = Convert.ToInt64(userTable.Rows[i]["ID"]);
                        }
                        if (!Convert.IsDBNull(userTable.Rows[i]["DepartmentID"]))
                        {
                            currentUser.DepartmentId = Convert.ToInt64(userTable.Rows[i]["DepartmentID"]);
                        }
                        if (!Convert.IsDBNull(userTable.Rows[i]["UserName"]))
                        {
                            currentUser.UserName = Convert.ToString(userTable.Rows[i]["UserName"]);
                        }
                        if (!Convert.IsDBNull(userTable.Rows[i]["FirstName"]))
                        {
                            currentUser.FirstName = Convert.ToString(userTable.Rows[i]["FirstName"]);
                        }
                        if (!Convert.IsDBNull(userTable.Rows[i]["LastName"]))
                        {
                            currentUser.LastName = Convert.ToString(userTable.Rows[i]["LastName"]);
                        }
                        if (!Convert.IsDBNull(userTable.Rows[i]["EMailAddress"]))
                        {
                            currentUser.EMailAddress = Convert.ToString(userTable.Rows[i]["EMailAddress"]);
                        }
                        if (!Convert.IsDBNull(userTable.Rows[i]["ManagerName"]))
                        {
                            currentUser.ManagerName = Convert.ToString(userTable.Rows[i]["ManagerName"]);
                        }
                        if (!Convert.IsDBNull(userTable.Rows[i]["Active"]))
                        {
                            currentUser.Active = Convert.ToBoolean(userTable.Rows[i]["Active"]);
                        }
                        if (!Convert.IsDBNull(userTable.Rows[i]["LastLogin"]))
                        {
                            currentUser.LastLogin = Convert.ToDateTime(userTable.Rows[i]["LastLogin"]);
                        }
                        if (!Convert.IsDBNull(userTable.Rows[i]["CreationDate"]))
                        {
                            currentUser.CreationDate = Convert.ToDateTime(userTable.Rows[i]["CreationDate"]);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                OnError($"UserDB.GetUser {ex.Message}");
            }

            return currentUser;
        }

        /* Luke Zwerger 02.10.2023 | Kontrolliert: N */
        /* Ernad Jakupovic 02.10.2023 */
        public List<UserProperty> GetUsers()
        {
            List<UserProperty> listUsers = new List<UserProperty>();

            string sqlQuery = string.Empty;

            DataTable userTable = new DataTable();

            try
            {
                sqlQuery = "PP2K_TimeTracker_SelectUsers";

                userTable = SQLManager.ExecuteSelect(sqlQuery,
                    new string[] { },
                    new object[] { });

                if(userTable.Rows.Count > 0)
                {
                    for (int i = 0; i < userTable.Rows.Count; i++)
                    {
                        UserProperty currentUser = new UserProperty();

                        if (!Convert.IsDBNull(userTable.Rows[i]["ID"]))
                        {
                            currentUser.Id = Convert.ToInt64(userTable.Rows[i]["ID"]);
                        }
                        if (!Convert.IsDBNull(userTable.Rows[i]["DepartmentID"]))
                        {
                            currentUser.DepartmentId = Convert.ToInt64(userTable.Rows[i]["DepartmentID"]);
                        }
                        if (!Convert.IsDBNull(userTable.Rows[i]["UserName"]))
                        {
                            currentUser.UserName = Convert.ToString(userTable.Rows[i]["UserName"]);
                        }
                        if (!Convert.IsDBNull(userTable.Rows[i]["FirstName"]))
                        {
                            currentUser.FirstName = Convert.ToString(userTable.Rows[i]["FirstName"]);
                        }
                        if (!Convert.IsDBNull(userTable.Rows[i]["LastName"]))
                        {
                            currentUser.LastName = Convert.ToString(userTable.Rows[i]["LastName"]);
                        }
                        if (!Convert.IsDBNull(userTable.Rows[i]["EMailAddress"]))
                        {
                            currentUser.EMailAddress = Convert.ToString(userTable.Rows[i]["EMailAddress"]);
                        }
                        if (!Convert.IsDBNull(userTable.Rows[i]["ManagerName"]))
                        {
                            currentUser.ManagerName = Convert.ToString(userTable.Rows[i]["ManagerName"]);
                        }
                        if (!Convert.IsDBNull(userTable.Rows[i]["Active"]))
                        {
                            currentUser.Active = Convert.ToBoolean(userTable.Rows[i]["Active"]);
                        }
                        if (!Convert.IsDBNull(userTable.Rows[i]["LastLogin"]))
                        {
                            currentUser.LastLogin = Convert.ToDateTime(userTable.Rows[i]["LastLogin"]);
                        }
                        if (!Convert.IsDBNull(userTable.Rows[i]["CreationDate"]))
                        {
                            currentUser.CreationDate = Convert.ToDateTime(userTable.Rows[i]["CreationDate"]);
                        }

                        listUsers.Add(currentUser);
                    }
                }
            }
            catch(Exception ex)
            {
                OnError($"UserDB.GetUsers {ex.Message}");
            }

            return listUsers;
        }

        public List<UserRoleProperty> GetUserRoles(long userId)
        {
            List<UserRoleProperty> listUserRoles = new List<UserRoleProperty>();

            string sqlQuery = string.Empty;

            DataTable userRoleTable = new DataTable();

            try
            {
                sqlQuery = "PP2K_TimeTracker_SelectUserRoles";

                userRoleTable = SQLManager.ExecuteSelect(sqlQuery,
                    new string[] { "@UserID" },
                    new object[] { userId });

                if(userRoleTable.Rows.Count > 0)
                {
                    for (int i = 0; i < userRoleTable.Rows.Count; i++)
                    {
                        UserRoleProperty currentUserRole = new UserRoleProperty();

                        if (!Convert.IsDBNull(userRoleTable.Rows[i]["ID"]))
                        {
                            currentUserRole.Id = Convert.ToInt64(userRoleTable.Rows[i]["ID"]);
                        }
                        if (!Convert.IsDBNull(userRoleTable.Rows[i]["RoleName"]))
                        {
                            currentUserRole.RoleName = Convert.ToString(userRoleTable.Rows[i]["RoleName"]);
                        }
                        if (!Convert.IsDBNull(userRoleTable.Rows[i]["Active"]))
                        {
                            currentUserRole.Active = Convert.ToBoolean(userRoleTable.Rows[i]["Active"]);
                        }
                        if (!Convert.IsDBNull(userRoleTable.Rows[i]["CreationDate"]))
                        {
                            currentUserRole.CreationDate = Convert.ToDateTime(userRoleTable.Rows[i]["CreationDate"]);
                        }

                        listUserRoles.Add(currentUserRole);
                    }
                }
            }
            catch(Exception ex)
            {
                OnError($"UserDB.GetUserRoles {ex.Message}");
            }

            return listUserRoles;
        }

        private void ErrorLogger(string message)
        {
            OnError($"UserDB.ErrorLogger {message}");
        }
    }
}
