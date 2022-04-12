using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using VisitorManagementSystemWebApi.App_Code;

namespace VisitorManagementSystemWebApi.App_Code
{
    public class SqlHelper
    {
        public IConfiguration Configuration { get; }
        public static string ConnectionString { get; set; }
        Startup startup;
        public SqlHelper(IConfiguration Configuration)
        {
            startup = new Startup(Configuration);
            ConnectionString = startup.GetString();
        }
        public static string ExecuteProcedureReturnString(SqlCommand cmd)
        {
            string result = "";
            try
            {
                using (var sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (cmd.Connection = sqlConnection)
                    {

                        cmd.Connection.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        result = cmd.ExecuteScalar().ToString();

                        sqlConnection.Close();

                        return result;
                    }
                }
            }
            catch (Exception ex) { return ""; }

        }

        public static DataSet ExtecuteProcedureReturnDataSet(SqlCommand cmd)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (cmd.Connection = sqlConnection)
                    {
                        cmd.Connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(ds);
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return ds != null ? ds : null;
        }
        public static DataTable ExtecuteProcedureReturnDataTable(SqlCommand cmd)
        {

            DataTable dt = new DataTable();
            try
            {
                using (var sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (cmd.Connection = sqlConnection)
                    {

                        cmd.Connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(dt);
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt != null ? dt : null;
        }

        public static Int32 ExtecuteProcedureReturnInteger(SqlCommand cmd)
        {
            try
            {
                Int32 Result = 0;
                using (var sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (cmd.Connection = sqlConnection)
                    {
                        cmd.Connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                        cmd.Connection.Close();
                    }
                }
                return Result;
            }
            catch (Exception ex) { return -5; }

        }
        public static string ExtecuteProcedureReturnString(SqlCommand cmd)
        {
            try
            {
                string Result = "";
                using (var sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (cmd.Connection = sqlConnection)
                    {
                        cmd.Connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = cmd.ExecuteScalar().ToString();
                        cmd.Connection.Close();
                    }
                }

                return Result;
            }
            catch (Exception ex) { return ex.Message.ToString(); }

        }

        public static Int32 ExtecuteInlineQueryToReturnInteger(SqlCommand cmd)
        {
            try
            {
                Int32 Result = 0;
                using (var sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (cmd.Connection = sqlConnection)
                    {
                        cmd.Connection.Open();
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                        cmd.Connection.Close();
                    }
                }

                return Result;
            }
            catch (Exception ex) { return -1; }

        }

        public static Int64 ExtecuteInlineQueryToReturnIntegers(SqlCommand cmd)
        {
            try
            {
                Int64 Result = 0;
                using (var sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (cmd.Connection = sqlConnection)
                    {
                        cmd.Connection.Open();
                        Result = Convert.ToInt64(cmd.ExecuteScalar());
                        cmd.Connection.Close();
                    }
                }

                return Result;
            }
            catch (Exception ex) { return -1; }

        }

    }
}
