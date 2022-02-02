using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VisitorManagementSystemWebApi.Model.Master;
using static VisitorManagementSystemWebApi.Model.Master.Designation;

namespace VisitorManagementSystemWebApi.App_Code.DAL.Master
{
    public class DesignationDal
    {
        public Int32 InsertDesignationData(InsertDesignation insertDesignation)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_DesignationMaster");

                cmd.Parameters.AddWithValue("@command", insertDesignation.Command.ToString());
                cmd.Parameters.AddWithValue("@Designame", insertDesignation.Designame.ToString());

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

        public List<DesignationModel> GetDesignationDeatils()
        {
            try
            {
                DataTable dt = new DataTable();
                List<DesignationModel> Lists = new List<DesignationModel>();

                SqlCommand cmd = new SqlCommand("SP_DesignationMaster");

                cmd.Parameters.AddWithValue("@Command", "SELECT".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DesignationModel List = new DesignationModel();

                    List.DesigID = Convert.ToInt64(dt.Rows[i]["DesigID"].ToString());
                    List.Designame = dt.Rows[i]["Designame"].ToString();


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


        public List<DesignationModel> GetDesignationDeatilsById(long DesigID)
        {
            try
            {
                DataTable dt = new DataTable();
                List<DesignationModel> Lists = new List<DesignationModel>();

                SqlCommand cmd = new SqlCommand("SP_DesignationMaster");

                cmd.Parameters.AddWithValue("@Command", "FETCH".ToString());
                cmd.Parameters.AddWithValue("@DesigID", DesigID);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DesignationModel List = new DesignationModel();

                    List.DesigID = Convert.ToInt64(dt.Rows[i]["DesigID"].ToString());
                    List.Designame = dt.Rows[i]["Designame"].ToString(); 

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
        public Int32 UpdateDesignationDetails(DesignationModel designationModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_DesignationMaster");

                cmd.Parameters.AddWithValue("@Command", "UPDATE".ToString());

                cmd.Parameters.AddWithValue("@DesigID", designationModel.DesigID);
                cmd.Parameters.AddWithValue("@Designame", designationModel.Designame.ToString());


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

        public Int32 RemoveDesignation(Int64 DesigID)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_DesignationMaster");
                cmd.Parameters.AddWithValue("@Command", "DELETE");
                cmd.Parameters.AddWithValue("@DesigID", DesigID.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }

        public Int32 CheckDesigName(string Designame)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_DesignationMaster");
                cmd.Parameters.AddWithValue("@Command", "CHECK");
                cmd.Parameters.AddWithValue("@Designame", Designame.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }
    }
}
