using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static VisitorManagementSystemWebApi.Model.Visitor.Login;

namespace VisitorManagementSystemWebApi.App_Code.DAL.Visitor
{
    public class LoginDal
    {

        public Int32 ChangePssword(string User_Name , string NewPass)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_ChangePassword");


                cmd.Parameters.AddWithValue("@Command", "CHECK");
                cmd.Parameters.AddWithValue("@User_Name", User_Name.ToString());
               // cmd.Parameters.AddWithValue("@Password", Password.ToString());
                cmd.Parameters.AddWithValue("@NewPass", NewPass.ToString());

             
                //cmd.Parameters.AddWithValue("@Password", Password.ToString());
                //cmd.Parameters.AddWithValue("@NewPass", NewPass.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }

        public Int32 CheckUsercredentials(string User_Name, string Password)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_CheckPassword");


                cmd.Parameters.AddWithValue("@Command", "CHECK");
                cmd.Parameters.AddWithValue("@User_Name", User_Name.ToString());
                cmd.Parameters.AddWithValue("@Password", Password.ToString());



                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }

        public List<UserDetails> GetUserDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                List<UserDetails> Lists = new List<UserDetails>();

                SqlCommand cmd = new SqlCommand("SP_UserMaster");

                cmd.Parameters.AddWithValue("@Command", "SELECT".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    UserDetails List = new UserDetails();

                    List.Role_id = Convert.ToInt64(dt.Rows[i]["Role_id"].ToString());
                    List.Username = dt.Rows[i]["User_Name"].ToString();

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



 

        public List<RoleList> GetRoleList()
        {
            try
            {
                DataTable dt = new DataTable();
                List<RoleList> Lists = new List<RoleList>();

                SqlCommand cmd = new SqlCommand("SP_ChangePassword");

                cmd.Parameters.AddWithValue("@Command", "BIND".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    RoleList List = new RoleList();

                    List.RoleID = Convert.ToInt64(dt.Rows[i]["RoleID"].ToString());
                    List.Role_Name = dt.Rows[i]["Role_Name"].ToString();
                    List.EMPSRNO = Convert.ToInt64(dt.Rows[i]["EMPSRNO"].ToString());
                    List.User_Name = dt.Rows[i]["User_Name"].ToString();
                    List.Emp_Name = dt.Rows[i]["Emp_Name"].ToString();

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
    }
}
