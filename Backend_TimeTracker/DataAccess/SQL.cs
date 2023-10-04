using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_TimeTracker
{
    public class SQL
    {
        /** Klassenbeschreibung SQL 
          * Hier sind drei SQL Statements definiert, damit ich Sie nicht immer wieder
          * ausschreiben muss habe ich mir hier einmalige Methoden definiert, die Parameter erwarten **/

        private string dbConnection = Properties.Settings.Default.DBConnection;

        public event OnErrorEventHandler OnError;
        public delegate void OnErrorEventHandler(string message);

        /** SQL INSERT Methode , die ich einmal deklariert habe und 
         * nun aufrufen kann und den Commandtext und die Parameter etc. übergeben kann 
         * Als Rückgabe erhalte ich die insertete ID **/
        public long ExecuteInsert(string commandText, string[] parameter, object[] values)
        {
            return executeInsert(commandText, parameter, values);
        }

        /** SQL UPDATE Methode , die ich einmal deklariert habe und 
          * nun aufrufen kann und den Commandtext und die Parameter etc. übergeben kann  **/
        public bool ExecuteUpdate(string commandText, string[] parameter, object[] values)
        {
            return executeUpdate(commandText, parameter, values);
        }

        /** SQL Select Methode , die ich einmal deklariert habe und 
        * nun aufrufen kann und den Commandtext und die Parameter etc. übergeben kann 
        * Als Rückgabe erhalte ich die ganze Tabelle **/
        public DataTable ExecuteSelect(string commandText, string[] parameter, object[] values)
        {
            return executeSelect(commandText, parameter, values);
        }

        public bool ProveSQLConnection()
        {
            return proveSQLConnection();
        }

        private bool proveSQLConnection()
        {
            SqlConnection connection = new SqlConnection();
            bool result = false;
            try
            {
                connection.ConnectionString = dbConnection;
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                command.Connection.Open();
                result = true;
            }
            catch (Exception ex)
            {
                OnError("[PROVE-SQL-CONNECTION-FEHLER] " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        private DataTable executeSelect(string commandText, string[] parameter, object[] values)
        {
            SqlConnection connection = new SqlConnection();
            SqlDataReader reader = null;

            DataTable table = new DataTable();

            try
            {
                connection.ConnectionString = dbConnection;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = commandText;

                for (int i = 0; i < parameter.Length; i++)
                {
                    if (values[i] != null)
                    {
                        command.Parameters.AddWithValue(parameter[i], values[i]);
                    }
                    else
                    {
                        command.Parameters.AddWithValue(parameter[i], DBNull.Value);
                    }
                }

                command.Connection.Open();

                reader = command.ExecuteReader();
                table.Load(reader);
            }
            catch(Exception ex)
            {
                OnError("[EXECUTE-SELECT-FEHLER] " + ex.Message);
            }
            finally
            {
                reader.Close();
                connection.Close();
            }

            return table;
        }

        private bool executeUpdate(string commandText, string[] parameter, object[] values)
        {
            SqlConnection connection = new SqlConnection();

            bool result = false;

            try
            {
                connection.ConnectionString = dbConnection;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = commandText;

                for (int i = 0; i < parameter.Length; i++)
                {
                    if (values[i] != null)
                    {
                        command.Parameters.AddWithValue(parameter[i], values[i]);
                    }
                    else
                    {
                        command.Parameters.AddWithValue(parameter[i], DBNull.Value);
                    }
                }

                command.Connection.Open();

                long? checkId = (long?)command.ExecuteNonQuery();

                if (checkId.HasValue)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                OnError("EXECUTE-UPDATE-FEHLER " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        private long executeInsert(string commandText, string[] parameter, object[] values)
        {
            SqlConnection connection = new SqlConnection();
            long id = 0;

            try
            {
                connection.ConnectionString = dbConnection;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = commandText;

                for (int i = 0; i < parameter.Length; i++)
                {
                    if (values[i] != null)
                    {
                        command.Parameters.AddWithValue(parameter[i], values[i]);
                    }
                    else
                    {
                        command.Parameters.AddWithValue(parameter[i], DBNull.Value);
                    }
                }

                command.Connection.Open();

                id = (long)command.ExecuteScalar();
            }
            catch(Exception ex)
            {
                OnError("[EXECUTE-INSERT-FEHLER] " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return id;
        }
    }
}
