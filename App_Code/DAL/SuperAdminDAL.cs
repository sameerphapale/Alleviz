using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
                cmd.Parameters.AddWithValue("@ToDate", obj.ToDate);
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
        public List<SuperAdminModel> GetSuperAdminDeatils(SuperAdminModel objmodel)
        {
            try
            {
                DataTable dt = new DataTable();
                List<SuperAdminModel> Lists = new List<SuperAdminModel>();

                SqlCommand cmd = new SqlCommand("SP_SuperAdminMaster");

                cmd.Parameters.AddWithValue("@Command", "GETDATA".ToString());


                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SuperAdminModel List = new SuperAdminModel();
                    cmd.Parameters.AddWithValue("@ID", objmodel.ID);
                    cmd.Parameters.AddWithValue("@NoofGates", objmodel.NoofGates);
                    cmd.Parameters.AddWithValue("@MacID", objmodel.MacID);
                    cmd.Parameters.AddWithValue("@SMSSending", objmodel.SMSSending);
                    cmd.Parameters.AddWithValue("@SMSPackage", objmodel.SMSPackage);
                    cmd.Parameters.AddWithValue("@EmailSending", objmodel.EmailSending);
                    cmd.Parameters.AddWithValue("@ToDate", objmodel.ToDate);
                    cmd.Parameters.AddWithValue("@SenderEmail", objmodel.SenderEmail);
                    cmd.Parameters.AddWithValue("@SMTPServer", objmodel.SMTPServer);
                    cmd.Parameters.AddWithValue("@EmailUsername", objmodel.EmailUsername);
                    cmd.Parameters.AddWithValue("@EmailPassword", objmodel.EmailPassword);
                    cmd.Parameters.AddWithValue("@PortNO", objmodel.PortNO);

                    Lists.Add(List);
                }
                return Lists;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
        public Int32 UpdateSuperAdminDetails(SuperAdminModel objmodel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SuperAdminMaster");

                cmd.Parameters.AddWithValue("@Command", "UPDATE".ToString());

                cmd.Parameters.AddWithValue("@ID", objmodel.ID);
                cmd.Parameters.AddWithValue("@NoofGates", objmodel.NoofGates);
                cmd.Parameters.AddWithValue("@MacID", objmodel.MacID);
                cmd.Parameters.AddWithValue("@SMSSending", objmodel.SMSSending);
                cmd.Parameters.AddWithValue("@SMSPackage", objmodel.SMSPackage);
                cmd.Parameters.AddWithValue("@EmailSending", objmodel.EmailSending);
                cmd.Parameters.AddWithValue("@ToDate", objmodel.ToDate);
                cmd.Parameters.AddWithValue("@SenderEmail", objmodel.SenderEmail);
                cmd.Parameters.AddWithValue("@SMTPServer", objmodel.SMTPServer);
                cmd.Parameters.AddWithValue("@EmailUsername", objmodel.EmailUsername);
                cmd.Parameters.AddWithValue("@EmailPassword", objmodel.EmailPassword);
                cmd.Parameters.AddWithValue("@PortNO", objmodel.PortNO);



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
        public List<SuperAdminSMSCountModel> GetSMSCount(SuperAdminSMSCountModel objsmscnt)
        {
            try
            {
                List<SuperAdminSMSCountModel> Lists = new List<SuperAdminSMSCountModel>();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SP_SuperAdminMaster");
                cmd.Parameters.AddWithValue("@Command", "GETCOUNT");
                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objsmscnt.Total = Convert.ToInt64(dt.Rows[0][0]);
                    objsmscnt.Used = Convert.ToInt64(dt.Rows[0][1]);
                    objsmscnt.Available = Convert.ToInt64(dt.Rows[0][2]);

                    Lists.Add(objsmscnt);
                }
                return Lists;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
        public Int32 ActivateUser()
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_CheckPassword");
                cmd.Parameters.AddWithValue("@Command", "UPDATEUSER");

                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }
    }
}
