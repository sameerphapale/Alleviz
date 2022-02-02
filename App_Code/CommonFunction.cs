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

        public static int SaveImageInDatabase(IFormFile image, long Visiid)
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
                            SqlCommand cmd = new SqlCommand("SP_VisitorDetails");
                            cmd.Parameters.AddWithValue("@Command", "IMG_INSERT");
                            cmd.Parameters.AddWithValue("@FileData", strBase64);
                            cmd.Parameters.AddWithValue("@Visiid", Visiid.ToString());
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
