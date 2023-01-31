﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using Newtonsoft.Json;
using DeploymentTool.Model;

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









        #region Private Methods







        public static void login(ref User objUser)
        {
            using (SqlConnection con = new SqlConnection(defaultConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sproc_UserLogin", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("tUserName", objUser.userName);
                cmd.Parameters.AddWithValue("tPassword ", objUser.password);

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

                objUser.tName = outputPara.Value.ToString();
                objUser.tEmail = outputPara1.Value.ToString();
                objUser.nRoleType = Convert.ToInt32(outputPara2.Value.ToString());
                objUser.nUserID = Convert.ToInt32(outputPara3.Value.ToString());
            }

        }
        static dynamic ConvertDataTableToDynamicObject(DataTable dataTable)
        {
            var dynamicList = dataTable.AsEnumerable().Select(row =>
            {
                var dynamicObject = new System.Dynamic.ExpandoObject();
                var dictionary = (IDictionary<string, object>)dynamicObject;

                foreach (DataColumn column in dataTable.Columns)
                {
                    dictionary[column.ColumnName] = row[column];
                }

                return dynamicObject;
            });

            return dynamicList;
        }

        public static Dictionary<string, object> CallProcedureAndConvertToJson(string procedureName)
        {
            using (var connection = new SqlConnection(DefaultConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        var dataTable = new DataTable();
                        dataTable.Load(reader);
                        Dictionary<string, object> dict = dataTable.AsEnumerable().ToDictionary(row => row.Field<string>(0), row => row.Field<object>(1));
                        return dict;
                    }
                }
            }
        }

        #endregion
    }

}