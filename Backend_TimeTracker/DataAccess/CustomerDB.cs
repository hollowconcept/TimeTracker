using GlobalDefinitions_TimeTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_TimeTracker.DataAccess
{
    public class CustomerDB
    {
        public event OnErrorEventHandler OnError;
        public delegate void OnErrorEventHandler(string message);

        /// <summary>
        /// Klassenbeschreibung 
        /// 
        /// </summary>

        public SQL SQLManager;

        public CustomerDB()
        {
            SQLManager = new SQL();

            SQLManager.OnError += new SQL.OnErrorEventHandler(ErrorLogger);
        }

        public bool UpdateCustomer(CustomerProperty currentCustomer)
        {
            bool result = false;

            string sqlQuery = string.Empty;

            try
            {
                sqlQuery = "PP2K_TimeTracker_UpdateCustomer";

                result = SQLManager.ExecuteUpdate(sqlQuery,
                    new string[] { "@ID", "@InitiatorUserID", "@CustomerName", "@CustomerNumber", "@ResponsibleSalesRepresentative", "@Active" },
                    new object[] { currentCustomer.Id, currentCustomer.InitiatorUserId, currentCustomer.CustomerName, currentCustomer.CustomerNumber, currentCustomer.ResponsibleSalesRepresentative, currentCustomer.Active });
            }
            catch(Exception ex)
            {
                OnError($"CustomerDB.UpdateCustomer {ex.Message}");
            }

            return result;
        }

        public bool InsertCustomer(CustomerProperty currentCustomer)
        {
            bool result = false;

            string sqlQuery = string.Empty;

            try
            {
                sqlQuery = "PP2K_TimeTracker_InsertCustomer";

                long checkId = SQLManager.ExecuteInsert(sqlQuery,
                    new string[] { "@InitiatorUserID", "@CustomerName", "@CustomerNumber", "@ResponsibleSalesRepresentative" },
                    new object[] { currentCustomer.InitiatorUserId, currentCustomer.CustomerName, currentCustomer.CustomerNumber, currentCustomer.ResponsibleSalesRepresentative });

                if(checkId > 0)
                {
                    result = true;
                }
            }
            catch(Exception ex)
            {
                OnError($"CustomerDB.InsertCustomer {ex.Message}");
            }

            return result;
        }

        public CustomerProperty GetCustomer(long customerId)
        {
            CustomerProperty currentCustomer = new CustomerProperty();

            string sqlQuery = string.Empty;

            DataTable customerTable = new DataTable();

            try
            {
                sqlQuery = "PP2K_TimeTracker_SelectCustomers";

                customerTable = SQLManager.ExecuteSelect(sqlQuery,
                    new string[] { "@CustomerID" },
                    new object[] { customerId });

                if(customerTable.Rows.Count > 0)
                {
                    for (int i = 0; i < customerTable.Rows.Count; i++)
                    {
                        if (!Convert.IsDBNull(customerTable.Rows[i]["ID"]))
                        {
                            currentCustomer.Id = Convert.ToInt64(customerTable.Rows[i]["ID"]);
                        }
                        if (!Convert.IsDBNull(customerTable.Rows[i]["RequestID"]))
                        {
                            currentCustomer.RequestId = Convert.ToInt64(customerTable.Rows[i]["RequestID"]);
                        }
                        if (!Convert.IsDBNull(customerTable.Rows[i]["InitiatorUserID"]))
                        {
                            currentCustomer.InitiatorUserId = Convert.ToInt64(customerTable.Rows[i]["InitiatorUserID"]);
                        }
                        if (!Convert.IsDBNull(customerTable.Rows[i]["CustomerName"]))
                        {
                            currentCustomer.CustomerName = Convert.ToString(customerTable.Rows[i]["CustomerName"]);
                        }
                        if (!Convert.IsDBNull(customerTable.Rows[i]["CustomerNumber"]))
                        {
                            currentCustomer.CustomerNumber = Convert.ToString(customerTable.Rows[i]["CustomerNumber"]);
                        }
                        if (!Convert.IsDBNull(customerTable.Rows[i]["ResponsibleSalesRepresentative"]))
                        {
                            currentCustomer.ResponsibleSalesRepresentative = Convert.ToString(customerTable.Rows[i]["ResponsibleSalesRepresentative"]);
                        }
                        if (!Convert.IsDBNull(customerTable.Rows[i]["Active"]))
                        {
                            currentCustomer.Active = Convert.ToBoolean(customerTable.Rows[i]["Active"]);
                        }
                        if (!Convert.IsDBNull(customerTable.Rows[i]["CreationDate"]))
                        {
                            currentCustomer.CreationDate = Convert.ToDateTime(customerTable.Rows[i]["CreationDate"]);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                OnError($"CustomerDB.GetCustomer {ex.Message}");
            }

            return currentCustomer;
        }

        public List<CustomerProperty> GetCustomers()
        {
            List<CustomerProperty> listCustomers = new List<CustomerProperty>();

            string sqlQuery = string.Empty;

            DataTable customerTable = new DataTable();

            try
            {
                sqlQuery = "PP2K_TimeTracker_SelectCustomers";

                customerTable = SQLManager.ExecuteSelect(sqlQuery,
                    new string[] { },
                    new object[] { });

                if (customerTable.Rows.Count > 0)
                {
                    for (int i = 0; i < customerTable.Rows.Count; i++)
                    {
                        CustomerProperty currentCustomer = new CustomerProperty();

                        if (!Convert.IsDBNull(customerTable.Rows[i]["ID"]))
                        {
                            currentCustomer.Id = Convert.ToInt64(customerTable.Rows[i]["ID"]);
                        }
                        if (!Convert.IsDBNull(customerTable.Rows[i]["InitiatorUserID"]))
                        {
                            currentCustomer.InitiatorUserId = Convert.ToInt64(customerTable.Rows[i]["InitiatorUserID"]);
                        }
                        if (!Convert.IsDBNull(customerTable.Rows[i]["CustomerName"]))
                        {
                            currentCustomer.CustomerName = Convert.ToString(customerTable.Rows[i]["CustomerName"]);
                        }
                        if (!Convert.IsDBNull(customerTable.Rows[i]["CustomerNumber"]))
                        {
                            currentCustomer.CustomerNumber = Convert.ToString(customerTable.Rows[i]["CustomerNumber"]);
                        }
                        if (!Convert.IsDBNull(customerTable.Rows[i]["ResponsibleSalesRepresentative"]))
                        {
                            currentCustomer.ResponsibleSalesRepresentative = Convert.ToString(customerTable.Rows[i]["ResponsibleSalesRepresentative"]);
                        }
                        if (!Convert.IsDBNull(customerTable.Rows[i]["Active"]))
                        {
                            currentCustomer.Active = Convert.ToBoolean(customerTable.Rows[i]["Active"]);
                        }
                        if (!Convert.IsDBNull(customerTable.Rows[i]["CreationDate"]))
                        {
                            currentCustomer.CreationDate = Convert.ToDateTime(customerTable.Rows[i]["CreationDate"]);
                        }

                        listCustomers.Add(currentCustomer);
                    }
                }
            }
            catch(Exception ex)
            {
                OnError($"CustomerDB.GetCustomers {ex.Message}");
            }

            return listCustomers;
        }

        private void ErrorLogger(string message)
        {
            OnError($"CustomerDB.ErrorLogger {message}");
        }
    }
}
