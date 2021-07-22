using System;
using System.Data;
using System.Data.SqlClient;

namespace EAAutoFramework.Helpers
{
    public static class DataHelperExtensions
    {
        //Open the connection
        public static SqlConnection DBConnect(this SqlConnection sqlConnection, string connectionString)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception e)
            {
                LogHelpers.Write("ERROR :: " + e.Message);
            }

            return null; 
        }

        //Close the connection
        public static void DBClose(this SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                LogHelpers.Write("ERROR :: " + e.Message);               
            }
        }

        //Execute query
        public static DataTable ExecuteQuery(this SqlConnection sqlConnection, string queryString)
        {
            DataSet dataSet;
            try
            {
                //Check the state of the connection
                if (sqlConnection == null || ((sqlConnection != null && (sqlConnection.State == ConnectionState.Closed 
                    || sqlConnection.State == ConnectionState.Broken))))
                {
                    sqlConnection.Open();
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand(queryString, sqlConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;

                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "table");
                sqlConnection.Close();
                return dataSet.Tables["table"];
            }
            catch (Exception e)
            {
                dataSet = null;
                sqlConnection.Close();
                LogHelpers.Write("ERROR :: " + e.Message);
                return null;
            }
            finally
            {                
                sqlConnection.Close();
                dataSet = null;
            }
        }
    }
}
