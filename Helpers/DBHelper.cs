using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace DeploymentTool
{
    public static class DBHelper
    {
#if DEBUG
        private static string defaultConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
#else
        private static string defaultConnectionString = "";
#endif
        public static string DefaultConnectionString
        {
            get
            {
                return defaultConnectionString;
            }
        }

        public static DataTable ExecuteProcedure(string PROC_NAME, params object[] parameters)
        {
            try
            {
                if (parameters.Length % 2 != 0)
                    throw new ArgumentException("Wrong number of parameters sent to procedure. Expected an even number.");
                DataTable a = new DataTable();
                List<SqlParameter> filters = new List<SqlParameter>();

                string query = "EXEC " + PROC_NAME;

                bool first = true;
                for (int i = 0; i < parameters.Length; i += 2)
                {
                    filters.Add(new SqlParameter(parameters[i] as string, parameters[i + 1]));
                    query += (first ? " " : ", ") + ((string)parameters[i]);
                    first = false;
                }

                a = Query(query, filters);
                return a;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ExecuteQuery(string query, params object[] parameters)
        {
            try
            {
                if (parameters.Length % 2 != 0)
                    throw new ArgumentException("Wrong number of parameters sent to procedure. Expected an even number.");
                DataTable a = new DataTable();
                List<SqlParameter> filters = new List<SqlParameter>();

                for (int i = 0; i < parameters.Length; i += 2)
                    filters.Add(new SqlParameter(parameters[i] as string, parameters[i + 1]));

                a = Query(query, filters);
                return a;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ExecuteNonQuery(string query, params object[] parameters)
        {
            try
            {
                if (parameters.Length % 2 != 0)
                    throw new ArgumentException("Wrong number of parameters sent to procedure. Expected an even number.");
                List<SqlParameter> filters = new List<SqlParameter>();

                for (int i = 0; i < parameters.Length; i += 2)
                    filters.Add(new SqlParameter(parameters[i] as string, parameters[i + 1]));
                return NonQuery(query, filters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static object ExecuteScalar(string query, params object[] parameters)
        {
            try
            {
                if (parameters.Length % 2 != 0)
                    throw new ArgumentException("Wrong number of parameters sent to query. Expected an even number.");
                List<SqlParameter> filters = new List<SqlParameter>();

                for (int i = 0; i < parameters.Length; i += 2)
                    filters.Add(new SqlParameter(parameters[i] as string, parameters[i + 1]));
                return Scalar(query, filters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Private Methods

        private static DataTable Query(String consulta, IList<SqlParameter> parametros)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(defaultConnectionString);
                SqlCommand command = new SqlCommand();
                SqlDataAdapter da;
                try
                {
                    command.Connection = connection;
                    command.CommandText = consulta;
                    if (parametros != null)
                    {
                        command.Parameters.AddRange(parametros.ToArray());
                    }
                    da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private static int NonQuery(string query, IList<SqlParameter> parametros)
        {
            try
            {
                DataSet dt = new DataSet();
                SqlConnection connection = new SqlConnection(defaultConnectionString);
                SqlCommand command = new SqlCommand();

                try
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = query;
                    command.Parameters.AddRange(parametros.ToArray());
                    return command.ExecuteNonQuery();

                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static object Scalar(string query, List<SqlParameter> parametros)
        {
            try
            {
                DataSet dt = new DataSet();
                SqlConnection connection = new SqlConnection(defaultConnectionString);
                SqlCommand command = new SqlCommand();

                try
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = query;
                    command.Parameters.AddRange(parametros.ToArray());
                    return command.ExecuteScalar();

                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void login(string userName, string password, out string tName, out string tEmail , out int nRoleType, out int nUserID)
        {
            using (SqlConnection con = new SqlConnection(defaultConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sproc_UserLogin", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("tUserName", userName);
                cmd.Parameters.AddWithValue("tPassword ", password);              

                SqlParameter outputPara = new SqlParameter();
                outputPara.ParameterName = "@tName";
                outputPara.Direction = System.Data.ParameterDirection.Output;
                outputPara.SqlDbType = System.Data.SqlDbType.NVarChar;
                outputPara.Size = 255;
                SqlParameter outputPara1 = new SqlParameter();
                outputPara1.ParameterName = "@tEmail";
                outputPara1.Direction = System.Data.ParameterDirection.Output;
                outputPara1.SqlDbType = System.Data.SqlDbType.NVarChar;
                outputPara1.Size = 255;
                SqlParameter outputPara2 = new SqlParameter();
                outputPara2.ParameterName = "@nRoleType ";
                outputPara2.Direction = System.Data.ParameterDirection.Output;
                outputPara2.SqlDbType = System.Data.SqlDbType.Int;
                SqlParameter outputPara3 = new SqlParameter();
                outputPara3.ParameterName = "@nUserID  ";
                outputPara3.Direction = System.Data.ParameterDirection.Output;
                outputPara3.SqlDbType = System.Data.SqlDbType.Int;
                cmd.Parameters.Add(outputPara);
                cmd.Parameters.Add(outputPara1);
                cmd.Parameters.Add(outputPara2);
                cmd.Parameters.Add(outputPara3);
                con.Open();
                cmd.ExecuteNonQuery();

                tName = outputPara.Value.ToString();  
                tEmail = outputPara1.Value.ToString();
                nRoleType = Convert.ToInt32(outputPara2.Value.ToString());
                nUserID = Convert.ToInt32(outputPara3.Value.ToString());
            }

}

        #endregion
    }

}