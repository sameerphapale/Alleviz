using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VisitorManagementSystemWebApi.App_Code
{
    public class CommonFunctionLogic
    {
        public static Int32 SendSMS(string MobileNumber, string SMS)
        {
            try
            {
                if (MobileNumber != null || SMS != null)
                {
                    using (var wb = new WebClient())
                    {
                        byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "YTBjYmYwNDRkODUwNzAyMGQwODA0MGMxZDZlYzQ5MDQ="},
                {"numbers" , MobileNumber},
                {"message" , SMS},
                {"sender" , "DSSNDA"}
                });
                        string result = System.Text.Encoding.UTF8.GetString(response);
                        return 1;
                    }
                }

                else
                {
                    return -1;
                }

                //string strUrl = "http://api.mvaayoo.com/mvaayooapi/MessageCompose?user=namrata@daccess.co.in:sic@123&senderID=DSSNDA&receipientno=" + MobileNumber + "&dcs=0&msgtxt=" + SMS + "&state=4&template_id=1407162029025974718";

                //WebRequest request = WebRequest.Create(strUrl);
                //// If required by the server, set the proxy credentials.
                //request.Proxy.Credentials = CredentialCache.DefaultCredentials;
                //// Get the response.
                //WebResponse response = request.GetResponse();
                //// Display the status.
                //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                //// Get the stream containing content returned by the server.
                //Stream dataStream = response.GetResponseStream();
                //// Open the stream using a StreamReader for easy access.
                //StreamReader reader = new StreamReader(dataStream);
                //// Read the content.
                //string responseFromServer = reader.ReadToEnd();
                //// Display the content.
                //Console.WriteLine(responseFromServer);
                //Console.ReadLine();
                //// Clean up the streams and the response.
                //reader.Close();
                //response.Close();
                //return 1;
            }
            catch (Exception ex) { return 0; }

        }

        public static int SaveFileInDatabase(IFormFile image,string CompName)
        {
            Int32 Result = 0;
            byte[] bytedata;
            try
            {
                string strBase64 = "";
                if (image.Length > 0)
                {
                    using (StreamReader reader = new StreamReader(image.OpenReadStream()))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            reader.BaseStream.CopyTo(ms);
                            bytedata = ms.ToArray();
                            strBase64 = Convert.ToBase64String(bytedata);
                            SqlCommand cmd = new SqlCommand("SP_CompanyMaster");
                            cmd.Parameters.AddWithValue("@Command", "INSERT");
                            cmd.Parameters.AddWithValue("@FileData", strBase64);
                            cmd.Parameters.AddWithValue("@CompName", CompName.ToString());

                            Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);
                        }
                    }
                }
                return Result;
            }
            catch (Exception ex) { return -1; }

        }

        public static int SaveImageInDatabase(IFormFile image, long AppID)
        {
            Int32 Result = 0;
            byte[] bytedata;
            try
            {
                string strBase64 = "";
                if (image.Length > 0)
                {
                    using (StreamReader reader = new StreamReader(image.OpenReadStream()))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            reader.BaseStream.CopyTo(ms);
                            bytedata = ms.ToArray();
                            strBase64 = Convert.ToBase64String(bytedata);
                            SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");
                            cmd.Parameters.AddWithValue("@Command", "IMG_INSERT");
                            cmd.Parameters.AddWithValue("@FileData", strBase64);
                            cmd.Parameters.AddWithValue("@AppID", AppID.ToString());
                            Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);
                        }
                    }
                }
                return Result;
            }
            catch (Exception ex) { return -1; }

        }

        public static int UpdateFileInDatabase(IFormFile image, string CompName)
        {
            Int32 Result = 0;
            byte[] bytedata;
            try
            {
                string strBase64 = "";
                if (image.Length > 0)
                {
                    using (StreamReader reader = new StreamReader(image.OpenReadStream()))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            reader.BaseStream.CopyTo(ms);
                            bytedata = ms.ToArray();
                            strBase64 = Convert.ToBase64String(bytedata);
                            SqlCommand cmd = new SqlCommand("SP_CompanyMaster");
                            cmd.Parameters.AddWithValue("@Command", "UPDATE");
                            cmd.Parameters.AddWithValue("@FileData", strBase64);
                            cmd.Parameters.AddWithValue("@CompName", CompName.ToString());

                            Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);
                        }
                    }
                }
                return Result;
            }
            catch (Exception ex) { return -1; }

        }

        //Generate RandomNo
        public static int GenerateOTP()
        {
            int _min = 100000;
            int _max = 999999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }
}
