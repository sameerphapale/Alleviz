using MailKit.Security;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using VisitorManagementSystemWebApi.Model;
using static VisitorManagementSystemWebApi.Model.EmailModel;

namespace VisitorManagementSystemWebApi.App_Code.DAL
{
    public class EmailDAL
    {
        public Int32 InsertApprovalEmailData(EmailRequest objemail)
        {
            try
            {
                //string query = "EXEC USP_VisitorSMSEmailNotification " + objemail.AppID +","+ objemail.VisiCatID;
                SqlCommand cmd = new SqlCommand("USP_VisitorSMSEmailNotification");
                cmd.Parameters.AddWithValue("@AppID", objemail.AppID);
                cmd.Parameters.AddWithValue("@VisiCatID", objemail.VisiCatID);
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
        public static Int32 UpdateEmail(Int64 EID)
        {
            try
            {
                //string query = "EXEC USP_VisiMasterSMSNotifation1 " + objAppoint.AppID + ",'" + objAppoint.EmployeeList + "' ";
                SqlCommand cmd = new SqlCommand("SP_EmailMaster");
                cmd.Parameters.AddWithValue("@Command", "UPDATE");
                cmd.Parameters.AddWithValue("@EID", EID);
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
        public static DataSet GetSMSEMailDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_EmailMaster");
                cmd.Parameters.AddWithValue("@Command", "SELECT");
                cmd.Parameters.AddWithValue("@EID", null);
                ds = SqlHelper.ExtecuteProcedureReturnDataSet(cmd);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
            return ds;

        }

        public static DataSet GetMeetingEMailDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_EmailMaster");
                cmd.Parameters.AddWithValue("@Command", "SELECTMEET");
                cmd.Parameters.AddWithValue("@EID", null);
                ds = SqlHelper.ExtecuteProcedureReturnDataSet(cmd);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
            return ds;

        }


        #region SMS
        public Int32 InsertVisitorSMSEmailConfirmData(EmailRequest objemail)
        {
            try
            {
                string query = "EXEC USP_VisiMasterSMSEmailNotificationConfirm " + objemail.AppID;
                SqlCommand cmd = new SqlCommand("USP_VisiMasterSMSEmailNotificationConfirm");
                cmd.Parameters.AddWithValue("@AppID", objemail.AppID);
                cmd.Parameters.AddWithValue("@AppTypeID", objemail.AppTypeID);
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

        public static Int32 UpdateSMS(Int64 SID)
        {
            try
            {
                //string query = "EXEC USP_VisiMasterSMSNotifation1 " + objAppoint.AppID + ",'" + objAppoint.EmployeeList + "' ";
                SqlCommand cmd = new SqlCommand("SP_SMSMaster");
                cmd.Parameters.AddWithValue("@Command", "UPDATE");
                cmd.Parameters.AddWithValue("@SID", SID);
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

        #endregion
        public static DataTable GetVisitorConfirmEMailDetails()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_EmailMaster");
                cmd.Parameters.AddWithValue("@Command", "SELECT");
                cmd.Parameters.AddWithValue("@EID", null);
                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
            return dt;

        }

        public Int32 InsertMeetingEmailData(EmailRequest objemail)
        {
            try
            {
                string query = "EXEC USP_InternalMeetingEmailNotification" + objemail.EmployeeList;
                SqlCommand cmd = new SqlCommand("USP_InternalMeetingEmailNotification");
                cmd.Parameters.AddWithValue("@ListEmpID", objemail.EmployeeList);
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
    }
}
