using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static VisitorManagementSystemWebApi.Model.Visitor.Appointment;

namespace VisitorManagementSystemWebApi.App_Code.DAL.Visitor
{
    public class AppointmentDal
    {
        public Int32 InsertAppointmenntData(AppointmentInsert AppointmentInsert)
         {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@command", AppointmentInsert.Command.ToString());
                cmd.Parameters.AddWithValue("@Visiid", AppointmentInsert.Visiid.ToString());
                cmd.Parameters.AddWithValue("@Empid", AppointmentInsert.Empid.ToString());
                cmd.Parameters.AddWithValue("@Visi_cat_id", AppointmentInsert.Visi_cat_id.ToString());
                cmd.Parameters.AddWithValue("@BranchID_visit", AppointmentInsert.BranchID_visit.ToString());
                cmd.Parameters.AddWithValue("@Deptid_visit", AppointmentInsert.Deptid_visit.ToString());
                cmd.Parameters.AddWithValue("@Purpose_id", AppointmentInsert.Purpose_id.ToString());
                cmd.Parameters.AddWithValue("@AppDatefrom", AppointmentInsert.AppDatefrom);
                cmd.Parameters.AddWithValue("@AppDateTo", AppointmentInsert.AppDateTo);
                cmd.Parameters.AddWithValue("@AppTimefrom", AppointmentInsert.AppTimefrom);
                cmd.Parameters.AddWithValue("@AppTimeto", AppointmentInsert.AppTimeto);
                cmd.Parameters.AddWithValue("@Assets", AppointmentInsert.Assets.ToString());

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

        public List<AppointmentDetails> GetAppointmentDeatils()
        {
            try
            {
                DataTable dt = new DataTable();
                List<AppointmentDetails> Lists = new List<AppointmentDetails>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "SELECT".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AppointmentDetails List = new AppointmentDetails();

                    List.Visiid = Convert.ToInt64(dt.Rows[i]["Visiid"].ToString());
                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
                    List.BranchID_visit = Convert.ToInt64(dt.Rows[i]["BranchID_visit"].ToString());
                    List.Deptid_visit = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    List.Purpose_id = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());


                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                    List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
                    List.EntryDate = Convert.ToDateTime(dt.Rows[i]["EntryDate"].ToString());
                    List.InDate = Convert.ToDateTime(dt.Rows[i]["InDate"].ToString());

                   
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


        public List<AppointmentDetails> GetAppointmentDeatilsByID(long Visiid)
        {
            try
            {
                DataTable dt = new DataTable();
                List<AppointmentDetails> Lists = new List<AppointmentDetails>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "FETCH".ToString());
                cmd.Parameters.AddWithValue("@Visiid", Visiid);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AppointmentDetails List = new AppointmentDetails();

                    List.Visiid = Convert.ToInt64(dt.Rows[i]["Visiid"].ToString());
                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisitorType = dt.Rows[i]["VisitorType"].ToString().Trim();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
                    List.BranchID_visit = Convert.ToInt64(dt.Rows[i]["BranchID_visit"].ToString());
                    List.Deptid_visit = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    List.Purpose_id = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());


                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                    List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
                    List.EntryDate = Convert.ToDateTime(dt.Rows[i]["EntryDate"].ToString());
                    List.InDate = Convert.ToDateTime(dt.Rows[i]["InDate"].ToString());


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


        public List<AppointmentDetails> GetAppointmentDeatilsByEmpID(long Empid)
        {
            try
            {
                DataTable dt = new DataTable();
                List<AppointmentDetails> Lists = new List<AppointmentDetails>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "BIND".ToString());
                cmd.Parameters.AddWithValue("@Empid", Empid);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AppointmentDetails List = new AppointmentDetails();

                    List.Visiid = Convert.ToInt64(dt.Rows[i]["Visiid"].ToString());
                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
                    List.BranchID_visit = Convert.ToInt64(dt.Rows[i]["BranchID_visit"].ToString());
                    List.Deptid_visit = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    List.Purpose_id = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());


                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                    List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
                    List.EntryDate = Convert.ToDateTime(dt.Rows[i]["EntryDate"].ToString());
                    List.InDate = Convert.ToDateTime(dt.Rows[i]["InDate"].ToString());


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

        public List<AppointmentDetailsByDept> GetAppointmentDeatilsByDept(string DeptName)
        {
            try
            {
                DataTable dt = new DataTable();
                List<AppointmentDetailsByDept> Lists = new List<AppointmentDetailsByDept>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "DeptSerach".ToString());
                cmd.Parameters.AddWithValue("@DeptName", DeptName);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AppointmentDetailsByDept List = new AppointmentDetailsByDept();

                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
                    List.BranchID_visit = Convert.ToInt64(dt.Rows[i]["BranchID_visit"].ToString());
                    List.BranchName = dt.Rows[i]["BranchName"].ToString();
                    List.Deptid_visit = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    List.DeptName = dt.Rows[i]["DeptName"].ToString();
                    List.Purpose_id = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    List.Purpose = dt.Rows[i]["Purpose"].ToString();
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());


                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                    List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
                    List.EntryDate = Convert.ToDateTime(dt.Rows[i]["EntryDate"].ToString());
                    List.InDate = Convert.ToDateTime(dt.Rows[i]["InDate"].ToString());


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


        public List<VisiPassDetails> GetPassDeatilsByVisiId(long Visiid)
        {
            try
            {
                DataTable dt = new DataTable();
                List<VisiPassDetails> Lists = new List<VisiPassDetails>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "Pass".ToString());
                cmd.Parameters.AddWithValue("@Visiid", Visiid);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    VisiPassDetails List = new VisiPassDetails();

                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
                    List.catName = dt.Rows[i]["catName"].ToString();
                    List.BranchID_visit = Convert.ToInt64(dt.Rows[i]["BranchID_visit"].ToString());
                    List.BranchName = dt.Rows[i]["BranchName"].ToString();
                    List.Deptid_visit = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    List.DeptName = dt.Rows[i]["DeptName"].ToString();
                    List.Purpose_id = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    List.Purpose = dt.Rows[i]["Purpose"].ToString();
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.HostName = dt.Rows[i]["HostName"].ToString();
                    List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());
                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                    List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    //List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
                    List.EntryDate = Convert.ToDateTime(dt.Rows[i]["EntryDate"].ToString());
                    List.InDate = Convert.ToDateTime(dt.Rows[i]["InDate"].ToString());
                    List.QRCode = dt.Rows[i]["QRCode"].ToString();
                    string s = (string)dt.Rows[i]["VisiPhoto"].ToString();
                    byte[] data = Convert.FromBase64String(s);
                    List.VisiPhoto = data;


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

        public List<AppointmentDetailsByDept> GetAppointmentDeatilsByBranch(string BranchName)
        {
            try
            {
                DataTable dt = new DataTable();
                List<AppointmentDetailsByDept> Lists = new List<AppointmentDetailsByDept>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "BranchSerach".ToString());
                cmd.Parameters.AddWithValue("@BranchName", BranchName);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AppointmentDetailsByDept List = new AppointmentDetailsByDept();

                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
                    List.BranchID_visit = Convert.ToInt64(dt.Rows[i]["BranchID_visit"].ToString());
                    List.BranchName = dt.Rows[i]["BranchName"].ToString();
                    List.Deptid_visit = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    List.DeptName = dt.Rows[i]["DeptName"].ToString();
                    List.Purpose_id = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    List.Purpose = dt.Rows[i]["Purpose"].ToString();
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());


                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                    List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
                    List.EntryDate = Convert.ToDateTime(dt.Rows[i]["EntryDate"].ToString());
                    List.InDate = Convert.ToDateTime(dt.Rows[i]["InDate"].ToString());

                                   
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

        public List<AppointmentDetailsByDept> GetAppointmentDeatilsByDate(string AppDatefrom)
        {
            try
            {
                DataTable dt = new DataTable();
                List<AppointmentDetailsByDept> Lists = new List<AppointmentDetailsByDept>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "DateSerach".ToString());
                cmd.Parameters.AddWithValue("@AppDatefrom", AppDatefrom);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AppointmentDetailsByDept List = new AppointmentDetailsByDept();

                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
                    List.BranchID_visit = Convert.ToInt64(dt.Rows[i]["BranchID_visit"].ToString());
                    List.BranchName = dt.Rows[i]["BranchName"].ToString();
                    List.Deptid_visit = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    List.DeptName = dt.Rows[i]["DeptName"].ToString();
                    List.Purpose_id = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    List.Purpose = dt.Rows[i]["Purpose"].ToString();
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());
                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                    List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
                    List.EntryDate = Convert.ToDateTime(dt.Rows[i]["EntryDate"].ToString());
                    List.InDate = Convert.ToDateTime(dt.Rows[i]["InDate"].ToString());


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

        public List<AppointmentDetailsByDept> GetAppointmentbasicreport(string DeptName,string AppDatefrom)
        {
            try
            {
                DataTable dt = new DataTable();
                List<AppointmentDetailsByDept> Lists = new List<AppointmentDetailsByDept>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "DateSerach".ToString());
                cmd.Parameters.AddWithValue("@DeptName", DeptName);
                cmd.Parameters.AddWithValue("@AppDatefrom", AppDatefrom);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AppointmentDetailsByDept List = new AppointmentDetailsByDept();

                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
                    List.BranchID_visit = Convert.ToInt64(dt.Rows[i]["BranchID_visit"].ToString());
                    List.BranchName = dt.Rows[i]["BranchName"].ToString();
                    List.Deptid_visit = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    List.DeptName = dt.Rows[i]["DeptName"].ToString();
                    List.Purpose_id = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    List.Purpose = dt.Rows[i]["Purpose"].ToString();
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());
                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                    List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
                    List.EntryDate = Convert.ToDateTime(dt.Rows[i]["EntryDate"].ToString());
                    List.InDate = Convert.ToDateTime(dt.Rows[i]["InDate"].ToString());


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

        public List<AppointmentStartEnd> GetAppointmentStartEndTime(string AppDatefrom)
        {
            try
            {
                DataTable dt = new DataTable();
                List<AppointmentStartEnd> Lists = new List<AppointmentStartEnd>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "TimeSerach".ToString());
                cmd.Parameters.AddWithValue("@AppDatefrom", AppDatefrom);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AppointmentStartEnd List = new AppointmentStartEnd();

                    List.starttime = dt.Rows[i]["starttime"].ToString();
                    List.endtime = dt.Rows[i]["endtime"].ToString();
    
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

        public List<AppointmentStartEnd> GetPersonaltimelineStartEndTime(string AppDatefrom,long Empid)
        {
            try
            {
                DataTable dt = new DataTable();
                List<AppointmentStartEnd> Lists = new List<AppointmentStartEnd>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "VisiTimeline".ToString());
                cmd.Parameters.AddWithValue("@AppDatefrom", AppDatefrom);
                cmd.Parameters.AddWithValue("@Empid", Empid);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AppointmentStartEnd List = new AppointmentStartEnd();

                    List.starttime = dt.Rows[i]["starttime"].ToString();
                    List.endtime = dt.Rows[i]["endtime"].ToString();

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

        public List<AppointmentCount> GetVisitorCount(string SearchDate)
        {
            try
            {
                DataTable dt = new DataTable();

                List<AppointmentCount> Lists = new List<AppointmentCount>();
                SqlCommand cmd = new SqlCommand("SP_CategoryMaster");

                cmd.Parameters.AddWithValue("@Command", "VisiCount".ToString());
                cmd.Parameters.AddWithValue("@SearchDate", SearchDate);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    AppointmentCount VCount = new AppointmentCount();

                  //  VCount.Scheduled = Convert.ToInt64(dt.Rows[0]["Scheduled"].ToString());
                    VCount.Visited = Convert.ToInt64(dt.Rows[0]["Visited"].ToString());                
                    VCount.WalkIn = Convert.ToInt64(dt.Rows[0]["WalkIn"].ToString());
                    VCount.InPremises = Convert.ToInt64(dt.Rows[0]["InPremises"].ToString());

                    Lists.Add(VCount);
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

        public Int32 RemoveAppointment(Int64 Visiid)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");
                cmd.Parameters.AddWithValue("@Command", "DELETE");
                cmd.Parameters.AddWithValue("@Visiid", Visiid.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }

    }
}
