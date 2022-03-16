using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static VisitorManagementSystemWebApi.Model.Master.Company;

namespace VisitorManagementSystemWebApi.App_Code.DAL.Master
{
    public class CompanyDal
    {
        

        public List<CompanyModel> GetCompanyDeatils()
        {
            try
            {
                DataTable dt = new DataTable();
                List<CompanyModel> Lists = new List<CompanyModel>();

                SqlCommand cmd = new SqlCommand("SP_CompanyMaster");

                cmd.Parameters.AddWithValue("@Command", "SELECT".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CompanyModel List = new CompanyModel();


                    List.CompID = Convert.ToInt64(dt.Rows[i]["CompID"].ToString());
                    List.CompName = dt.Rows[i]["CompName"].ToString();
                    string s = (string)dt.Rows[i]["CompanyLogo"].ToString();
                    byte[] data = Convert.FromBase64String(s);
                    List.CompanyLogo = data;

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


        public List<CompanyModel> GetCompanyDeatilsByID(long CompID)
        {
            try
            {
                DataTable dt = new DataTable();
                List<CompanyModel> Lists = new List<CompanyModel>();

                SqlCommand cmd = new SqlCommand("SP_CompanyMaster");

                cmd.Parameters.AddWithValue("@Command", "SELECT".ToString());
                cmd.Parameters.AddWithValue("@CompID", CompID);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CompanyModel List = new CompanyModel();


                    List.CompID = Convert.ToInt64(dt.Rows[i]["CompID"].ToString());
                    List.CompName = dt.Rows[i]["CompName"].ToString();
                    string s = (string)dt.Rows[i]["CompanyLogo"].ToString();
                    byte[] data = Convert.FromBase64String(s);
                    List.CompanyLogo = data;

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
        public Int32 UpdatecompanyDetails(CompanyModel companyModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_CompanyMaster");

                cmd.Parameters.AddWithValue("@Command", "UPDATE".ToString());

                cmd.Parameters.AddWithValue("@CompID", companyModel.CompID);
                cmd.Parameters.AddWithValue("@CompName", companyModel.CompName.ToString());
                cmd.Parameters.AddWithValue("@CompanyLogo", companyModel.CompanyLogo.ToString());

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

        public Int32 RemoveCompany(Int64 CompID)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_CompanyMaster");

                cmd.Parameters.AddWithValue("@Command", "DELETE");
                cmd.Parameters.AddWithValue("@CompID", CompID.ToString());

                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }
    }
}
