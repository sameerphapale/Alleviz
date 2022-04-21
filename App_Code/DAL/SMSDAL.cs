using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using VisitorManagementSystemWebApi.Model;

namespace VisitorManagementSystemWebApi.App_Code.DAL
{
    public class SMSDAL
    {
        SMSModel objsms = new SMSModel();
        public void SendSMS(SMSModel objsend)
        {
            try
            {
                DataSet ds = GetSMSDetails(objsend);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string MobileNumber = ds.Tables[0].Rows[0]["STo"].ToString();
                        string Message = ds.Tables[0].Rows[0]["SMessage"].ToString();
                        if (MobileNumber != null || Message != null)
                        {
                            using (var wb = new WebClient())
                            {
                                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                        {
                        {"apikey" , "YTBjYmYwNDRkODUwNzAyMGQwODA0MGMxZDZlYzQ5MDQ="},
                        {"numbers" , MobileNumber},
                        {"message" , Message},
                        {"sender" , "DSSEPL"}
                        });
                                string result = System.Text.Encoding.UTF8.GetString(response);

                            }
                        }

                    }
                    UpdateSMSDetails(objsend);
                }

            }
            catch (Exception ex)
            {
            }

        }

        public Int32 SendEPassSMS(SMSModel obj)
        {
            try
            {
                DataSet ds = GetSMSDetails(obj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Int64 SID = Convert.ToInt64(ds.Tables[0].Rows[0]["SID"]);
                        string MobileNumber = ds.Tables[0].Rows[0]["STo"].ToString();
                        string Message = ds.Tables[0].Rows[0]["SMessage"].ToString();
                        if (MobileNumber != null || Message != null)
                        {
                            using (var wb = new WebClient())
                            {
                                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                            {
                            {"apikey" , "YTBjYmYwNDRkODUwNzAyMGQwODA0MGMxZDZlYzQ5MDQ="},
                            {"numbers" , MobileNumber},
                            {"message" , Message},
                            {"sender" , "DSSEPL"}
                            });
                                //string result = "";
                                string result = System.Text.Encoding.UTF8.GetString(response);
                                SID = obj.SID;
                            }
                        }
                    }
                    UpdateSMSDetails(obj);
                }
            }
            catch (Exception ex)
            {
            }
            return 1;
        }

        public static Int32 UpdateSMSDetails(SMSModel objupdate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SMSMaster");
                cmd.Parameters.AddWithValue("@Command", "UPDATE");
                cmd.Parameters.AddWithValue("@SID", objupdate.SID);
                cmd.Parameters.AddWithValue("@AppID", objupdate.AppID);
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

        public static DataSet GetSMSDetails(SMSModel obj)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SMSMaster");
                cmd.Parameters.AddWithValue("@Command", "SELECT");
                cmd.Parameters.AddWithValue("@SID", obj.SID);
                cmd.Parameters.AddWithValue("@AppID", obj.AppID);
                ds = SqlHelper.ExtecuteProcedureReturnDataSet(cmd);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
            return ds;

        }

        public Int32 InsertSMSDetails(SMSModel obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SMSMaster");
                cmd.Parameters.AddWithValue("@Command", "INSERT");
                cmd.Parameters.AddWithValue("@SID", obj.SID);
                cmd.Parameters.AddWithValue("@AppID", obj.AppID);
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
