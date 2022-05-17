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
        public Int32 InsertHostEmailData(EmailRequest objemail)
        {
            try
            {
                //string query = "EXEC USP_VisiHostEmailNotification " + objemail.AppID +","+ objemail.VisiCatID;
                SqlCommand cmd = new SqlCommand("USP_VisiHostEmailNotification");
                cmd.Parameters.AddWithValue("@AppID", objemail.AppID);
                cmd.Parameters.AddWithValue("@ApprovalId", objemail.EmployeeList);
                cmd.Parameters.AddWithValue("@TotalLevels", objemail.TotalLevels);
                cmd.Parameters.AddWithValue("@Level", objemail.Level);
                cmd.Parameters.AddWithValue("@Command", objemail.Command);
                cmd.Parameters.AddWithValue("@Remark", objemail.Remark);
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
        public Int32 InsertApprovalEmailDataAllLevel(EmailRequest objemail)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("USP_VisitorApprovalEmailNotificationAllLevel");
                cmd.Parameters.AddWithValue("@AppID", objemail.AppID);
                cmd.Parameters.AddWithValue("@VisiCatID", objemail.VisiCatID);
                cmd.Parameters.AddWithValue("@ApprovalId", objemail.EmployeeList);
                cmd.Parameters.AddWithValue("@TotalLevels", objemail.TotalLevels);
                cmd.Parameters.AddWithValue("@Level", objemail.Level);
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
        public Int32 InsertApprovalEmailDataFirstLevel(EmailRequest objemail)
        {
            try
            {
                //string query = "EXEC USP_VisitorApprovalEmailNotificationFirstLevel " + objemail.AppID +","+ objemail.VisiCatID;
                SqlCommand cmd = new SqlCommand("USP_VisitorApprovalEmailNotificationFirstLevel");
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
        public Int32 InsertVisitorSMSEmailConfirm(EmailRequest objemail)
        {
            try
            {
                //string query = "EXEC USP_VisiMasterSMSEmailNotificationConfirm " + objemail.AppID;
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

        #region SMS
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
                //string query = "EXEC USP_InternalMeetingEmailNotification" + objemail.EmployeeList;
                SqlCommand cmd = new SqlCommand("USP_InternalMeetingEmailNotification");
                cmd.Parameters.AddWithValue("@ListEmpID", objemail.EmployeeList);
                cmd.Parameters.AddWithValue("@MeetingID", objemail.MeetingId);
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
        public Int32 InsertMeetingQRCodeEmailData(EmailRequest objemail)
        {
            try
            {
                //string query = "EXEC USP_InternalMeetingEmailNotification" + objemail.EmployeeList;
                SqlCommand cmd = new SqlCommand("SP_InternalMeetingEmailQRCodeNotification");
                cmd.Parameters.AddWithValue("@ListEmpID", objemail.EmployeeList);
                cmd.Parameters.AddWithValue("@MeetingID", objemail.MeetingId);
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
        public Int32 InsertEmployeeEmailData(EmailRequest objemail)
        {
            try
            {
                string query = "EXEC USP_EmployeeEmailNotification" + objemail.EmployeeList;
                SqlCommand cmd = new SqlCommand("USP_EmployeeEmailNotification");
                cmd.Parameters.AddWithValue("@EmpID", objemail.EmployeeList);
                cmd.Parameters.AddWithValue("@Command", objemail.Command);
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
        public Int32 InsertSMSAlertEmailData(EmailRequest objemail)
        {
            try
            {
                //string query = "EXEC USP_EmployeeEmailNotification" + objemail.EmployeeList;
                SqlCommand cmd = new SqlCommand("SP_SMSAlertEmailNotification");
                //cmd.Parameters.AddWithValue("@EmpID", objemail.EmployeeList);
                cmd.Parameters.AddWithValue("@Command", objemail.Command);
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

        public Int32 InsertUnscheduleHostEmailData(EmailRequest objemail)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UnscheduleHostEmailNotification");
                cmd.Parameters.AddWithValue("@EmpID", objemail.HostID);
                cmd.Parameters.AddWithValue("@AppID", objemail.AppID);
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

        public static DataSet GetQRMailDetails(Int64 MeeetinID)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_EmailMaster");
                cmd.Parameters.AddWithValue("@Command", "SELECTQR");
                cmd.Parameters.AddWithValue("@MeetingID", MeeetinID);
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
