using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static VisitorManagementSystemWebApi.Model.Master.Category;

namespace VisitorManagementSystemWebApi.App_Code.DAL.Master
{
    public class CategoryDal
    {

        public Int32 InsertCategoryData(InsertCategory insertCategory)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_CategoryMaster");

                cmd.Parameters.AddWithValue("@command", insertCategory.Command.ToString());
                cmd.Parameters.AddWithValue("@catName", insertCategory.catName.ToString());
                cmd.Parameters.AddWithValue("@ApprovalAuthority", insertCategory.ApprovalAuthority.ToString());

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

        public Int32 InsertApprovalAuthoritData(InsertApprovalAuthority insertApprovalAuthority)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_CategoryMaster");

                cmd.Parameters.AddWithValue("@command", insertApprovalAuthority.Command.ToString());

                cmd.Parameters.AddWithValue("@catName", insertApprovalAuthority.catName.ToString());
                cmd.Parameters.AddWithValue("@ApprovalAuthority", insertApprovalAuthority.ApprovalAuthority.ToString());
                cmd.Parameters.AddWithValue("@ApprovalLevel", insertApprovalAuthority.ApprovalLevel.ToString());
                cmd.Parameters.AddWithValue("@Level1", insertApprovalAuthority.Level1.ToString());
                cmd.Parameters.AddWithValue("@Level2", insertApprovalAuthority.Level2.ToString());
                cmd.Parameters.AddWithValue("@Level3", insertApprovalAuthority.Level3.ToString());
                cmd.Parameters.AddWithValue("@Level4", insertApprovalAuthority.Level4.ToString());
                cmd.Parameters.AddWithValue("@Level5", insertApprovalAuthority.Level5.ToString());

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

        public List<CategoryModel> GetCategoryDeatils()
        {
            try
            {
                DataTable dt = new DataTable();
                List<CategoryModel> Lists = new List<CategoryModel>();

                SqlCommand cmd = new SqlCommand("SP_CategoryMaster");

                cmd.Parameters.AddWithValue("@Command", "SELECT".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CategoryModel List = new CategoryModel();

                    List.catid = Convert.ToInt32(dt.Rows[i]["catid"].ToString());
                    List.catName = dt.Rows[i]["catName"].ToString();
                    List.ApprovalAuthority = dt.Rows[i]["ApprovalAuthority"].ToString().Trim();
                    List.ApprovalLevel = Convert.ToInt32(dt.Rows[i]["ApprovalLevel"].ToString());
                    List.Level1 = Convert.ToInt64(dt.Rows[i]["Level1"].ToString());
                    List.Level2 = Convert.ToInt64(dt.Rows[i]["Level2"].ToString());
                    List.Level3 = Convert.ToInt64(dt.Rows[i]["Level3"].ToString());
                    List.Level4 = Convert.ToInt64(dt.Rows[i]["Level4"].ToString());
                    List.Level5 = Convert.ToInt64(dt.Rows[i]["Level5"].ToString());



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


        public List<CodeModel> GetQRCode(int Number)
        {
            
            try
            {
               
                List<CodeModel> Lists = new List<CodeModel>();

                Random r = new Random();
              
                for (int i = 0; i < Number; i++)
                {
                    CodeModel List = new CodeModel();
                    int num = r.Next();

                    List.Code = num;



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

        public List<CategoryModel> GetAllCategoryDetails(int catid)
        {
            try
            {
                DataTable dt = new DataTable();
                List<CategoryModel> Lists = new List<CategoryModel>();

                SqlCommand cmd = new SqlCommand("SP_CategoryMaster");

                cmd.Parameters.AddWithValue("@Command", "FETCH".ToString());
                cmd.Parameters.AddWithValue("@catid", catid);


                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    CategoryModel List = new CategoryModel();

                    List.catid = Convert.ToInt32(dt.Rows[i]["catid"].ToString());
                    List.catName = dt.Rows[i]["catName"].ToString();
                    List.ApprovalAuthority = dt.Rows[i]["ApprovalAuthority"].ToString().Trim();
                    List.ApprovalLevel = Convert.ToInt32(dt.Rows[i]["ApprovalLevel"].ToString());
                    List.Level1 = Convert.ToInt64(dt.Rows[i]["Level1"].ToString());
                    List.Level2 = Convert.ToInt64(dt.Rows[i]["Level2"].ToString());
                    List.Level3 = Convert.ToInt64(dt.Rows[i]["Level3"].ToString());
                    List.Level4 = Convert.ToInt64(dt.Rows[i]["Level4"].ToString());
                    List.Level5 = Convert.ToInt64(dt.Rows[i]["Level5"].ToString());

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
        public Int32 UpdateCategoryApprovalDetails(CategoryModel categoryModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_CategoryMaster");

                cmd.Parameters.AddWithValue("@Command", "Edit".ToString());

                cmd.Parameters.AddWithValue("@catid", categoryModel.catid);
                cmd.Parameters.AddWithValue("@catName", categoryModel.catName.ToString());
                cmd.Parameters.AddWithValue("@ApprovalAuthority", categoryModel.ApprovalAuthority.ToString());
                cmd.Parameters.AddWithValue("@ApprovalLevel", categoryModel.ApprovalLevel.ToString());
                cmd.Parameters.AddWithValue("@Level1", categoryModel.Level1.ToString());
                cmd.Parameters.AddWithValue("@Level2", categoryModel.Level2.ToString());
                cmd.Parameters.AddWithValue("@Level3", categoryModel.Level3.ToString());
                cmd.Parameters.AddWithValue("@Level4", categoryModel.Level4.ToString());
                cmd.Parameters.AddWithValue("@Level5", categoryModel.Level5.ToString());


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

        public Int32 UpdateCategoryDetails(CategoryModel categoryModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_CategoryMaster");

                cmd.Parameters.AddWithValue("@Command", "UPDATE".ToString());

                cmd.Parameters.AddWithValue("@catid", categoryModel.catid);
                cmd.Parameters.AddWithValue("@catName", categoryModel.catName.ToString());


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

        public Int32 RemoveCategory(Int64 catid)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_CategoryMaster");
                cmd.Parameters.AddWithValue("@Command", "DELETE");
                cmd.Parameters.AddWithValue("@catid", catid.ToString());

                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }
    }
}
