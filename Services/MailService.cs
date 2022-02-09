using MailKit.Security;
using Microsoft.Data.SqlClient;
using MimeKit;
using System;
using System.Data;
using VisitorManagementSystemWebApi.App_Code;
using VisitorManagementSystemWebApi.App_Code.DAL;
using VisitorManagementSystemWebApi.Model;

namespace VisitorManagementSystemWebApi.Services
{
    public class MailService : IMailService
    {
        //private readonly MailSettings _mailSettings;
        //public MailService(IOptions<MailSettings> mailSettings)
        //{
        //    _mailSettings = mailSettings.Value;
        //}
        public void SendEmail(Int64 VISIID)
        {
            DataSet dsEmail = new DataSet();
            dsEmail = EmailDAL.GetEMailDetails(VISIID);
            string VisiEmail = dsEmail.Tables[0].Rows[0][2].ToString();
            string Subject = dsEmail.Tables[0].Rows[0][2].ToString();
            string Message = dsEmail.Tables[0].Rows[0][2].ToString();
            string Sender = dsEmail.Tables[0].Rows[0][2].ToString();
            string Host = dsEmail.Tables[0].Rows[0][2].ToString();
            int Port = Convert.ToInt32(dsEmail.Tables[0].Rows[0][2]);
            string Password = dsEmail.Tables[0].Rows[0][2].ToString();
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(Sender);
            email.To.Add(MailboxAddress.Parse(VisiEmail));
            email.Subject = Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = Message;

            //  builder.HtmlBody = "Dear " + mailRequest.VisiName + ",<BR/><BR/>" +
            //"Here We Confirm your registration for RSVP Verification "  + "<BR/> " +
            //"for Conforming your presence in 134 th NDA Passing Out Parade, Pune." + "<BR/> " +
            //"Please visit NDA Gate within Next 96 hrs.<BR/>" +
            // "Please click below link to RSVP Invitation Card.<BR/>" +
            // "https://designaxis.co.in/#/rsvp-pass/" + mailRequest.VisiID + "<BR/>" +
            //  " Please get hard copy of this on your visit." + "<BR/> <BR/>" +
            //  "Thanks, NDA, Pune";

            //builder.HtmlBody = "Dear " + mailRequest.VisiName + ",<BR/><BR/>" +
            //     "Here we confirm your registration for" + mailData.Rows[0]["Ceremony_Name"] + ", Pune." + "<BR/>" +
            //"To confirm your visit please get hard copy of this pass and visit NDA Gate within" + "<BR/>" +
            //"Next 96 hrs of registrartion date.There you have to scan QR code which is printed on Pass," + "<BR/>" +
            //" this will confirm your visit for this ceremony." + "<BR/><BR/>" +
            //"Please click below link to vies Acknowledgement Invitation Card." + "<BR/>" +
            //"Link:https://designaxis.co.in/#/rsvp-pass/" + mailRequest.VisiID + "<BR/><BR/>" +

            //"<B>Please get below documents while coming <B/>:" + "<BR/>" +
            //    "1.Original Adhar cards of all visitors." + "<BR/>" +
            //    "2.Covid 19 Vaccinaation Report of all visitors." + "<BR/>" +
            //    "3.Police Verification of within one month for all visitors." + "<BR/><BR/>" +

            //    "Thanks," + "<BR/>" +
            //    "NDA, Pune";



            email.Body = builder.ToMessageBody();
            var smtp = new MailKit.Net.Smtp.SmtpClient();
            //smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.Auto);
            //smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            smtp.Connect(Host, Port, SecureSocketOptions.Auto);
            smtp.Authenticate(Sender, Password);
            smtp.Send(email);
            smtp.Disconnect(true);
        }

       

    }
}
