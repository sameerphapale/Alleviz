using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorManagementSystemWebApi.Model;

namespace VisitorManagementSystemWebApi.App_Code.DAL
{
    public class SuperAdminDAL
    {
        public Int32 InsertSuperAdminData(SuperAdminModel obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SuperAdminMaster");
                cmd.Parameters.AddWithValue("@Command", "INSERT");
                cmd.Parameters.AddWithValue("@NoofGates", obj.NoofGates);
                cmd.Parameters.AddWithValue("@MacID", obj.MacID);
                cmd.Parameters.AddWithValue("@SMSSending", obj.SMSSending);
                cmd.Parameters.AddWithValue("@SMSPackage", obj.SMSPackage);
                cmd.Parameters.AddWithValue("@EmailSending", obj.EmailSending);
                cmd.Parameters.AddWithValue("@EnableSSL", obj.EnableSSL);
                cmd.Parameters.AddWithValue("@SenderEmail", obj.SenderEmail);
                cmd.Parameters.AddWithValue("@SMTPServer", obj.SMTPServer);
                cmd.Parameters.AddWithValue("@EmailUsername", obj.EmailUsername);
                cmd.Parameters.AddWithValue("@EmailPassword", obj.EmailPassword);
                cmd.Parameters.AddWithValue("@PortNO", obj.PortNO);
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
