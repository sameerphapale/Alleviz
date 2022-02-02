using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VisitorManagementSystemWebApi.Model.Master;
using static VisitorManagementSystemWebApi.Model.Master.Department;

namespace VisitorManagementSystemWebApi.App_Code.DAL.Master
{
    public class DepartmentDal
    {
        public Int32 InsertDepartmentData(DeptInsert deptInsert)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_DepartmentMaster");

                cmd.Parameters.AddWithValue("@command", deptInsert.Command.ToString());
                cmd.Parameters.AddWithValue("@DeptName", deptInsert.DeptName.ToString());
         
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

        public List<DeptModel> GetDepartmentDeatils()
        {
            try
            {
                DataTable dt = new DataTable();
                List<DeptModel> Lists = new List<DeptModel>();

                SqlCommand cmd = new SqlCommand("SP_DepartmentMaster");

                cmd.Parameters.AddWithValue("@Command", "SELECT".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DeptModel List = new DeptModel();

                    List.DeptID = Convert.ToInt64(dt.Rows[i]["DeptID"].ToString());
                    List.DeptName = dt.Rows[i]["DeptName"].ToString();
               

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

        public List<DeptModel> GetDepartmentDeatilsById(long DeptID)
        {
            try
            {
                DataTable dt = new DataTable();
                List<DeptModel> Lists = new List<DeptModel>();

                SqlCommand cmd = new SqlCommand("SP_DepartmentMaster");

                cmd.Parameters.AddWithValue("@Command", "FETCH".ToString());
                cmd.Parameters.AddWithValue("@DeptID", DeptID);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DeptModel List = new DeptModel();

                    List.DeptID = Convert.ToInt64(dt.Rows[i]["DeptID"].ToString());
                    List.DeptName = dt.Rows[i]["DeptName"].ToString();

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
        public Int32 UpdateDepartmentDetails(DeptModel deptModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_DepartmentMaster");

                cmd.Parameters.AddWithValue("@Command", "UPDATE".ToString());

                cmd.Parameters.AddWithValue("@DeptID", deptModel.DeptID);
                cmd.Parameters.AddWithValue("@DeptName", deptModel.DeptName.ToString());
              

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

        public Int32 CheckDeptName(string DeptName)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_DepartmentMaster");
                cmd.Parameters.AddWithValue("@Command", "CHECK");
                cmd.Parameters.AddWithValue("@DeptName", DeptName.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }

        public Int32 RemoveDepartment(Int64 DeptID)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_DepartmentMaster");
                cmd.Parameters.AddWithValue("@Command", "DELETE");
                cmd.Parameters.AddWithValue("@DeptID", DeptID.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }

    }
}
