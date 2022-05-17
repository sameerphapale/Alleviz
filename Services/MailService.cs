using Grpc.Core;
using GSF.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using QRCoder;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
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
                        MailMessage message = new MailMessage();
                        message.To.Add(VisiEmail);// Email-ID of Receiver  
                        message.Subject = Subject;// Subject of Email  
                        message.From = new MailAddress(Sender, Name);// Email-ID of Sender  
                        message.Body = Message;
                        message.IsBodyHtml = true;
                        AlternateView altViewLogo = AlternateView.CreateAlternateViewFromString(Message, null, MediaTypeNames.Text.Html);
                        LinkedResource LogoPictureRes = new LinkedResource(@"Images/Logo.png", MediaTypeNames.Image.Jpeg);
                        LogoPictureRes.ContentId = "LogoPictureId";
                        altViewLogo.LinkedResources.Add(LogoPictureRes);
                        message.AlternateViews.Add(altViewLogo);

                        AlternateView footerview = AlternateView.CreateAlternateViewFromString(Message, null, MediaTypeNames.Text.Html);
                        LinkedResource footerviewPicture = new LinkedResource(@"Images/footer.png", MediaTypeNames.Image.Jpeg);
                        footerviewPicture.ContentId = "footerPictureId";
                        footerview.LinkedResources.Add(footerviewPicture);
                        message.AlternateViews.Add(footerview);
                        //message.Attachments.Add(new Attachment(@"Images/qrcode.png"));
                        var smtp = new MailKit.Net.Smtp.SmtpClient();
                        smtp.Connect(Host, Port, SecureSocketOptions.Auto);
                        smtp.Authenticate(Sender, Password);
                        smtp.Send((MimeMessage)message);
                    }
                    //foreach (DataRow row in dsEmail.Tables[0].Rows)
                    //{
                    //    string VisiEmail = row["ETO"].ToString();
                    //    string Subject = row["ESUBJECT"].ToString();
                    //    string Message = row["EMESSAGE"].ToString();

                    //    var email = new MimeMessage();
                    //    email.Sender = MailboxAddress.Parse(Sender);
                    //    email.From.Add(new MailboxAddress(Name, Sender));
                    //    email.To.Add(MailboxAddress.Parse(VisiEmail));
                    //    email.Subject = Subject;
                    //    var builder = new BodyBuilder();
                    //    builder.HtmlBody = Message;
                    //    email.Body = builder.ToMessageBody();
                    //    var smtp = new MailKit.Net.Smtp.SmtpClient();
                    //    smtp.Connect(Host, Port, SecureSocketOptions.Auto);
                    //    smtp.Authenticate(Sender, Password);
                    //    smtp.Send(email);
                    //    smtp.Disconnect(true);
                    //}
                    Int32 SID = EmailDAL.UpdateEmail(EID);
                    //return SID;
                }
                return Result;
            }
            catch (Exception ex)
            {
                return Result;
            }

        }

        public string SendEmailReturnString(Int64 EID)
        {
            string Result = "OK";
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
                        MailMessage message = new MailMessage();
                        message.To.Add(VisiEmail);// Email-ID of Receiver  
                        message.Subject = Subject;// Subject of Email  
                        message.From = new MailAddress(Sender, Name);// Email-ID of Sender  
                        message.Body = Message;
                        message.IsBodyHtml = true;
                        AlternateView altViewLogo = AlternateView.CreateAlternateViewFromString(Message, null, MediaTypeNames.Text.Html);
                        LinkedResource LogoPictureRes = new LinkedResource(@"Images/Logo.png", MediaTypeNames.Image.Jpeg);
                        LogoPictureRes.ContentId = "LogoPictureId";
                        altViewLogo.LinkedResources.Add(LogoPictureRes);
                        message.AlternateViews.Add(altViewLogo);

                        AlternateView footerview = AlternateView.CreateAlternateViewFromString(Message, null, MediaTypeNames.Text.Html);
                        LinkedResource footerviewPicture = new LinkedResource(@"Images/footer.png", MediaTypeNames.Image.Jpeg);
                        footerviewPicture.ContentId = "footerPictureId";
                        footerview.LinkedResources.Add(footerviewPicture);
                        message.AlternateViews.Add(footerview);
                        //message.Attachments.Add(new Attachment(@"Images/qrcode.png"));
                        var smtp = new MailKit.Net.Smtp.SmtpClient();
                        smtp.Connect(Host, Port, SecureSocketOptions.Auto);
                        smtp.Authenticate(Sender, Password);
                        smtp.Send((MimeMessage)message);
                    }
                    EmailDAL.UpdateEmail(EID);
                }
                return Result;
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
                return Result;
            }

        }

        public Int32 SendQRCodeEmail(Int64 EID, Int64 MeetID)
        {
            Int32 Result = 0;
            try
            {
                DataSet dsEmail = new DataSet();
                DataSet dsqrcodeno = new DataSet();
                //dsEmail = EmailDAL.GetSMSEMailDetails();
                dsEmail = EmailDAL.GetQRMailDetails(MeetID);
                if (dsEmail.Tables[0].Rows.Count > 0)
                {
                    string Sender = dsEmail.Tables[1].Rows[0]["Email"].ToString();
                    string Host = dsEmail.Tables[1].Rows[0]["Host"].ToString();
                    string Name = dsEmail.Tables[1].Rows[0]["Name"].ToString();
                    int Port = Convert.ToInt32(dsEmail.Tables[1].Rows[0]["Port"]);
                    string Password = dsEmail.Tables[1].Rows[0]["Password"].ToString();
                    string qrnumber = dsEmail.Tables[2].Rows[0]["ORCodeNo"].ToString();
                    GenerateQrCode(qrnumber);

                    foreach (DataRow row in dsEmail.Tables[0].Rows)
                    {
                        string VisiEmail = row["ETO"].ToString();
                        string Subject = row["ESUBJECT"].ToString();
                        string Message = row["EMESSAGE"].ToString();
                        MailMessage message = new MailMessage();
                        message.To.Add(VisiEmail);// Email-ID of Receiver  
                        message.Subject = Subject;// Subject of Email  
                        message.From = new MailAddress(Sender, Name);// Email-ID of Sender  
                        message.Body = Message;
                        message.IsBodyHtml = true;
                        AlternateView altViewLogo = AlternateView.CreateAlternateViewFromString(Message, null, MediaTypeNames.Text.Html);
                        LinkedResource LogoPictureRes = new LinkedResource(@"Images/Logo.png", MediaTypeNames.Image.Jpeg);
                        LogoPictureRes.ContentId = "LogoPictureId";
                        altViewLogo.LinkedResources.Add(LogoPictureRes);
                        message.AlternateViews.Add(altViewLogo);

                        AlternateView altViewqrcode = AlternateView.CreateAlternateViewFromString(Message, null, MediaTypeNames.Text.Html);
                        LinkedResource qrcodePictureRes = new LinkedResource(@"Images/qrcode.png", MediaTypeNames.Image.Jpeg);
                        qrcodePictureRes.ContentId = "qrcodePictureId";
                        altViewqrcode.LinkedResources.Add(qrcodePictureRes);
                        message.AlternateViews.Add(altViewqrcode);

                        AlternateView footerview = AlternateView.CreateAlternateViewFromString(Message, null, MediaTypeNames.Text.Html);
                        LinkedResource footerviewPicture = new LinkedResource(@"Images/footer.png", MediaTypeNames.Image.Jpeg);
                        footerviewPicture.ContentId = "footerPictureId";
                        footerview.LinkedResources.Add(footerviewPicture);
                        message.AlternateViews.Add(footerview);
                        //message.Attachments.Add(new Attachment(@"Images/qrcode.png"));
                        var smtp = new MailKit.Net.Smtp.SmtpClient();
                        smtp.Connect(Host, Port, SecureSocketOptions.Auto);
                        smtp.Authenticate(Sender, Password);
                        smtp.Send((MimeMessage)message);
                    }
                    EmailDAL.UpdateEmail(EID);
                }
                return Result;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Result;
            }

        }
        private byte[] GenerateQrCode(string qrmsg)
        {
            string code = qrmsg;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    return byteImage;
                }
            }
        }

    }
}
