using MailKit.Security;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Data;
using VisitorManagementSystemWebApi.App_Code;
using VisitorManagementSystemWebApi.App_Code.DAL;
using VisitorManagementSystemWebApi.Model;
using static VisitorManagementSystemWebApi.Model.EmailModel;

namespace VisitorManagementSystemWebApi.Services
{

    public class MailService : IMailService
    {
        public Int32 SendEmail(Int64 EID)
        {
            Int32 Result = 1;
            try
            {
                DataSet dsEmail = new DataSet();
                dsEmail = EmailDAL.GetSMSEMailDetails();
                if (dsEmail.Tables[0].Rows.Count > 0)
                {
                    string Sender = dsEmail.Tables[1].Rows[0]["Email"].ToString();
                    string Host = dsEmail.Tables[1].Rows[0]["Host"].ToString();
                    string Name = dsEmail.Tables[1].Rows[0]["Name"].ToString();
                    int Port = Convert.ToInt32(dsEmail.Tables[1].Rows[0]["Port"]);
                    string Password = dsEmail.Tables[1].Rows[0]["Password"].ToString();
                    foreach (DataRow row in dsEmail.Tables[0].Rows)
                    {
                        string VisiEmail = row["ETO"].ToString();
                        string Subject = row["ESUBJECT"].ToString();
                        string Message = row["EMESSAGE"].ToString();

                        var email = new MimeMessage();
                        email.Sender = MailboxAddress.Parse(Sender);
                        email.From.Add(new MailboxAddress(Name, Sender));
                        email.To.Add(MailboxAddress.Parse(VisiEmail));
                        email.Subject = Subject;
                        var builder = new BodyBuilder();
                        builder.HtmlBody = Message;
                        email.Body = builder.ToMessageBody();
                        var smtp = new MailKit.Net.Smtp.SmtpClient();
                        smtp.Connect(Host, Port, SecureSocketOptions.Auto);
                        smtp.Authenticate(Sender, Password);
                        smtp.Send(email);
                        smtp.Disconnect(true);
                        //request.EID = Convert.ToInt64(row["EID"]);
                       
                    }
                    Int32 SID = EmailDAL.UpdateEmail(EID);
                    return SID;

                }
                return Result;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return Result;
        }
    }
}
