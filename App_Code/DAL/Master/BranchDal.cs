using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static VisitorManagementSystemWebApi.Model.Master.Branch;

namespace VisitorManagementSystemWebApi.App_Code.DAL.Master
{
    public class BranchDal
    {
        public Int32 InsertBranchData(BranchInsert branchInsert)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_BranchMaster");

                cmd.Parameters.AddWithValue("@command", branchInsert.Command.ToString());
                cmd.Parameters.AddWithValue("@BranchName", branchInsert.BranchName.ToString());
                cmd.Parameters.AddWithValue("@Address", branchInsert.Address.ToString());

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
        public List<BranchDetails> GetBranchDeatils()
        {
            try
            {
                DataTable dt = new DataTable();
                List<BranchDetails> Lists = new List<BranchDetails>();

                SqlCommand cmd = new SqlCommand("SP_BranchMaster");

                cmd.Parameters.AddWithValue("@Command", "SELECT".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BranchDetails List = new BranchDetails();

                    List.BranchID = Convert.ToInt64(dt.Rows[i]["BranchID"].ToString());
                    List.BranchName = dt.Rows[i]["BranchName"].ToString();
                    List.Address = dt.Rows[i]["Address"].ToString();
                
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


        public List<BranchDetails> GetBranchDeatilsById(long BranchID)
        {
            try
            {
                DataTable dt = new DataTable();
                List<BranchDetails> Lists = new List<BranchDetails>();

                SqlCommand cmd = new SqlCommand("SP_BranchMaster");

                cmd.Parameters.AddWithValue("@Command", "FETCH".ToString());
                cmd.Parameters.AddWithValue("@BranchID", BranchID);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BranchDetails List = new BranchDetails();

                    List.BranchID = Convert.ToInt64(dt.Rows[i]["BranchID"].ToString());
                    List.BranchName = dt.Rows[i]["BranchName"].ToString();
                    List.Address = dt.Rows[i]["Address"].ToString();

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
        public Int32 UpdateBranchDetails(BranchUpdate branchUpdate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_BranchMaster");

                cmd.Parameters.AddWithValue("@Command", "UPDATE".ToString());

                cmd.Parameters.AddWithValue("@BranchID", branchUpdate.BranchID);
                cmd.Parameters.AddWithValue("@BranchName", branchUpdate.BranchName.ToString());
                cmd.Parameters.AddWithValue("@Address", branchUpdate.Address.ToString());

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

        public Int32 RemoveBranch(Int64 BranchID)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_BranchMaster");
                cmd.Parameters.AddWithValue("@Command", "DELETE");
                cmd.Parameters.AddWithValue("@BranchID", BranchID.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }
    }
}
