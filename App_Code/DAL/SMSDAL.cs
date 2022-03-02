using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VisitorManagementSystemWebApi.Model;

namespace VisitorManagementSystemWebApi.App_Code.DAL
{
    public class SMSDAL
    {
        SMSModel objsms = new SMSModel();
        public void SendSMS(Int64 SID)
        {
            try
            {
                DataSet ds = GetSMSDetails(SID);
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
                        //if(result > 0)
                        UpdateSMSDetails(SID);
                        //return 1;
                    }
                }
                else
                {
                    //return -1;
                }
            }
            catch (Exception ex)
            { //return 0;
              //
              //}
            }

        }

        public static Int32 UpdateSMSDetails(Int64 SID)
        {
            try
            {
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

        public static DataSet GetSMSDetails(Int64 SID)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SMSMaster");
                cmd.Parameters.AddWithValue("@Command", "SELECT");
                cmd.Parameters.AddWithValue("@SID", SID);
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
