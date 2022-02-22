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
        //private readonly EmailSetting _mailSettings;
        //public EmailSetting(IOptions<EmailSetting> mailSettings)
        //{
        //    _mailSettings = mailSettings.Value;
        //}
        public Int32 InsertEmailData(EmailRequest objemail)
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
        public static DataSet GetEMailDetails()
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


        //public Int32 SendEmail(EmailRequest request)
        //{
        //    Int32 Result = 0;
        //    DataSet dsEmail = new DataSet();
        //    dsEmail = EmailDAL.GetEMailDetails(request);
        //    if (dsEmail.Tables[0].Rows.Count > 0)
        //    {

        //        if (dsEmail.Tables[0].Rows.Count > 1)
        //        {
        //            foreach (DataRow row in dsEmail.Tables[0].Rows)
        //            {
        //                string VisiEmail = row["ETO"].ToString();
        //                string Subject = row["ESUBJECT"].ToString(); ;
        //                string Message = row["EMESSAGE"].ToString(); ;
        //                string Sender = _mailSettings.Email;
        //                string Host = _mailSettings.Host;
        //                int Port = _mailSettings.Port;
        //                string Password = _mailSettings.Password;
        //                var email = new MimeMessage();
        //                email.Sender = MailboxAddress.Parse(Sender);
        //                email.To.Add(MailboxAddress.Parse(VisiEmail));
        //                email.Subject = Subject;
        //                var builder = new BodyBuilder();
        //                builder.HtmlBody = Message;
        //                email.Body = builder.ToMessageBody();
        //                var smtp = new MailKit.Net.Smtp.SmtpClient();
        //                smtp.Connect(Host, Port, SecureSocketOptions.Auto);
        //                smtp.Authenticate(Sender, Password);
        //                smtp.Send(email);
        //                smtp.Disconnect(true);

        //                request.EID = Convert.ToInt64(row["EID"]);
        //                EmailDAL.UpdateEmail(request);
        //            }

        //        }

        //    }
        //    return Result;
        //}
    }
}
