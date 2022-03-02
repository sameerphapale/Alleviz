using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static VisitorManagementSystemWebApi.Model.Master.Employee;

namespace VisitorManagementSystemWebApi.App_Code.DAL.Master
{
    public class EmployeeDal
    {

        public Int32 InsertEmployeeData(InsertEmployee insertEmployee)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_EmployeeMaster");

                cmd.Parameters.AddWithValue("@command", insertEmployee.Command.ToString());
                cmd.Parameters.AddWithValue("@Emp_Name", insertEmployee.Emp_Name.ToString());
                cmd.Parameters.AddWithValue("@ContactNo", insertEmployee.ContactNo.ToString());
                cmd.Parameters.AddWithValue("@Email", insertEmployee.Email.ToString());
                cmd.Parameters.AddWithValue("@DeptID", insertEmployee.DeptID.ToString());
                cmd.Parameters.AddWithValue("@DesigID", insertEmployee.DesigID.ToString());
                cmd.Parameters.AddWithValue("@BranchID", insertEmployee.BranchID.ToString());
                cmd.Parameters.AddWithValue("@Role_id", insertEmployee.Role_id.ToString());
                cmd.Parameters.AddWithValue("@User_Name", insertEmployee.User_Name.ToString());
                cmd.Parameters.AddWithValue("@Password", insertEmployee.Password.ToString());
                //cmd.Parameters.AddWithValue("@Status", insertEmployee.Status.ToString());

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

        public Int32 InsertEmployeeBulkData(BulkEmployee bulkEmployee)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_EmployeeMaster");

                cmd.Parameters.AddWithValue("@command", bulkEmployee.Command.ToString());
                cmd.Parameters.AddWithValue("@Emp_Name", bulkEmployee.Emp_Name.ToString());
                cmd.Parameters.AddWithValue("@ContactNo", bulkEmployee.ContactNo.ToString());
                cmd.Parameters.AddWithValue("@Email", bulkEmployee.Email.ToString());
                cmd.Parameters.AddWithValue("@DeptName", bulkEmployee.DeptID.ToString());
                cmd.Parameters.AddWithValue("@Designame", bulkEmployee.DesigID.ToString());
                cmd.Parameters.AddWithValue("@BranchName", bulkEmployee.BranchID.ToString());
                cmd.Parameters.AddWithValue("@Role_Name", bulkEmployee.RoleID.ToString());
                cmd.Parameters.AddWithValue("@User_Name", bulkEmployee.User_Name.ToString());
                cmd.Parameters.AddWithValue("@Password", bulkEmployee.Password.ToString());

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
        public List<EmployeeModel> GetEmployeeDeatils()
        {
            try
            {
                DataTable dt = new DataTable();
                List<EmployeeModel> Lists = new List<EmployeeModel>();

                SqlCommand cmd = new SqlCommand("SP_EmployeeMaster");

                cmd.Parameters.AddWithValue("@Command", "SELECT".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EmployeeModel List = new EmployeeModel();

                    List.EMPSRNO = Convert.ToInt64(dt.Rows[i]["EMPSRNO"].ToString());
                    List.Emp_Name = dt.Rows[i]["Emp_Name"].ToString();
                    List.User_Name = dt.Rows[i]["User_Name"].ToString();
                    List.ContactNo = Convert.ToInt64(dt.Rows[i]["ContactNo"].ToString());
                    List.Email = dt.Rows[i]["Email"].ToString();
                    List.DeptID = Convert.ToInt64(dt.Rows[i]["DeptID"].ToString());
                    List.DeptName = dt.Rows[i]["DeptName"].ToString();
                    List.DesigID = Convert.ToInt64(dt.Rows[i]["DesigID"].ToString());
                    List.Designame = dt.Rows[i]["Designame"].ToString();
                    List.BranchID = Convert.ToInt64(dt.Rows[i]["BranchID"].ToString());
                    List.BranchName = dt.Rows[i]["BranchName"].ToString();
                    List.RoleID = Convert.ToInt32(dt.Rows[i]["RoleID"].ToString());
                    List.Status = Convert.ToInt32(dt.Rows[i]["Status"].ToString());





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

        public List<MultipleUserHistory> CheckData(MultipleUser users)
        {
            //Int32 Event_Id = 0;
            DataSet covisitorresult = new DataSet();
            try
            {
                List<MultipleUserHistory> userHistories = new List<MultipleUserHistory>();


                var user1 = string.Join(",", users.Username.ToArray());
                var user2 = string.Join(",", users.MobileNo.ToArray());
                var user3 = string.Join(",", users.MailId.ToArray());
                var user4 = string.Join(",", users.RoleName.ToArray());
                SqlCommand cmd1 = new SqlCommand("[SP_Check_EmpDetails]");
                // cmd.Parameters.AddWithValue("@Guest_Aadhar_No", adharecrpt);

                cmd1.Parameters.AddWithValue("@Command", "CHECK");
                cmd1.Parameters.AddWithValue("@User_Name", user1);
                cmd1.Parameters.AddWithValue("@ContactNo", user2);
                cmd1.Parameters.AddWithValue("@Email", user3);
                cmd1.Parameters.AddWithValue("@Role_Name", user4);

                covisitorresult = SqlHelper.ExtecuteProcedureReturnDataSet(cmd1);

                foreach (DataRow row in covisitorresult.Tables[0].Rows)
                {

                    userHistories.Add(
                        new MultipleUserHistory()
                        {
                            NameOf_array = "User Name",
                            Users = row["value"].ToString(),
                            Status = Convert.ToInt32(row["Username"])
                        }
                        );
                }
                foreach (DataRow row in covisitorresult.Tables[1].Rows)
                {
                    userHistories.Add(
                        new MultipleUserHistory()
                        {
                            NameOf_array = "Mobile Number",
                            Users = row["val"].ToString(),
                            Status = Convert.ToInt32(row["MobileNo"])
                        }
                        );
                }
                foreach (DataRow row in covisitorresult.Tables[2].Rows)
                {
                    userHistories.Add(
                        new MultipleUserHistory()
                        {
                            NameOf_array = "Email ID",
                            Users = row["valu"].ToString(),
                            Status = Convert.ToInt32(row["EmailId"])
                        }
                        );
                }

                foreach (DataRow row in covisitorresult.Tables[3].Rows)
                {
                    userHistories.Add(
                        new MultipleUserHistory()
                        {
                            NameOf_array = "Role Name",
                            Users = row["valus"].ToString(),
                            Status = Convert.ToInt32(row["RoleName"])
                        }
                        );
                }
                return userHistories;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }

        public List<EmployeeModel> GetEmployeeDeatilsByID(long EMPSRNO)
        {
            try
            {
                DataTable dt = new DataTable();
                List<EmployeeModel> Lists = new List<EmployeeModel>();

                SqlCommand cmd = new SqlCommand("SP_EmployeeMaster");

                cmd.Parameters.AddWithValue("@Command", "BIND".ToString());
                cmd.Parameters.AddWithValue("@EMPSRNO", EMPSRNO);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EmployeeModel List = new EmployeeModel();

                    List.EMPSRNO = Convert.ToInt64(dt.Rows[i]["EMPSRNO"].ToString());
                    List.Emp_Name = dt.Rows[i]["Emp_Name"].ToString();
                    List.User_Name = dt.Rows[i]["User_Name"].ToString();
                    List.ContactNo = Convert.ToInt64(dt.Rows[i]["ContactNo"].ToString());
                    List.Email = dt.Rows[i]["Email"].ToString();
                    List.DeptID = Convert.ToInt64(dt.Rows[i]["DeptID"].ToString());
                    List.DeptName = dt.Rows[i]["DeptName"].ToString();
                    List.DesigID = Convert.ToInt64(dt.Rows[i]["DesigID"].ToString());
                    List.Designame = dt.Rows[i]["Designame"].ToString();
                    List.BranchID = Convert.ToInt64(dt.Rows[i]["BranchID"].ToString());
                    List.BranchName = dt.Rows[i]["BranchName"].ToString();
                    List.RoleID = Convert.ToInt32(dt.Rows[i]["RoleID"].ToString());
                    List.Status = Convert.ToInt32(dt.Rows[i]["Status"].ToString());
                    List.Password = dt.Rows[i]["Password"].ToString();





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


        public List<RoleModel> GetRoleDeatils()
        {
            try
            {
                DataTable dt = new DataTable();
                List<RoleModel> Lists = new List<RoleModel>();

                SqlCommand cmd = new SqlCommand("SP_GetRoleDetails");

                cmd.Parameters.AddWithValue("@Command", "SELECT".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    RoleModel List = new RoleModel();

                    List.RoleID = Convert.ToInt32(dt.Rows[i]["RoleID"].ToString());
                    List.Role_Name = dt.Rows[i]["Role_Name"].ToString();
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
        public Int32 UpdateEmployeeDetails(UpdateEmployee updateEmployee)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_EmployeeMaster");

                cmd.Parameters.AddWithValue("@Command", "UPDATE".ToString());

                cmd.Parameters.AddWithValue("@EMPSRNO", updateEmployee.EMPSRNO);
                cmd.Parameters.AddWithValue("@Emp_Name", updateEmployee.Emp_Name.ToString());
                cmd.Parameters.AddWithValue("@User_Name", updateEmployee.User_Name.ToString());
                cmd.Parameters.AddWithValue("@ContactNo", updateEmployee.ContactNo.ToString());
                cmd.Parameters.AddWithValue("@Email", updateEmployee.Email.ToString());
                cmd.Parameters.AddWithValue("@DeptID", updateEmployee.DeptID.ToString());
                cmd.Parameters.AddWithValue("@DesigID", updateEmployee.DesigID.ToString());
                cmd.Parameters.AddWithValue("@BranchID", updateEmployee.BranchID.ToString());
                cmd.Parameters.AddWithValue("@Role_id", updateEmployee.Role_id.ToString());
                cmd.Parameters.AddWithValue("@Status", updateEmployee.Status.ToString());
                cmd.Parameters.AddWithValue("@Password", updateEmployee.Password.ToString());



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


        public Int32 CheckEmpMNo(long ContactNo)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_EmployeeMaster");
                cmd.Parameters.AddWithValue("@Command", "CHECK");
                cmd.Parameters.AddWithValue("@ContactNo", ContactNo.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }


        public Int32 CheckEmpEmail(string Email)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_EmployeeMaster");
                cmd.Parameters.AddWithValue("@Command", "CHECKEmail");
                cmd.Parameters.AddWithValue("@Email", Email.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }
        public Int32 RemoveEmployee(Int64 EMPSRNO)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_EmployeeMaster");
                cmd.Parameters.AddWithValue("@Command", "DELETE");
                cmd.Parameters.AddWithValue("@EMPSRNO", EMPSRNO.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }


        public List<EmployeeProfile> GetEmpProfileDetails(string User_Name)
        {
            try
            {
                DataTable dt = new DataTable();
                List<EmployeeProfile> Lists = new List<EmployeeProfile>();

                SqlCommand cmd = new SqlCommand("SP_EmployeeMaster");

                cmd.Parameters.AddWithValue("@Command", "FETCH".ToString());
                cmd.Parameters.AddWithValue("@User_Name", User_Name);


                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    EmployeeProfile List = new EmployeeProfile();

                    List.EMPSRNO = Convert.ToInt64(dt.Rows[i]["EMPSRNO"].ToString());
                    List.Emp_Name = dt.Rows[i]["Emp_Name"].ToString();
                    List.User_Name = dt.Rows[i]["User_Name"].ToString();
                    List.ContactNo = Convert.ToInt64(dt.Rows[i]["ContactNo"].ToString());
                    List.Email = dt.Rows[i]["Email"].ToString();
                    List.DeptID = Convert.ToInt64(dt.Rows[i]["DeptID"].ToString());
                    List.DesigID = Convert.ToInt64(dt.Rows[i]["DesigID"].ToString());
                    List.BranchID = Convert.ToInt64(dt.Rows[i]["BranchID"].ToString());
                    List.RoleID = Convert.ToInt32(dt.Rows[i]["RoleID"].ToString());

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
