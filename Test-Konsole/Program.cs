using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend_TimeTracker.DataAccess;
using GlobalDefinitions_TimeTracker.Models;

namespace Test_Konsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserDB userDB = new UserDB();

            ProjectDB projectDB = new ProjectDB();

            RepositoryDB repositoryDB = new RepositoryDB();

            RequestDB requestDB = new RequestDB();

            TimeRecordingDB timeRecordingDB = new TimeRecordingDB();

            CustomerrDB customerrDB = new CustomerrDB();

            //#region InsertUser
            //UserProperty currentUser = new UserProperty();

            ////currentUser.Id = 1;
            //currentUser.DepartmentId = 1;
            //currentUser.FirstName = "Ernad";
            //currentUser.LastName = "Jakupovic";
            //currentUser.UserName = "EJ";
            //currentUser.EMailAddress = "EJ@gmail.com";
            //currentUser.ManagerName = "Managername";
            //currentUser.Active = true;

            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //if (userDB.InsertUser(currentUser))
            //{
            //    Console.WriteLine("Methode InsertUser hat funktioniert");
            //}
            //else
            //{
            //    Console.WriteLine("Methode InsertUser hat nicht funktioniert");
            //}
            //#endregion
            //////Insertfunktion wurde erfolgreich ausgeführt.

            //#region UpdateUser
            //UserProperty currentUser = new UserProperty();

            //currentUser.Id = 1;
            //currentUser.DepartmentId = 2;
            //currentUser.FirstName = "Ernad";
            //currentUser.LastName = "Jakupovic";
            //currentUser.UserName = "EJ";
            //currentUser.EMailAddress = "EJ@gmail.com";
            //currentUser.ManagerName = "Managername";
            //currentUser.Active = true;
            //currentUser.LastLogin = DateTime.Now;

            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //if (userDB.UpdateUser(currentUser))
            //{
            //    Console.WriteLine("Methode UpdateUser hat funktioniert");
            //}
            //else
            //{
            //    Console.WriteLine("Methode UpdateUser hat nicht funktioniert");
            //}
            ////EXECUTE - UPDATE - FEHLER Could not find stored procedure 'PP2K_TimeTracker_UpdateUser'.
            //#endregion

            //#region GetUser
            //UserProperty currentUser = new UserProperty();

            //long? userId = 9;


            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //Console.Write(userDB.GetUser(userId));
            ////GetUser Funktion erfolgreich ausgeführt.
            //#endregion

            //#region GetUsers
            //UserProperty currentUser = new UserProperty();

            //List<UserProperty> listUsers = new List<UserProperty>();


            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //Console.Write(userDB.GetUsers());
            //Console.Write(listUsers);
            ////GetUsers Funktion wurde erfolgreich ausgeführt.
            //#endregion

            //#region GetUserRoles
            //UserRoleProperty currentUserRole = new UserRoleProperty();

            //List<UserRoleProperty> listUserRoles = new List<UserRoleProperty>();

            //long userId = 9;
            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //Console.Write(userDB.GetUserRoles(userId));
            //Console.Write(listUserRoles);
            ////GetUserRoles Funktion wurde erfolgreich ausgeführt.
            //#endregion


            //ProjectDB


            //#region InsertProject
            //ProjectProperty currentProject = new ProjectProperty();

            ////currentUser.Id = 1;
            //currentProject.CustomerId = 1;
            //currentProject.InitiatorUserId = 9;
            //currentProject.ProjectStatusId = 2;
            //currentProject.ProjectName = "EJ";
            //currentProject.OrderNumberInternal = "Ordernumber";
            //currentProject.OrderNumberExternal = "ordernumber";
            //currentProject.ResponsibleSalesRepresentative = "Man";
            //currentProject.ProjectStartTime = DateTime.Now;
            //currentProject.ProjectEndTime = DateTime.Now;
            //currentProject.ProjectHasDeadline = true;
            //currentProject.Contingent_Budget = 2;
            //currentProject.Contingent_WorkingDays = 2;
            ////currentUser.Active = true;
            ////currentUser.CreationDate = DateTime.Now;
            ////currentUser.LastLogin = DateTime.Now;

            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //if (projectDB.InsertProject(currentProject))
            //{
            //    Console.WriteLine("Methode InsertProject hat funktioniert");
            //}
            //else
            //{
            //    Console.WriteLine("Methode InsertProject hat nicht funktioniert");
            //}
            //#endregion
            ////Funktion InsertProject wurde erfolgreich ausgeführt.

            //#region UpdateProject
            //ProjectProperty currentProject = new ProjectProperty();


            //currentProject.CustomerId = 1;
            //currentProject.InitiatorUserId = 9;
            //currentProject.ProjectStatusId = 2;
            //currentProject.ProjectName = "EJ";
            //currentProject.OrderNumberInternal = "Ordernumber";
            //currentProject.OrderNumberExternal = "ordernumber";
            //currentProject.ResponsibleSalesRepresentative = "Man";
            //currentProject.ProjectStartTime = DateTime.Now;
            //currentProject.ProjectEndTime = DateTime.Now;
            //currentProject.ProjectHasDeadline = true;
            //currentProject.Contingent_Budget = 2;
            //currentProject.Contingent_WorkingDays = 2;




            //if (projectDB.UpdateProject(currentProject))
            //{
            //    Console.WriteLine("Methode UpdateProject hat funktioniert");
            //}
            //else
            //{
            //    Console.WriteLine("Methode UpdateProject hat nicht funktioniert");
            //}
            //#endregion
            //////EXECUTE - UPDATE - FEHLER Could not find stored procedure 'PP2K_TimeTracker_UpdateProject'.

            //#region InsertProjectChangeHistory
            //ProjectChangeHistoryProperty currentprojectChangeHistory = new ProjectChangeHistoryProperty();

            ////currentUser.Id = 1;
            //currentprojectChangeHistory.ProjectId = 3;
            //currentprojectChangeHistory.CustomerId = 1;
            //currentprojectChangeHistory.InitiatorUserId = 9;
            //currentprojectChangeHistory.ProjectStatusId = 2;
            //currentprojectChangeHistory.ProjectName = "EJ";
            //currentprojectChangeHistory.OrderNumberInternal = "Ordernumber";
            //currentprojectChangeHistory.OrderNumberExternal = "ordernumber";
            //currentprojectChangeHistory.ResponsibleSalesRepresentative = "Man";
            //currentprojectChangeHistory.ProjectStartTime = DateTime.Now;
            //currentprojectChangeHistory.ProjectEndTime = DateTime.Now;
            //currentprojectChangeHistory.ProjectHasDeadline = true;
            //currentprojectChangeHistory.Contingent_Budget = 2;
            //currentprojectChangeHistory.Contingent_WorkingDays = 2;
            //currentprojectChangeHistory.ChangedByUserId = 9;
            //currentprojectChangeHistory.ChangeDate = DateTime.Now;
            ////currentUser.Active = true;
            ////currentUser.CreationDate = DateTime.Now;
            ////currentUser.LastLogin = DateTime.Now;

            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //if (projectDB.InsertProjectChangeHistory(currentprojectChangeHistory))
            //{
            //    Console.WriteLine("Methode InsertProjectChangeHistory hat funktioniert");
            //}
            //else
            //{
            //    Console.WriteLine("Methode InsertProjectChangeHistory hat nicht funktioniert");
            //}
            //#endregion
            ////Funktion InsertProjectChangeHistory wurde erfolgreich ausgeführt.
            ///

            //#region GetProjectChangeHistorys
            //ProjectChangeHistoryProperty currentPropertyChangeHistory = new ProjectChangeHistoryProperty();

            //List<ProjectChangeHistoryProperty> listprojectChangeHistories = new List<ProjectChangeHistoryProperty>();

            //long? projectId = 3;

            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //Console.Write(projectDB.GetProjectChangeHistorys(projectId));
            //Console.Write(listprojectChangeHistories);
            ////"[EXECUTE-SELECT-FEHLER] Could not find stored procedure 'PP2K_TimeTracker_SelectProjectChangeHistory'."
            //#endregion

            //#region GetProject
            //ProjectProperty currentProject = new ProjectProperty();

            //long projectId = 3;

            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //Console.Write(projectDB.GetProject(projectId));

            ////"[EXECUTE-SELECT-FEHLER] Could not find stored procedure 'PP2K_TimeTracker_SelectProjects'."
            //#endregion

            //#region GetProjects
            //ProjectProperty currentProject = new ProjectProperty();

            //long projectId = 3;

            //List<ProjectProperty> listProjects = new List<ProjectProperty>();


            //Console.Write(projectDB.GetProjects());
            //Console.Write(listProjects);

            ////"[EXECUTE-SELECT-FEHLER] Could not find stored procedure 'PP2K_TimeTracker_SelectProjects'."
            //#endregion

            //#region GetBusinessAreas
            //BusinessAreaProperty currentbusinessArea = new BusinessAreaProperty();

            //List<BusinessAreaProperty> listbusinessAreas = new List<BusinessAreaProperty>();


            //Console.Write(repositoryDB.GetBusinessAreas());
            //Console.Write(listbusinessAreas);

            ////Funktion GetBusinessAreas wurde erfolgreich ausgeführt.
            //#endregion

            //#region GetRoles
            //RoleProperty currentRole = new RoleProperty();

            //List<RoleProperty> listRoles = new List<RoleProperty>();


            //Console.Write(repositoryDB.GetRoles());
            //Console.Write(listRoles);

            ////Funktion GetRoles wurde erfolgreich ausgeführt.
            //#endregion

            //#region GetStatus
            //StatusProperty currentStatus = new StatusProperty();

            //List<StatusProperty> listStatus = new List<StatusProperty>();


            //Console.Write(repositoryDB.GetStatus());
            //Console.Write(listStatus);

            ////"[EXECUTE-SELECT-FEHLER] Could not find stored procedure 'PP2K_TimeTracker_SelectStatus'."
            //#endregion


            //#region InsertProjectChangeHistory
            //ProjectChangeHistoryProperty currentprojectChangeHistory = new ProjectChangeHistoryProperty();

            ////currentUser.Id = 1;
            //currentprojectChangeHistory.ProjectId = 3;
            //currentprojectChangeHistory.CustomerId = 1;
            //currentprojectChangeHistory.InitiatorUserId = 9;
            //currentprojectChangeHistory.ProjectStatusId = 2;
            //currentprojectChangeHistory.ProjectName = "EJ";
            //currentprojectChangeHistory.OrderNumberInternal = "Ordernumber";
            //currentprojectChangeHistory.OrderNumberExternal = "ordernumber";
            //currentprojectChangeHistory.ResponsibleSalesRepresentative = "Man";
            //currentprojectChangeHistory.ProjectStartTime = DateTime.Now;
            //currentprojectChangeHistory.ProjectEndTime = DateTime.Now;
            //currentprojectChangeHistory.ProjectHasDeadline = true;
            //currentprojectChangeHistory.Contingent_Budget = 2;
            //currentprojectChangeHistory.Contingent_WorkingDays = 2;
            //currentprojectChangeHistory.ChangedByUserId = 9;
            //currentprojectChangeHistory.ChangeDate = DateTime.Now;
            ////currentUser.Active = true;
            ////currentUser.CreationDate = DateTime.Now;
            ////currentUser.LastLogin = DateTime.Now;

            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //if (projectDB.InsertProjectChangeHistory(currentprojectChangeHistory))
            //{
            //    Console.WriteLine("Methode InsertProjectChangeHistory hat funktioniert");
            //}
            //else
            //{
            //    Console.WriteLine("Methode InsertProjectChangeHistory hat nicht funktioniert");
            //}
            //#endregion
            ////Funktion InsertProjectChangeHistory wurde erfolgreich ausgeführt.


            //#region InsertCustomer
            //CustomerProperty currentCustomer = new CustomerProperty();

            ////currentUser.Id = 1;
            //currentCustomer.InitiatorUserId = 9;
            //currentCustomer.CustomerName = "Ernad";
            //currentCustomer.CustomerNumber = "Jakupovic";
            //currentCustomer.ResponsibleSalesRepresentative = "EJ";


            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //if (customerrDB.InsertCustomer(currentCustomer))
            //{
            //    Console.WriteLine("Methode InsertCustomer hat funktioniert");
            //}
            //else
            //{
            //    Console.WriteLine("Methode InsertCustomer hat nicht funktioniert");
            //}
            //#endregion
            //////InsertCustomer funktion wurde erfolgreich ausgeführt.

            //#region UpdateCustomer
            //CustomerProperty currentCustomer = new CustomerProperty();

            //currentCustomer.Id = 1;
            //currentCustomer.InitiatorUserId = 9;
            //currentCustomer.CustomerName = "Jakupovic";
            //currentCustomer.CustomerNumber = "12";
            //currentCustomer.ResponsibleSalesRepresentative = "EJ";
            //currentCustomer.Active = true;


            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //if (customerrDB.UpdateCustomer(currentCustomer))
            //{
            //    Console.WriteLine("Methode UpdateCustomer hat funktioniert");
            //}
            //else
            //{
            //    Console.WriteLine("Methode UpdateCustomer hat nicht funktioniert");
            //}
            //#endregion
            //////UpdateCustomer funktion wurde erfolgreich ausgeführt.

            //#region GetCustomer
            //CustomerProperty currentCustomer = new CustomerProperty();

            //long customerId = 2;


            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //Console.Write(customerrDB.GetCustomer(customerId));
            ////GetCustomer Funktion erfolgreich ausgeführt.
            //#endregion

            //#region GetCustomers
            //CustomerProperty currentCustomer = new CustomerProperty();

            //List<CustomerProperty> listCustomers = new List<CustomerProperty>();


            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //Console.Write(customerrDB.GetCustomers());
            //Console.Write(listCustomers);
            ////GetCustomers Funktion wurde erfolgreich ausgeführt.
            //#endregion

            // #region InsertRequest
            //RequestProperty currentRequest = new RequestProperty();

            // //currentUser.Id = 1;
            // currentRequest.RequestTypeId = 1;
            // currentRequest.RequestTypeRequestId = 1;
            // currentRequest.InitiatorUserId = 9;
            // currentRequest.StatusId = 1;

            // //currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            // if (requestDB.InsertRequest(currentRequest))
            // {
            //     Console.WriteLine("Methode InsertRequest hat funktioniert");
            // }
            // else
            // {
            //     Console.WriteLine("Methode InsertRequest hat nicht funktioniert");
            // }
            // #endregion
            // ////Insertfunktion wurde erfolgreich ausgeführt.

            //#region UpdateRequest
            //RequestProperty currentRequest = new RequestProperty();

            //currentRequest.Id = 1;
            //currentRequest.RequestTypeId = 2;
            //currentRequest.RequestTypeRequestId = 1;
            //currentRequest.InitiatorUserId = 9;
            //currentRequest.StatusId = 1;

            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //if (requestDB.UpdateRequest(currentRequest))
            //{
            //    Console.WriteLine("Methode UpdateRequest hat funktioniert");
            //}
            //else
            //{
            //    Console.WriteLine("Methode UpdateRequest hat nicht funktioniert");
            //}
            //#endregion
            //////UpdateRequest funktion wurde erfolgreich ausgeführt.

            //#region GetRequest
            //RequestProperty currentRequest = new RequestProperty();

            //long customerId = 2;


            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //Console.Write(requestDB.GetRequest(customerId));
            ////SelectRequests Procedure fehlt

            //#endregion

            //#region GetRequests
            //RequestProperty currentRequest = new RequestProperty();

            //List<RequestProperty> listRequests = new List<RequestProperty>();


            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //Console.Write(requestDB.GetRequests());
            //Console.Write(listRequests);
            ////Stored Procedure SelectRequests Missing
            //#endregion

            //TimeRecordingDB

            //#region InsertTimeRecording
            //TimeRecordingProperty currentTimeRecording = new TimeRecordingProperty();


            //currentTimeRecording.RecordingUserId = 9;
            //currentTimeRecording.CustomerId = 1;
            //currentTimeRecording.ProjectId = 3;
            //currentTimeRecording.BusinessAreaId = 1;
            //currentTimeRecording.WorkingDate = DateTime.Now;
            //currentTimeRecording.WorkingHours = 8;
            //currentTimeRecording.ExecutedActivity = "EJ";





            //if (timeRecordingDB.InsertTimeRecording(currentTimeRecording))
            //{
            //    Console.WriteLine("Methode InsertTimeRecording hat funktioniert");
            //}
            //else
            //{
            //    Console.WriteLine("Methode InsertTimeRecording hat nicht funktioniert");
            //}
            //#endregion
            ////InsertTimeRecording Object rEFERENCE not set to object.

            //#region UpdateTimeRecording
            //TimeRecordingProperty currentTimeRecording = new TimeRecordingProperty();

            ////currentUser.Id = 1;
            //currentTimeRecording.Id = 5;
            //currentTimeRecording.RecordingUserId = 9;
            //currentTimeRecording.CustomerId = 1;
            //currentTimeRecording.ProjectId = 3;
            //currentTimeRecording.BusinessAreaId = 1;
            //currentTimeRecording.WorkingDate = DateTime.Now;
            //currentTimeRecording.WorkingHours = Decimal.TryParse();
            //currentTimeRecording.ExecutedActivity = "EJ";
            //currentTimeRecording.Active = true;


            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //if (timeRecordingDB.UpdateTimeRecording(currentTimeRecording))
            //{
            //    Console.WriteLine("Methode UpdateTimeRecording hat funktioniert");
            //}
            //else
            //{
            //    Console.WriteLine("Methode UpdateTimeRecording hat nicht funktioniert");
            //}
            //#endregion
            //////InsertTimeRecording Object rEFERENCE not set to object.


            //#region GetTimeRecording
            //TimeRecordingProperty currentTimeRecording = new TimeRecordingProperty();

            //long? userId = 9;
            //long? timerecordingId = 1;
            //long? customerId = 2;
            //long? projectId = 1;
            //long? businessAreaId = 1;


            ////currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            //Console.Write(timeRecordingDB.GetTimeRecording(userId, timerecordingId, customerId, projectId, businessAreaId));
            ////SelectRequests Procedure fehlt

            //#endregion

            #region GetTimeRecordings
            TimeRecordingProperty currentTimeRecording = new TimeRecordingProperty();

            List<TimeRecordingProperty> listTimeRecordings = new List<TimeRecordingProperty>();

            long? userId = 9;
            long? timerecordingId = 1;
            long? customerId = 2;
            long? projectId = 1;
            long? businessAreaId = 1;


            //currentUser.DepartmentId, currentUser.UserName, currentUser.FirstName, currentUser.LastName, currentUser.EMailAddress, currentUser.ManagerName


            Console.Write(timeRecordingDB.GetTimeRecordings(userId, timerecordingId, customerId, projectId, businessAreaId));
            Console.Write(listTimeRecordings);
            //Stored Procedure SelectRequests Missing
            #endregion




        }
    }
}
