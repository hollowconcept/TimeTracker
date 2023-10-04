using Backend_TimeTracker.DataAccess;
using GlobalDefinitions_TimeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_TimeTracker.Management
{
    public class UserManager
    {
        public static event OnErrorEventHandler OnError;
        public delegate void OnErrorEventHandler(string message);

        private static UserDB UserDB;

        public UserManager()
        {
            UserDB = new UserDB();

            UserDB.OnError += new UserDB.OnErrorEventHandler(ErrorLogger);
        }

        public static List<UserProperty> GetUsers()
        {
            List<UserProperty> listUsers = default;

            UserDB = new UserDB();

            try
            {
                listUsers = UserDB.GetUsers();
            }
            catch(Exception ex)
            {
                OnError($"UserManager.GetUsers {ex.Message}");
            }

            return listUsers;
        }

        public static UserProperty GetUserInformation(long? userId, string emailAddress)
        {
            UserProperty currentUser = default;

            UserDB = new UserDB();

            try
            {
                currentUser = UserDB.GetUser(userId, emailAddress);
            }
            catch(Exception ex)
            {
                OnError($"UserManager.GetUserInformation {ex.Message}");
            }

            return currentUser;
        }

        public static int UpdateCurrentUser(UserProperty currentUser)
        {
            int result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumUpdate.Default;

            try
            {
                if (!UserDB.UpdateUser(currentUser))
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
        public static int CreateUser(UserProperty currentUser)
        {
            int result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumInsert.Default;

            UserDB = new UserDB();

            try
            {
                UserProperty checkUserExists = UserDB.GetUser(null, currentUser.EMailAddress);

                // User existiert - Aktualisieren
                if (checkUserExists != null)
                {
                    currentUser.Id = checkUserExists.Id;
                    currentUser.LastLogin = DateTime.Now;

                    if (!UserDB.UpdateUser(currentUser))
                    {
                        result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumInsert.Error;
                        return result;
                    }
                }
                // User exestiert nicht - Neu hinzufügen
                else
                {
                    if (!UserDB.InsertUser(currentUser))
                    {
                        result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumInsert.Error;
                        return result;
                    }
                }

                result = (int)GlobalDefinitions_TimeTracker.Models.EnumProperty.EnumInsert.Success;
            }
            catch (Exception ex)
            {
                OnError($"UserManager.InsertUser {ex.Message}");
            }

            return result;
        }

        private void ErrorLogger(string message)
        {
            OnError($"UserManager.ErrorLogger {message}");
        }
    }
}
