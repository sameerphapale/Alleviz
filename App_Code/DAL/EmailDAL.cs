using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VisitorManagementSystemWebApi.Model;

namespace VisitorManagementSystemWebApi.App_Code.DAL
{
    public class EmailDAL
    {

        public Int32 UpdateEmail(EmailModel objemail)
        {
            try
            {
                //string query = "EXEC USP_VisiMasterSMSNotifation1 " + objAppoint.AppID + ",'" + objAppoint.EmployeeList + "' ";
                SqlCommand cmd = new SqlCommand("SP_BranchMaster");
                //cmd.Parameters.AddWithValue("@command", objemail.Email.ToString());
                //cmd.Parameters.AddWithValue("@Address", objemail.Name.ToString());
                //cmd.Parameters.AddWithValue("@command", objemail.Password.ToString());
                //cmd.Parameters.AddWithValue("@BranchName", objemail.Host.ToString());
                cmd.Parameters.AddWithValue("@Address", objemail.Port.ToString());
                return SqlHelper.ExtecuteProcedureReturnInteger(cmd);
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {

            }
        }

        public static DataSet GetEMailDetails(Int64 VISIID)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GATEMAILDETAILS");
                cmd.Parameters.AddWithValue("@COMMAND", VISIID);
                cmd.Parameters.AddWithValue("@VISIID", VISIID);
                ds = SqlHelper.ExtecuteProcedureReturnDataSet(cmd);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
            return ds;

        }
    }
}
